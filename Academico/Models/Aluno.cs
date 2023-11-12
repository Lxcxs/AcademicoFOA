namespace Academico.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<AlunoDisciplina>? AlunoDisciplinas { get; set; }
        public List<Disciplina> Disciplinas { get; } = new();

    }
}
