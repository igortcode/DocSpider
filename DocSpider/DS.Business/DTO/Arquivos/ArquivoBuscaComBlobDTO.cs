using System;

namespace DS.Business.DTO.Arquivos
{
    public class ArquivoBuscaComBlobDTO
    {
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ContentType { get; set; }
        public byte[] Dados { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
