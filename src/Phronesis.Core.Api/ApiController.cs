using Microsoft.AspNetCore.Mvc;
using Phronesis.Core.Domain.ValueObject;
using Phronesis.Core.Domain.Contract.Enums;

namespace Phronesis.Core.Api
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: 20/04/2022.
    /// Description..........: Controller base para API com tratamenro de retorno para conceito de API RESTFull.
    /// Reason...............: .
    /// </summary>
    /// <remarks></remarks>
    public abstract class ApiController : ControllerBase
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructors
        #endregion

        #region Methods

        /// <summary>
        /// Tratamento de retorno padrão.
        /// </summary>
        /// <typeparam name="TValue">Tipo do valor de retorno.</typeparam>
        /// <param name="result">Resultado do domínio.</param>
        /// <returns>Resultado da requisição HTTP.</returns>
        /// <remarks></remarks>
        protected new IActionResult Response<TValue>(Result<TValue> result)
        {
            var retorno = (result != null)
                ? new { msg = result.Msgs?.ToArray(), data = result.Value }
                : null;

            switch (result.TipoResult)
            {
                case TipoResultEnum.Success:
                    if (retorno != null) return Ok(retorno);
                    return Ok();
                case TipoResultEnum.Created:
                    if (retorno != null) return StatusCode(201, retorno);
                    return StatusCode(201);
                case TipoResultEnum.NotFound:
                    if (retorno?.msg?.Any() ?? false) return NotFound(retorno);
                    return NotFound();
                case TipoResultEnum.Failed:
                default:
                    return BadRequest(retorno);
            }
        }

        #endregion
    }
}
