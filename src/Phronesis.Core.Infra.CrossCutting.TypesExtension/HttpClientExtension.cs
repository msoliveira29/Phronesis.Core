using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

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
    public static class HttpClientExtension
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
        /// <param name="httpClient"></param>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Task<HttpResponseMessage> PostJsonAsync(this HttpClient httpClient, string url, object body)
        {
            var bodyJson = JsonSerializer.Serialize(body);

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(bodyJson, Encoding.UTF8, "application/json");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return httpClient.SendAsync(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="url"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Task<HttpResponseMessage> GetJsonAsync(this HttpClient httpClient, string url, Dictionary<string, string> properties = null)
        {
            string qryStr = (properties?.Any() ?? false) ? string.Join("&", properties.Select(p => $"{p.Key}={p.Value}")) : string.Empty;

            var request = new HttpRequestMessage(HttpMethod.Get, (url + (qryStr.IsNullOrEmpty() ? qryStr : $"?{qryStr}")));
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient.SendAsync(request);
        }

        #endregion
    }
}
