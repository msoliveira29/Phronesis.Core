namespace Phronesis.Core.Domain.ValueObject
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: 19/04/2022.
    /// Description..........: .
    /// Reason...............: .
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public class ErrorMessage
    {
        #region Attributes
        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        public string? Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        public string? PropertyName { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <remarks></remarks>
        public ErrorMessage(string? message)
        {
            Message = message;
        }

        #endregion

        #region Methods
        #endregion
    }
}
