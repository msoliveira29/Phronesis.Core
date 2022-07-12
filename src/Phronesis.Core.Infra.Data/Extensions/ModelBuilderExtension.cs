using Microsoft.EntityFrameworkCore;

namespace Phronesis.Core.Infra.Data.Extensions
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: 21/04/2022.
    /// Description..........: Extensão do ModelBuilder.
    /// Reason...............: .
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public static class ModelBuilderExtensions
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructors
        #endregion

        #region Methods

        /// <summary>
        /// Seta deleção em cascata.
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <remarks>Por padrão não executa a deleção em cascata</remarks>
        public static ModelBuilder SetCascadeDelete(this ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            return modelBuilder;
        }

        /// <summary>
        /// Seta o nome das tabelas.
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <remarks>Utiliza como prefixo a palavra 'tb_'</remarks>
        public static ModelBuilder SetDefaultTableName(this ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model
                .GetEntityTypes())
            {
                property.SetTableName("tb_" + property.GetTableName().ToLower());
            }

            return modelBuilder;
        }

        /// <summary>
        /// Seta um tamanho padrão para as propriedades do tipo string.
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <remarks></remarks>
        public static ModelBuilder UseDefaultStringLength(this ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string) && p.GetMaxLength() == null))
            {
                property.SetMaxLength(2048);
            }

            return modelBuilder;
        }

        /// <summary>
        /// Seta o tipo de dado varchar como padrão para as propriedades do tipo string.
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <remarks></remarks>
        public static ModelBuilder UseVarchar(this ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string)))
            {
                if (property.GetColumnType() == null)
                {
                    property.SetColumnType("varchar");
                }
            }

            return modelBuilder;
        }

        /// <summary>
        /// Seta o tipo de dado datetime como padrão para as propriedades do tipo datetime.
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <remarks></remarks>
        public static ModelBuilder UseDateTime(this ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?)))
            {
                if (property.GetColumnType() == null)
                    property.SetColumnType("datetime");
            }

            return modelBuilder;
        }

        /// <summary>
        /// Seta o tipo de dado decimal(13,2) como padrão para as propriedades do tipo decimal.
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <remarks></remarks>
        public static ModelBuilder UseDecimal(this ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                if (property.GetColumnType() == null)
                    property.SetColumnType("decimal(13,2)");
            }

            return modelBuilder;
        }

        #endregion
    }
}
