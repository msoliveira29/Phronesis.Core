using FluentValidation.Results;
using Phronesis.Core.Domain.ValueObject;

namespace Phronesis.Core.Domain.Message
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: 19/04/2022.
    /// Description..........: .
    /// Reason...............: .
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public abstract class Command
    {
        #region Attributes

        private ValidationResult? _validationResult;

        public abstract bool IsValid();

        #endregion

        #region Properties
        #endregion

        #region Constructors
        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validationResult"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected bool Validate(ValidationResult validationResult)
        {
            _validationResult = validationResult;
            return validationResult.IsValid;
        }

        // Exemplo implementação com DataAnnotation
        //public static IEnumerable<ValidationResult> getValidationErros(object obj)
        //{
        //    var resultadoValidacao = new List<ValidationResult>();
        //    var contexto = new ValidationContext(obj, null, null);
        //    Validator.TryValidateObject(obj, contexto, resultadoValidacao, true);
        //    return resultadoValidacao;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        public IEnumerable<ErrorMessage>? Errors => _validationResult?.Errors?.Select(e =>
            new ErrorMessage(e.ErrorMessage) { PropertyName = e.PropertyName });

        #endregion
    }

    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: 19/04/2022.
    /// Description..........: .
    /// Reason...............: .
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public abstract class Command<TEntity>
        : Command
    {
        #region Attributes
        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        public TEntity Entity { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <remarks></remarks>
        protected Command(TEntity entity)
        {
            Entity = (entity != null)
                ? entity
                : throw new ArgumentNullException(nameof(entity));
        }

        #endregion

        #region Methods
        #endregion
    }
}
