using AutoMapper;
using DS.Business.DTO.Arquivos;
using DS.Web.Models;

namespace DS.Web.Configuration.AutoMapper
{
    public class ArquivoProfile : Profile
    {
        public ArquivoProfile()
        {
            CreateMap<ArquivoCadastroViewModel, ArquivoCadastroDTO>()
                .ReverseMap();

            CreateMap<ArquivoDetalheSemBlobViewModel, ArquivoBuscaSemBlobDTO>()
                .ReverseMap();

            CreateMap<ArquivoDetalheViewModel, ArquivoBuscaComBlobDTO>()
               .ReverseMap();

            CreateMap<ArquivoCadastroViewModel, ArquivoBuscaComBlobDTO>()
              .ReverseMap();

            CreateMap<ArquivoCadastroViewModel, ArquivoAtualizarDTO>()
             .ReverseMap();
        }
    }
}
