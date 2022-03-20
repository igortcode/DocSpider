using DS.Business.DTO.Arquivos;
using DS.Business.Entities;
using DS.Business.Interface.Repository;
using DS.Business.Interface.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Transactions;

namespace DS.Business.Services
{
    public class ArquivoService : IArquivoService
    {
        private readonly IArquivoRepository _arquivoRepository;
        private readonly ILogRepository _logRepository;

        public ArquivoService(IArquivoRepository arquivoRepository, ILogRepository logRepository)
        {
            _arquivoRepository = arquivoRepository;
            _logRepository = logRepository;
        }

        public async Task<ArquivoBuscaComBlobDTO> Novo(ArquivoCadastroDTO novoArquivo)
        {
            
            if (await _arquivoRepository.ExisteCadastro(novoArquivo.Dados.FileName))
                throw new Exception("Já existe um cadastro com esse nome!");

            Arquivo result = new Entities.Arquivo
            {
                Nome = novoArquivo.Dados.FileName,
                Titulo = novoArquivo.Titulo,
                Descricao = novoArquivo.Descricao,
                ContentType = novoArquivo.Dados.ContentType,
                Dados = ToBiteArray(novoArquivo.Dados),
                DataCadastro = DateTime.Now,
            };

            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await _arquivoRepository.Adicionar(result);
                await _logRepository.Adicionar(new Log { Mensagem = $"Fulano cadastrou o arquivo com Id : {result.Id}", DataModificacao = DateTime.Now });
                transaction.Complete();
            }

            return await _arquivoRepository.BuscaComBlob(result.Id);
        }

        public async Task<ArquivoBuscaComBlobDTO> Atualizar(ArquivoAtualizarDTO atualizaArquivo)
        {

            if (await _arquivoRepository.ExisteCadastro(atualizaArquivo.Id))
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var arquivo = await _arquivoRepository.ObterPorId(atualizaArquivo.Id);
                    mapToAquivo(atualizaArquivo, ref arquivo);
                    await _arquivoRepository.Atualizar(arquivo);
                    await _logRepository.Adicionar(new Log { Mensagem = $"Fulano editou o arquivo com Id = {atualizaArquivo.Id}.", DataModificacao = DateTime.Now });

                    transaction.Complete();
                }
                return await _arquivoRepository.BuscaComBlob(atualizaArquivo.Id);
            }
            else
                throw new Exception("Arquivo não encontrado com esse identificador!");
        }

        public async Task<ArquivoBuscaComBlobDTO> BuscaCompletaPorId(Guid Id)
        {
            var result = await _arquivoRepository.BuscaComBlob(Id);
            return result;
        }

        public async Task<ArquivoBuscaSemBlobDTO> BuscaSimplesPorId(Guid Id)
        {
            var result = await _arquivoRepository.BuscaSemBlob(Id);
            return result;
        }

        public async Task<ArquivoListagemDTO> Listar(int pagina)
        {
            pagina = pagina < 1 ? 1 : pagina;
            var result = await _arquivoRepository.ListarSemBlob(pagina);
            return result;
        }

        public async Task Excluir(Guid Id)
        {
            await _arquivoRepository.Remover(Id);
            await _logRepository.Adicionar(new Log { Mensagem = $"Fulano excluiu o arquivo com Id = {Id}.", DataModificacao = DateTime.Now });
        }


        public async Task<ArquivoListagemDTO> Pesquisa(int pagina, string pesquisa)
        {
            pagina = pagina < 1 ? 1 : pagina;
            var result = await _arquivoRepository.Pesquisar(pagina, pesquisa);
            return result;
        }

        private byte[] ToBiteArray(IFormFile file)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                file.OpenReadStream().CopyTo(ms);
                return ms.ToArray();
            }
        }

        private void mapToAquivo(ArquivoAtualizarDTO atualizaArquivo, ref Arquivo arquivo)
        {
            arquivo.Nome = atualizaArquivo.Dados.FileName;
            arquivo.Titulo = atualizaArquivo.Titulo;
            arquivo.Descricao = atualizaArquivo.Descricao;
            arquivo.ContentType = atualizaArquivo.ContentType;
            arquivo.Dados = ToBiteArray(atualizaArquivo.Dados);
        }
    }
}
