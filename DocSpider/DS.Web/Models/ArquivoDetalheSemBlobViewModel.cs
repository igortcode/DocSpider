using System;
using System.ComponentModel.DataAnnotations;

namespace DS.Web.Models
{
    public class ArquivoDetalheSemBlobViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public string ContentType { get; set; }
        [Display(Name = "Data de Cadastro")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DataCadastro { get; set; }
    }
}
