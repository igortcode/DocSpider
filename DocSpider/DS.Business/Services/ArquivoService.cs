using DS.Business.DTO.Arquivos;
using DS.Business.Interface.Service;
using System;
using System.Threading.Tasks;

namespace DS.Business.Services
{
    public class ArquivoService : IArquivoService
    {
        public Task<ArquivoBuscaComBlobDTO> Novo(ArquivoCadastroDTO novoArquivo)
        {
            throw new NotImplementedException();
        }
        public Task<ArquivoBuscaComBlobDTO> Atualizar(ArquivoAtualizarDTO atualizaArquivo)
        {
            throw new NotImplementedException();
        }

        public Task<ArquivoBuscaComBlobDTO> BuscaCompletaPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<ArquivoBuscaSemBlobDTO> BuscaSimplesPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<ArquivoListagemDTO> Listar(int pagina)
        {
            throw new NotImplementedException();
        }

      
        public Task<ArquivoListagemDTO> Pesquisa(int pagina, string pesquisa)
        {
            throw new NotImplementedException();
        }
    }
}
