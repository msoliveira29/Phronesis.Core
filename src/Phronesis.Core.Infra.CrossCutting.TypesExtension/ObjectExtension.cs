namespace Phronesis.Core.Infra.CrossCutting.TypesExtension
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: 17/04/2022.
    /// Description..........: .
    /// Reason...............: .
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public static class ObjectExtension
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructors
        #endregion

        #region Methods

        /// <summary>
        /// Valida se o objeto é nulo e dispara ArgumentNullException caso positivo
        /// </summary>
        /// <param name="o"></param>
        /// <param name="objName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static object ThrowIfNull(this object o, string? objName = null) =>
            o ?? throw new ArgumentNullException(objName ?? nameof(o));

        /// <summary>
        /// Valida se o objeto é nulo
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool IsNull(this object o) =>
            o == null;

        #endregion
    }
}
