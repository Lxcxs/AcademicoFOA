using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Academico.Models
{
    public class Disciplina
    {
        public int? Id { get; set; }
        [Required]
        public string Nome { get; set; } = string.Empty;
        [IntegerValidator(MinValue = 20)]
        public int CargaHoraria { get; set; }
        public ICollection<CursoDisciplina>? CursosDisciplinas { get; set; }
        public ICollection<AlunoDisciplina>? AlunoDisciplinas { get; set; }

        public List<Aluno> Alunos { get; } = new();
    }
}
