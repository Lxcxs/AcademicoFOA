namespace Academico.Models
{
    public class CursoDisciplina
    {
        internal object DisciplinaId;

        public int CursoId { get; set; }
        public Curso? Curso { get; set; }
        public int DisciplinaID { get; set; }
        public Disciplina? Disciplina { get; set; }
    }
}