using System.ComponentModel.DataAnnotations.Schema;

namespace Phronesis.Core.Domain.Contract.Models
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: 08/04/2022.
    /// Description..........: Entidade ModelBase.
    /// Reason...............: .
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    /// <remarks></remarks>
    [Serializable]
    public abstract class ModelBase<TId> where TId : struct
    {
        #region Attributes

        private DateTime? _criadoEm;

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TId Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        public DateTime? CriadoEm
        {
            get { return _criadoEm; }
            set { _criadoEm = (value == null ? DateTime.UtcNow : value); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        public DateTime? AtualizadoEm { get; set; }

        #endregion

        #region Constructors
        #endregion

        #region Methods
        #endregion
    }
}
