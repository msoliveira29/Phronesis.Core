namespace Phronesis.Core.Application.Contract.ViewModels
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: 21/04/2022.
    /// Description..........: Entidade ViewBase.
    /// Reason...............: .
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    /// <remarks></remarks>
    public abstract class ViewModelBase<TId> where TId : struct
    {
        #region Attributes
        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        public TId Id { get; set; }

        #endregion

        #region Constructors
        #endregion

        #region Methods
        #endregion
    }
}
