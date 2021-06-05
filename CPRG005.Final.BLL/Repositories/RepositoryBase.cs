using CPRG005.Final.Data;
using CPRG005.Final.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG005.Final.BLL.Repositories
{
    public interface IRepositoryBase<T> where T : Entity
    {
        Task<string> Create(T entity);
        Task<int> Delete(int id);
        Task<string> Edit(int? id, T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(int? id);
    }

    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        private readonly MarinaDbContext context;
        private readonly ILogger logger;
        public RepositoryBase(MarinaDbContext context, ILogger<T> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public virtual async Task<List<T>> GetAll()
        {
            try
            {
                return await context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogDebug($"Error in GetAll. T: {typeof(T)} Error: {ex.Message}");
                return null;
            }
        }
        public virtual async Task<T> GetById(int? id)
        {
            try
            {
                if (id == null)
                    return null;

                var entity = await context.Set<T>()
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (entity == null)
                    return null;

                return entity;
            }
            catch (Exception ex)
            {
                logger.LogDebug($"Error in GetById({id}). T: {typeof(T)} Error: {ex.Message}");
                return null;
            }

        }
        public virtual async Task<string> Create(T entity)
        {
            try
            {
                context.Add(entity);
                var entityId = await context.SaveChangesAsync();
                return entity.Id.ToString();
            }
            catch (Exception ex)
            {
                logger.LogDebug($"Error in Create. T: {typeof(T)} Error: {ex.Message}");
                return null;
            }

        }
        public virtual async Task<string> Edit(int? id, T entity)
        {
            try
            {
                if (id != entity.Id || id == 0 )
                    return null;

                try
                {
                    context.Update(entity);
                    var entityId = await context.SaveChangesAsync();
                    return "Success";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityExists(entity.Id))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogDebug($"Error in Edit({id}). T: {typeof(T)} Error: {ex.Message}");
                return null;
            }

        }
        public virtual async Task<int> Delete(int id)
        {
            try
            {
                var entity = await context.Set<T>().FindAsync(id);
                context.Set<T>().Remove(entity);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogDebug($"Error in Delete({id}). T: {typeof(T)} Error: {ex.Message}");
                return -1;
            }
        }
        private bool EntityExists(int id)
        {
            return context.Set<T>().Any(e => e.Id == id);
        }
    }
}
