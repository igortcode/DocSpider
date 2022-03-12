using System;

namespace DS.Business.Entities
{
    public class Arquivo : Entity
    {
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ContentType { get; set; }
        public byte[] Dados { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
