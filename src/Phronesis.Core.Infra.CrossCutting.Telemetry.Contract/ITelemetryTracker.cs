using Phronesis.Core.Domain.ValueObject;

namespace Phronesis.Core.Infra.CrossCutting.Telemetry.Contract
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: 17/04/2022.
    /// Description..........: .
    /// Reason...............: .
    /// </summary>
    /// <remarks></remarks>
    public interface ITelemetryTracker
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
        /// <param name="exception"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        Task TrackException(Exception exception);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        Task TrackException(Exception exception, Dictionary<string, string> details);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        Task TrackMessage(string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        Task TrackMessage(string message, Dictionary<string, string> details);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        Task TrackMessage(string message, IEnumerable<ErrorMessage> errors);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        Task TrackWarning(string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        Task TrackWarning(string message, Dictionary<string, string> details);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        Task TrackWarning(string message, IEnumerable<ErrorMessage> errors);

        #endregion
    }
}
