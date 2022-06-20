using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phronesis.Core.Domain.Contract.Models;

namespace Phronesis.Core.Infra.Data.Mapping
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: 10/04/2022.
    /// Description..........: Configuração de banco de dados para a entidade ModelBase.
    /// Reason...............: .
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    /// <remarks></remarks>
    [Serializable]
    public class EntityMapBase<TEntity, TId> : IEntityTypeConfiguration<TEntity> where TEntity : ModelBase<TId> where TId : struct
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructors
        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <remarks></remarks>
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.CriadoEm)
                .HasColumnName("dh_inclusao")
                .HasDefaultValueSql("getdate()")
                .IsRequired(true);

            builder.Property(x => x.AtualizadoEm)
                .HasColumnName("dh_alteracao");
        }

        #endregion
    }
}
