using DS.Business.Entities;
using DS.Business.Interface.Repository;
using DS.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DS.Data.Repository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly DSContext Context;
        protected readonly DbSet<TEntity> dbSet;

        public GenericRepository(DSContext context)
        {
            Context = context;
            dbSet = Context.Set<TEntity>();
        }


        public async Task<TEntity> Adicionar(TEntity entity)
        {
            dbSet.Add(entity);
            await SaveChanges();
            return await dbSet.FindAsync(entity.Id);
        }

        public async Task<TEntity> Atualizar(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return await dbSet.FindAsync(entity.Id);
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await dbSet.AsNoTracking().Where(f => f.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task Remover(Guid id)
        {
            var entity = await dbSet.FindAsync(id);
            dbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
