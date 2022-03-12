using System.Collections.Generic;

namespace DS.Business.DTO.Arquivos
{
    public class ArquivoListagemDTO
    {
        public long MaxPage { get; set; }
        public List<ArquivoBuscaSemBlobDTO> Data { get; set; }
    }
}
