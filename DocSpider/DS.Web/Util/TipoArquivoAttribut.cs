using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DS.Web.Util
{
    public class TipoArquivoAttribut : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is IFormFile)
            {
                IFormFile arquivo = (IFormFile)value;

                if (arquivo.FileName.EndsWith(".exe") || arquivo.FileName.EndsWith(".zip") || arquivo.FileName.EndsWith(".bat"))
                {
                    return false;
                }
                else
                    return true;
            }
            else
                return false;
        }
    }
}
