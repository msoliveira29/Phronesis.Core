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
    public static class IEnumerableExtension
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
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <param name="action"></param>
        /// <remarks></remarks>
        public static void ForEach<T>(this IEnumerable<T> e, Action<T> action)
        {
            Array.ForEach(e.ToArray(), action);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <param name="o"></param>
        /// <remarks></remarks>
        public static void Add<T>(this IEnumerable<T> e, T o)
        {
            _ = e.Append(o);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <param name="e1"></param>
        /// <remarks></remarks>
        public static void AddRange<T>(this IEnumerable<T> e, IEnumerable<T> e1)
        {
            var result = new List<T>((e?.Count() ?? 0) + (e1?.Count() ?? 0));
            if (e?.Any() ?? false)
            {
                result.AddRange(e);
            }

            if (e1?.Any() ?? false)
            {
                result.AddRange(e1);
            }
        }

        #endregion
    }
}
