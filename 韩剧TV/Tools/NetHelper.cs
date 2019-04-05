using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.WebUI;
using Windows.UI.Xaml.Controls;
using 韩剧TV.Model;

namespace 韩剧TV.Tools
{
    public class NetHelper
    {
        /// <summary>
        /// http请求数据
        /// </summary>
        /// <param name="url">传入网页参数</param>
        /// <returns>字符串数据</returns>
        public async Task<string> RequestStr(string url,Dictionary<string,string> headerDic)
        {
            try
            {
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                HttpClient httpClient = new HttpClient(handler);
                var message = new HttpRequestMessage(HttpMethod.Get, url);
                message.Headers.Add("vc", "a_4280");
                message.Headers.Add("uk", " PqoGbccO1eAZHf6M8D/Wd5WVdMHG/9QZ+F1S1c+9r5E=");
                message.Headers.Add("User-Agent", " HanjuTV/4.2.8 (MEIZU Zero; Android 7.0; Scale/2.00)");
                if (headerDic!=null)
                {
                    foreach (var item in headerDic)
                    {
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> RequestUrl(string url)
        {
            try
            {
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                HttpClient httpClient = new HttpClient(handler);
                var message = new HttpRequestMessage(HttpMethod.Get, url);
               
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding encodingUTF = Encoding.GetEncoding("utf-8");
                var response = await httpClient.SendAsync(message);
                Stream StreamToReader = await response.Content.ReadAsStreamAsync();
                StreamReader sr = new StreamReader(StreamToReader, encodingUTF);
                string resdata = await sr.ReadToEndAsync();
                return resdata;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> RequestStrWithParams(string url, List<KeyValuePair<string, string>> data)
        {
            try
            {
                string responseBody = "";
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                HttpClient httpClient = new HttpClient(handler);
                //var message = new HttpRequestMessage(HttpMethod.Post, url);
                //message.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                //message.Headers.Add("Upgrade-Insecure-Requests", "1");
                //message.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                //message.Headers.Add("Content-Length", "89");
                HttpResponseMessage response = await httpClient.PostAsync(url, new FormUrlEncodedContent(data));
                if (response.EnsureSuccessStatusCode().StatusCode.ToString().ToLower() == "ok")
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                }
                return responseBody;
            }
            catch
            {
                return "0";
            }
        }
      
        /// <summary>
        /// 创建JsonSerializer对象
        /// </summary>
        JsonSerializer jsonSerializer = JsonSerializer.Create();
        /// <summary>
        /// 格式话Json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public T GetView<T>(string json)
        {
            return jsonSerializer.Deserialize<T>(new JsonTextReader(new StringReader(json)));
        }

        public async static Task<string> GetStringByJs(string html,string js)
        {
            WebView webView = new WebView();
            webView.NavigateToString(html);
            await Task.Delay(200);
            string url = await webView.InvokeScriptAsync("eval", new[] { js });
            webView.NavigateToString("");
            return url;
        }
    }
}
