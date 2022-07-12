using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Phronesis.Core.Domain.Contract.Models;
using Phronesis.Core.Infra.CrossCutting.TypesExtension;
using Phronesis.Core.Infra.Data.Contract;

namespace Phronesis.Core.Infra.Data.Repository
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: 17/04/2022.
    /// Description..........: .
    /// Reason...............: .
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    /// <remarks></remarks>
    [Serializable]
    public class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId> where TEntity : ModelBase<TId> where TId : struct
    {
        #region Attributes

        internal readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <remarks></remarks>
        public RepositoryBase(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException($"Sem Contexto para: {nameof(context)}");
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            _dbSet = _context.Set<TEntity>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual async Task<TId> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return entity.Id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual async Task<bool> AddRangeAsync(TEntity[] entity)
        {
            await _dbSet.AddRangeAsync(entity).ConfigureAwait(false);
            return (await _context.SaveChangesAsync().ConfigureAwait(false)) > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> where) =>
            !(await GetSingleAsync(where).ConfigureAwait(false)).IsNull();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual Task<TEntity[]> GetAllAsync(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> orderBy, params Expression<Func<TEntity, object>>[]? includes)
        {
            var consulta = _dbSet.AsQueryable<TEntity>().Where(where);
            if (includes != null)
            {
                consulta = includes.Aggregate(consulta, (current, include) => current.Include(include));
            }

            return consulta.OrderBy(orderBy).ToArrayAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual Task<TEntity[]> GetAllAsync(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> orderBy) => GetAllAsync(where, orderBy, null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual Task<TEntity[]> GetAllAsync(Expression<Func<TEntity, object>> orderBy) => _dbSet.OrderBy(orderBy).ToArrayAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual Task<TEntity> GetByIdAsync(TId id) => GetSingleAsync(e => e.Id.Equals(id));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[]? includes)
        {
            var consulta = _dbSet.AsQueryable<TEntity>().Where(where);
            if (includes != null)
            {
                consulta = includes.Aggregate(consulta, (current, include) => current.Include(include));
            }

            return consulta.SingleAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where) => GetSingleAsync(where, null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual async Task<bool> RemoveAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public async Task<bool> RemoveRangeAsync(TEntity[] entity)
        {
            _dbSet.RemoveRange(entity);
            return (await _context.SaveChangesAsync().ConfigureAwait(false)) > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public async Task<bool> UpdAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public async Task<bool> UpdRangeAsync(TEntity[] entity)
        {
            _dbSet.UpdateRange(entity);
            return (await _context.SaveChangesAsync().ConfigureAwait(false)) > 0;
        }

        #endregion
    }
}
