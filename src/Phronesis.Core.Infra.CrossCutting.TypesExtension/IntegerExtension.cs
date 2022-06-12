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
    public static class IntegerExtension
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructors
        #endregion

        #region Methods

        /// <summary>
        /// Soma os itens do Array
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Sum(this int[] o)
        {
            var result = 0;
            o.ForEach(n => result += n);
            return result;
        }

        /// <summary>
        /// Convert string para int
        /// </summary>
        /// <param name="s"></param>
        /// <param name="padrao"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int ToInt(this string s, int padrao = 0)
        {
            return s.IsNullOrEmpty() ? padrao : (int.TryParse(s, out int result) ? result : padrao);
        }

        #endregion
    }
}
