using DS.Business.DTO.Arquivos;
using DS.Business.Entities;
using DS.Business.Interface.Repository;
using DS.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DS.Data.Repository
{
    public class ArquivoRepository : GenericRepository<Arquivo>, IArquivoRepository
    {
        private readonly IDapperRepository _dapperRepository;

        public ArquivoRepository(DSContext context, IDapperRepository dapperRepository) : base(context){
            _dapperRepository = dapperRepository;
        }

        public async Task<ArquivoBuscaComBlobDTO> BuscaComBlob(Guid Id)
        {
            return await Context.Arquivos.Where(a => a.Id.Equals(Id))
                .Select(a => new ArquivoBuscaComBlobDTO 
                {
                Id = a.Id,
                Nome = a.Nome,
                Titulo = a.Titulo,
                Descricao = a.Descricao,
                DataCadastro = a.DataCadastro,
                Dados = a.Dados, 
                ContentType = a.ContentType
                }).FirstOrDefaultAsync();
        }

        public async Task<ArquivoBuscaSemBlobDTO> BuscaSemBlob(Guid Id)
        {
            string sql = @"SELECT 
                            Id, 
                            Nome, 
                            Titulo, 
                            Descricao, 
                            ContentType, 
                            DataCadastro 
                            FROM Arquivo
                            WHERE Id = @IdArquivo";
            var result = await _dapperRepository.DbQueryFirstAsync<ArquivoBuscaSemBlobDTO>(sql, new { IdArquivo = Id });
            return result;
        }

        public async Task<bool> ExisteCadastro(string nome)
        {
            return await dbSet.AnyAsync(a => a.Nome.Equals(nome));
        }

        public async Task<bool> ExisteCadastro(Guid Id)
        {
            return await dbSet.AnyAsync(a => a.Id.Equals(Id));
        }

        public async Task<ArquivoListagemDTO> ListarSemBlob(int pagina)
        {
            string sql = @"SELECT 
                            COUNT(1) 
                            FROM Arquivos;";
            
            var count = await _dapperRepository.DPExecuteScalarAsync<long>(sql);
            count = (int)Math.Ceiling((double)count / 10);
            
            sql = @"SELECT 
                            Id, 
                            Nome, 
                            Titulo, 
                            Descricao, 
                            ContentType, 
                            DataCadastro 
                            FROM Arquivos as A "
                           +$"ORDER BY A.Nome OFFSET({pagina} - 1) * 10 ROWS FETCH FIRST 10 ROWS ONLY;";

            var list = await _dapperRepository.DbQueryAsync<ArquivoBuscaSemBlobDTO>(sql);

            return new ArquivoListagemDTO { Data = list.ToList(), MaxPage = count };
        }

        public async Task<ArquivoListagemDTO> Pesquisar(int pagina, string pesquisa)
        {
            DateTime data;
            string sql = string.Empty;
            long count = 0;
            IList<ArquivoBuscaSemBlobDTO> list = new List<ArquivoBuscaSemBlobDTO>();
            if(DateTime.TryParse(pesquisa, out data))
            {
                 sql = @"SELECT 
                            COUNT(1) 
                            FROM Arquivo
                            WHERE Nome LIKE @Pesquisa OR Titulo LIKE @Pesquisa OR Descricao LIKE @Pesquisa OR ContentType LIKE @Pesquisa;";

                count = await _dapperRepository.DPExecuteScalarAsync<long>(sql);
                count = (int)Math.Ceiling((double)count / 10);

                sql = @"SELECT 
                            Id, 
                            Nome, 
                            Titulo, 
                            Descricao, 
                            ContentType, 
                            DataCadastro 
                            FROM Arquivo 
                            WHERE DataCadastro = @Data"
                               + $"ORDER BY Arquivo.Nome OFFSET({pagina} - 1) * 10 ROWS FETCH FIRST 10 ROWS ONLY;";

               list = await _dapperRepository.DbQueryAsync<ArquivoBuscaSemBlobDTO>(sql, new { Data = data });

                return new ArquivoListagemDTO { Data = list.ToList(), MaxPage = count };
            }
            else
            {
                sql = @"SELECT 
                            COUNT(1) 
                            FROM Arquivo
                            WHERE Nome LIKE @Pesquisa OR Titulo LIKE @Pesquisa OR Descricao LIKE @Pesquisa OR ContentType LIKE @Pesquisa;";

                count = await _dapperRepository.DPExecuteScalarAsync<long>(sql);
                count = (int)Math.Ceiling((double)count / 10);

                sql = @"SELECT 
                            Id, 
                            Nome, 
                            Titulo, 
                            Descricao, 
                            ContentType, 
                            DataCadastro 
                            FROM Arquivo 
                            WHERE Nome LIKE @Pesquisa OR Titulo LIKE @Pesquisa OR Descricao LIKE @Pesquisa OR ContentType LIKE @Pesquisa"
                               + $"ORDER BY Arquivo.Nome OFFSET({pagina} - 1) * 10 ROWS FETCH FIRST 10 ROWS ONLY;";

                list = await _dapperRepository.DbQueryAsync<ArquivoBuscaSemBlobDTO>(sql, new { Pesquisa = $"%{pesquisa}%" });

                return new ArquivoListagemDTO { Data = list.ToList(), MaxPage = count };
            }
        }
    }
}
