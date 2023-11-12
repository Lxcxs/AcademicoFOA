using Academico.Models;
using Microsoft.EntityFrameworkCore;

namespace Academico.Data
{
    public class AcademicoContext : DbContext
    {
        public AcademicoContext(DbContextOptions<AcademicoContext> options) : base(options)
        { }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<CursoDisciplina> CursosDisciplina { get; set; }
   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CursoDisciplina>().HasKey(cd => new { cd.DisciplinaID, cd.CursoId });

            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.Disciplinas)
                .WithMany(e => e.Alunos)
                .UsingEntity<AlunoDisciplina>(j => j.HasKey("AlunoId", "DisciplinaId", "Semestre" , "Ano"));
        }
   

        public DbSet<Academico.Models.AlunoDisciplina>? AlunoDisciplina { get; set; }


    }
}
