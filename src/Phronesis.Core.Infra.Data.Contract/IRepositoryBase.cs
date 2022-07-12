using System.Linq.Expressions;
using Phronesis.Core.Domain.Contract.Models;

namespace Phronesis.Core.Infra.Data.Contract
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
    public interface IRepositoryBase<TEntity, TId> where TEntity : ModelBase<TId> where TId : struct
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructors
        #endregion

        #region Methods

        /// <summary>
        /// Adiciona nova entidade à tabela
        /// </summary>
        /// <param name="entity">Entidade à ser adicionada</param>
        /// <returns>Primary Key</returns>
        Task<TId> AddAsync(TEntity entity);

        /// <summary>
        /// Adiciona novas entidades à tabela
        /// </summary>
        /// <param name="entity">Entidades à serem adicionadas</param>
        /// <returns>Primary Key</returns>
        Task<bool> AddRangeAsync(TEntity[] entity);

        /// <summary>
        /// Verifica se existe um registro equivalente de acordo com a regra estipulada
        /// </summary>
        /// <param name="where">Regra de verificação</param>
        /// <returns>True/False</returns>
        Task<bool> Exists(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// Restorna todas as Entidades(Registros) de acordo com a regra de negócios
        /// </summary>
        /// <param name="where">Regra de negócio</param>
        /// <param name="orderBy">Ordenação de retorno</param>
        /// <param name="includes">Entidades(Tabelas) para realizar Join</param>
        /// <returns>Lista de Entidades(Registros)</returns>
        Task<TEntity[]> GetAllAsync(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> orderBy, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Restorna todas as Entidades(Registros) de acordo com a regra de negócios
        /// </summary>
        /// <param name="where">Regra de negócio</param>
        /// <param name="orderBy">Ordenação de retorno</param>
        /// <returns>Lista de Entidades(Registros)</returns>
        public Task<TEntity[]> GetAllAsync(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> orderBy);

        /// <summary>
        /// Restorna todas as Entidades(Registros) de acordo com a regra de negócios
        /// </summary>
        /// <param name="orderBy">Ordenação de retorno</param>
        /// <returns>Lista de Entidades(Registros)</returns>
        Task<TEntity[]> GetAllAsync(Expression<Func<TEntity, object>> orderBy);

        /// <summary>
        /// Retorna Entidade(Registro) de acordo com a Primary Key da tabela
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns>Entidade(Registro)</returns>
        Task<TEntity> GetByIdAsync(TId id);

        /// <summary>
        /// Restorna a Entidade(Registro) de acordo com a regra de negócios
        /// </summary>
        /// <param name="where">Regra de negócio</param>
        /// <param name="includes">Entidade(Tabela) para realizar Join</param>
        /// <returns>Entidade(Registro)</returns>
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[]? includes);

        /// <summary>
        /// Restorna a Entidade(Registro) de acordo com a regra de negócios
        /// </summary>
        /// <param name="where">Regra de negócio</param>
        /// <returns>Entidade(Registro)</returns>
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// Exclui fisicamente um registro da tabela
        /// </summary>
        /// <param name="entity">Entidade(Registro)</param>
        /// <returns>True/False</returns>
        Task<bool> RemoveAsync(TEntity entity);

        /// <summary>
        /// Exclui fisicamente registros da tabela
        /// </summary>
        /// <param name="entity">Entidade(Registro)</param>
        /// <returns>True/False</returns>
        Task<bool> RemoveRangeAsync(TEntity[] entity);

        /// <summary>
        /// Atualiza registro na tabela
        /// </summary>
        /// <param name="entity">Entidade(Regiostro)</param>
        /// <returns>True/False</returns>
        Task<bool> UpdAsync(TEntity entity);

        /// <summary>
        /// Atualiza registros na tabela
        /// </summary>
        /// <param name="entity">Entidade(Regiostro)</param>
        /// <returns>True/False</returns>
        Task<bool> UpdRangeAsync(TEntity[] entity);

        #endregion
    }
}
