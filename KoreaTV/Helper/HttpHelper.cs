using KoreaTV.AppClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KoreaTV.Helper {
    public static class HttpHelper {
        public static async Task<string> HttpGet(string url, Dictionary<string, string> headerData=null) {
            try {
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                HttpClient httpClient = new HttpClient(handler);
                var message = new HttpRequestMessage(HttpMethod.Get, url);
                message.Headers.Add("vn", AppConfig.AndroidAppVersion);
                message.Headers.Add("vc", AppConfig.AndroidAppVC);
                message.Headers.Add("uk",AppConfig.AndroidAppUK);
                message.Headers.Add("User-Agent", AppConfig.AndroidUserAgent);
                message.Headers.Add("sign", AppConfig.AndroidSign);

                if (headerData != null) {
                    foreach (var item in headerData) {
                        message.Headers.Add(item.Key, item.Value);
                    }
                }
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding encodingUTF = Encoding.GetEncoding("utf-8");
                var response = await httpClient.SendAsync(message);
                Stream StreamToReader = await response.Content.ReadAsStreamAsync();
                StreamReader sr = new StreamReader(StreamToReader, encodingUTF);
                string resdata = await sr.ReadToEndAsync();
                return resdata;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public static async Task<string> HttpPost(string url, List<KeyValuePair<string, string>> postData) {
            try {
                string responseBody = "";
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                HttpClient httpClient = new HttpClient(handler);
                HttpResponseMessage response = await httpClient.PostAsync(url, new FormUrlEncodedContent(postData));
                if (response.EnsureSuccessStatusCode().StatusCode.ToString().ToLower() == "ok") {
                    responseBody = await response.Content.ReadAsStringAsync();
                }
                return responseBody;
            }
            catch {
                return null;
            }
        }
    }
}
