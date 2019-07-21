using System.Net;
using System.Net.Http;
using System.Text;
using HttpClient = System.Net.Http.HttpClient;

namespace Se7en.Network {
    public class WebClient : Net {
        private static CookieContainer CookieContainer { get; set; }
        public static string SendRequest(string url,
                                   WebRequestType method = WebRequestType.GET,
                                   string parameter = "",
                                   (string key, string value)[] requestHeaderOption = null,
                                   string contentType = "application/json"
        ) {
            using HttpClientHandler clientHandler = new HttpClientHandler() {
                CookieContainer = CookieContainer,
                ClientCertificateOptions = ClientCertificateOption.Automatic
            };
            using (HttpClient client = new HttpClient(clientHandler)) {

                if (requestHeaderOption != null)
                    foreach ((string key, string value) in requestHeaderOption)
                        client.DefaultRequestHeaders.Add(key, value);

                HttpMethod methodType = method switch
                {
                    WebRequestType.GET => HttpMethod.Get,
                    WebRequestType.POST => HttpMethod.Post,
                    WebRequestType.PUT => HttpMethod.Put,
                    WebRequestType.DELETE => HttpMethod.Delete,
                    WebRequestType.HEAD => HttpMethod.Head,
                    _ => throw new System.Exception()
                };

                HttpRequestMessage request = new HttpRequestMessage(methodType, url) {
                    Content = new StringContent(parameter, Encoding.UTF8, contentType)
                };

                try {
                    return client.SendAsync(request).Result.Content.ReadAsStringAsync().Result;
                } catch {
                    return string.Empty;
                }
            }
        }
    }
}