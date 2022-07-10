using Phronesis.Core.Infra.CrossCutting.TypesExtension;
using Phronesis.Core.Domain.Contract.Enums;

namespace Phronesis.Core.Domain.ValueObject
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: 19/04/2022.
    /// Description..........: .
    /// Reason...............: .
    /// </summary>
    /// <remarks></remarks>
    public class Result
    {
        #region Attributes

        private ICollection<string> msgs;

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        public virtual ICollection<string> Msgs
        {
            get
            {
                if (ErrorMessages?.Any() ?? false)
                {
                    if (msgs?.Any() ?? false)
                    {
                        ErrorMessages.ForEach(em => msgs.Add($"{em.PropertyName}:{em.Message}"));
                    }
                    else
                    {
                        msgs = new List<string>(ErrorMessages.Select(em =>
                            em.PropertyName.IsNullOrEmpty() ? em.Message : ($"{em.PropertyName}:{em.Message}")));
                    }
                }

                return msgs;
            }

            set { msgs = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        public virtual ICollection<ErrorMessage> ErrorMessages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        public TipoResultEnum TipoResult { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        public bool HasMsg => (Msgs?.Any() ?? false);

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        protected Result()
        {
            TipoResult = TipoResultEnum.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoResult"></param>
        /// <remarks></remarks>
        protected Result(TipoResultEnum tipoResult = TipoResultEnum.Success)
        {
            TipoResult = tipoResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <param name="tipoResult"></param>
        /// <remarks></remarks>
        protected Result(IEnumerable<string> errorMsg, TipoResultEnum tipoResult = TipoResultEnum.Success)
            : this(errorMsg?.Select(e => new ErrorMessage(e)), tipoResult)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <param name="tipoResult"></param>
        /// <remarks></remarks>
        protected Result(IEnumerable<ErrorMessage> errorMsg, TipoResultEnum tipoResult = TipoResultEnum.Success)
            : this(tipoResult) =>
            ErrorMessages = errorMsg?.ToArray();

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Result<bool> Success()
        {
            return Success(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Result<bool> Success(string msg)
        {
            return Success(true, msg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Result<TResult> Success<TResult>(TResult result)
        {
            return Success(result, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="result"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Result<TResult> Success<TResult>(TResult result, string? msg)
        {
            return new Result<TResult>(result, msg.IsNullOrEmpty() ? null : new ErrorMessage[1] { new ErrorMessage(msg) });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Result<bool> Failed(string error)
        {
            return Failed<bool>(new string[1] { error });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msgs"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Result<bool> Failed(IEnumerable<string> msgs)
        {
            return Failed<bool>(msgs.Select(msg => new ErrorMessage(msg)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMessages"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Result<bool> Failed(IEnumerable<ErrorMessage> errorMessages)
        {
            return Failed<bool>(errorMessages);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="error"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Result<TResult> Failed<TResult>(string error)
        {
            return Failed<TResult>(new string[1] { error });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="msgs"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Result<TResult> Failed<TResult>(IEnumerable<string> msgs)
        {
            return Failed<TResult>(msgs.Select(msg => new ErrorMessage(msg)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="errorMessages"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Result<TResult> Failed<TResult>(IEnumerable<ErrorMessage> errorMessages)
        {
            return Failed<TResult>(default, errorMessages);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="result"></param>
        /// <param name="errorMessages"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Result<TResult> Failed<TResult>(TResult result, IEnumerable<ErrorMessage> errorMessages)
        {
            return new Result<TResult>(result, errorMessages, TipoResultEnum.Failed);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Result<bool> NotFound()
        {
            return NotFound(string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Result<bool> NotFound(string msg)
        {
            return NotFound<bool>(msg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Result<TResult> NotFound<TResult>(string? msg = null)
        {
            return new Result<TResult>(default, msg, TipoResultEnum.NotFound);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Result<TResult> Created<TResult>(TResult result)
        {
            return Created(result, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="result"></param>
        /// <param name="msgs"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Result<TResult> Created<TResult>(TResult result, IEnumerable<string>? msgs = null)
        {
            return new Result<TResult>(result, msgs?.Select(msg => new ErrorMessage(msg)), TipoResultEnum.Created);
        }

        #endregion
    }

    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: 19/04/2022.
    /// Description..........: .
    /// Reason...............: .
    /// </summary>
    /// <remarks></remarks>
    public class Result<TValue> : Result
    {
        #region Attributes
        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        public TValue Value { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="msg"></param>
        /// <param name="tipoResult"></param>
        /// <remarks></remarks>
        public Result(TValue value, string msg, TipoResultEnum tipoResult = TipoResultEnum.Success)
            : this(value, msg.IsNullOrEmpty() ? null : new string[1] { msg }, tipoResult)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="msgs"></param>
        /// <param name="tipoResult"></param>
        /// <remarks></remarks>
        public Result(TValue value, IEnumerable<string> msgs, TipoResultEnum tipoResult = TipoResultEnum.Success)
            : this(value, msgs?.Select(msg => new ErrorMessage(msg)), tipoResult)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMessages"></param>
        /// <param name="tipoResult"></param>
        /// <remarks></remarks>
        public Result(TValue value, IEnumerable<ErrorMessage> errorMessages, TipoResultEnum tipoResult = TipoResultEnum.Success)
            : base(errorMessages, tipoResult)
        {
            Value = value;
        }

        #endregion

        #region Methods
        #endregion
    }
}
