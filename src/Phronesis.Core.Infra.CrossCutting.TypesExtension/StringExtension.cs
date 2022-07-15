using System.Globalization;
using System.Text;

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
    public static class StringExtension
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructors
        #endregion

        #region Methods

        /// <summary>
        /// Valida se a string é vazia ou nula
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool IsNullOrEmpty(this string s)
        {
            return GetStringOrNull(s).IsNull();
        }

        /// <summary>
        /// Retorna a string ou null
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string? GetStringOrNull(this string? s)
        {
            s = s?.Trim();
            return !string.IsNullOrEmpty(s)
                ? (string.IsNullOrWhiteSpace(s) ? null : s)
                : null;
        }

        /// <summary>
        /// Retorna a string ou vazio
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string? GetStringOrEmpty(this string? s) =>
            GetStringOrNull(s) ?? string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="paramName"></param>
        /// <param name="msgError"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <remarks></remarks>
        public static string ThrowIfNullOrEmpty(this string s, string? paramName = null, string? msgError = null)
        {
            return s.GetStringOrNull() ?? throw new ArgumentNullException(paramName.GetStringOrNull() ?? nameof(s), msgError.GetStringOrEmpty());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string ThrowIfNullOrEmpty(this string s, string paramName) =>
            ThrowIfNullOrEmpty(s, paramName, null);

        /// <summary>
        /// Convert para double
        /// </summary>
        /// <param name="s">string que será convertida</param>
        /// <param name="def">valor default caso a string esteja vazia, nula ou não consiga converter</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static double ToDoubleOrDefault(this string s, double def) =>
            (s.IsNullOrEmpty())
                ? def
                : (double.TryParse(s, out double result) ? result : def);

        /// <summary>
        /// Retorna apenas números
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string OnlyNumbers(this string s) =>
            string.Join(string.Empty, s.Replace(" ", string.Empty).ToCharArray().Where(Char.IsDigit));

        /// <summary>
        /// Remove acentos do texto
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string RemoveAcento(this string s)
        {
            StringBuilder sbReturn = new StringBuilder();

            var arrayText = s.Normalize(NormalizationForm.FormD).ToCharArray();

            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }

            return sbReturn.ToString();
        }

        #endregion
    }
}
