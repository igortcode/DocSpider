using DS.Business.DTO.Arquivos;
using System;
using System.Threading.Tasks;

namespace DS.Business.Interface.Service
{
    public interface IArquivoService
    {
        Task<ArquivoBuscaComBlobDTO> Novo(ArquivoCadastroDTO novoArquivo);
        Task<ArquivoBuscaComBlobDTO> Atualizar(ArquivoAtualizarDTO atualizaArquivo);
        Task<ArquivoListagemDTO> Listar(int pagina);
        Task<ArquivoBuscaSemBlobDTO> BuscaSimplesPorId(Guid Id);
        Task<ArquivoBuscaComBlobDTO> BuscaCompletaPorId(Guid Id);
        Task<ArquivoListagemDTO> Pesquisa(int pagina, string pesquisa);
    }
}
