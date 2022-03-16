using Microsoft.AspNetCore.Http;
using System;

namespace DS.Business.DTO.Arquivos
{
    public class ArquivoAtualizarDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ContentType { get; set; }
        public IFormFile Dados { get; set; }
    }
}
