using System;

namespace DS.Business.DTO.Arquivos
{
    public class ArquivoBuscaSemBlobDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ContentType { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
