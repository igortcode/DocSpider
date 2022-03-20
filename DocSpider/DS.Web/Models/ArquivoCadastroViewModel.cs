using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using DS.Web.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DS.Web.Models
{
    public class ArquivoCadastroViewModel
    {
        [Key]
        public Guid Id { get; set; }
       
        [Required(ErrorMessage = "Campo {0} é obrigatório!")]
        [StringLength(100, ErrorMessage ="Campo {0} não pode exceder o limite de 100 caracteres!")]
        [Display(Name ="Título")]
        public string Titulo { get; set; }
        
        [StringLength(2000, ErrorMessage = "Campo {0} não pode exceder o limite de 2000 caracteres!")]
        [Required(ErrorMessage = "Campo {0} é obrigatório!")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "Campo {0} é obrigatório!")]
        [TipoArquivoAttribut(ErrorMessage ="Tipo de {0} inválido!")]
        public IFormFile Arquivo { get; set; }
    }
}
