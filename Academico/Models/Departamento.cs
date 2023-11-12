﻿namespace Academico.Models
{
    public class Departamento
    {
        public long? Id { get; set; }
        public string Nome { get; set; }
        public long InstituicaoID { get; set; }
        public Instituicao? Instituicao { get; set; }
    }
}
