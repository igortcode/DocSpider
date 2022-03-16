using DS.Business.DTO.Arquivos;
using DS.Business.Entities;
using System;
using System.Threading.Tasks;

namespace DS.Business.Interface.Repository
{
    public interface IArquivoRepository : IGenericRepository<Arquivo>
    {
        Task<ArquivoBuscaComBlobDTO> BuscaComBlob(Guid Id);
        Task<ArquivoBuscaSemBlobDTO> BuscaSemBlob(Guid Id);
        Task<bool> ExisteCadastro(string nome);
        Task<bool> ExisteCadastro(Guid id);
        Task<ArquivoListagemDTO> ListarSemBlob(int pagina);
        Task<ArquivoListagemDTO> Pesquisar(int pagina, string pesquisa);
    }
}
