using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Academico.Data;
using Academico.Models;

namespace Academico.Controllers
{
    public class CursoDisciplinaController : Controller
    {
        private readonly AcademicoContext _context;

        public CursoDisciplinaController(AcademicoContext context)
        {
            _context = context;
        }

        // GET: CursoDisciplina
        public async Task<IActionResult> Index()
        {
            var academicoContext = _context.CursosDisciplina.Include(c => c.Curso).Include(c => c.Disciplina);
            return View(await academicoContext.ToListAsync());
        }

        // GET: CursoDisciplina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CursosDisciplina == null)
            {
                return NotFound();
            }

            var cursoDisciplina = await _context.CursosDisciplina
                .Include(c => c.Curso)
                .Include(c => c.Disciplina)
                .FirstOrDefaultAsync(m => m.DisciplinaID == id);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }

            return View(cursoDisciplina);
        }

        // GET: CursoDisciplina/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Id");
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "Id", "Id");
            return View();
        }

        // POST: CursoDisciplina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CursoId,DisciplinaID")] CursoDisciplina cursoDisciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoDisciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Id", cursoDisciplina.CursoId);
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "Id", "Id", cursoDisciplina.DisciplinaID);
            return View(cursoDisciplina);
        }

        // GET: CursoDisciplina/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CursosDisciplina == null)
            {
                return NotFound();
            }

            var cursoDisciplina = await _context.CursosDisciplina.FindAsync(id);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Id", cursoDisciplina.CursoId);
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "Id", "Id", cursoDisciplina.DisciplinaID);
            return View(cursoDisciplina);
        }

        // POST: CursoDisciplina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CursoId,DisciplinaID")] CursoDisciplina cursoDisciplina)
        {
            if (id != cursoDisciplina.DisciplinaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoDisciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoDisciplinaExists(cursoDisciplina.DisciplinaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Id", cursoDisciplina.CursoId);
            ViewData["DisciplinaID"] = new SelectList(_context.Disciplinas, "Id", "Id", cursoDisciplina.DisciplinaID);
            return View(cursoDisciplina);
        }

        // GET: CursoDisciplina/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CursosDisciplina == null)
            {
                return NotFound();
            }

            var cursoDisciplina = await _context.CursosDisciplina
                .Include(c => c.Curso)
                .Include(c => c.Disciplina)
                .FirstOrDefaultAsync(m => m.DisciplinaID == id);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }

            return View(cursoDisciplina);
        }

        // POST: CursoDisciplina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CursosDisciplina == null)
            {
                return Problem("Entity set 'AcademicoContext.CursosDisciplina'  is null.");
            }
            var cursoDisciplina = await _context.CursosDisciplina.FindAsync(id);
            if (cursoDisciplina != null)
            {
                _context.CursosDisciplina.Remove(cursoDisciplina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoDisciplinaExists(int id)
        {
          return (_context.CursosDisciplina?.Any(e => e.DisciplinaID == id)).GetValueOrDefault();
        }
    }
}
