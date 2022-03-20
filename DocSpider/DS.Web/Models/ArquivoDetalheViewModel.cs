using System;

namespace DS.Web.Models
{
    public class ArquivoDetalheViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ContentType { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
