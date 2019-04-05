using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web;
using Windows.Web.Http;

namespace 韩剧TV.Tools
{
    public class WebViewHelper
    {
        public class WebLoadedArgs : EventArgs
        {
            public bool Success { get; private set; }
            public WebErrorStatus WebErrorStatus { get; private set; }
            public string Html { get; private set; }

            public WebLoadedArgs(WebErrorStatus webErrorStatus)
            {
                WebErrorStatus = webErrorStatus;
                Success = false;
            }

            public WebLoadedArgs(string Html, WebErrorStatus webErrorStatus)
            {
                this.Html = Html;
                WebErrorStatus = webErrorStatus;
                Success = true;
            }
        }

        public string Url { get; private set; }
        public event EventHandler<WebLoadedArgs> WebLoaded;
        private WebView webView;

        public WebViewHelper(string Url)
        {
            this.Url = Url;
            webView = new WebView(WebViewExecutionMode.SeparateThread);
            webView.Navigate(new Uri(Url));
            webView.NavigationCompleted += WebView_NavigationCompleted;
            webView.NavigationFailed += WebView_NavigationFailed;
        }

        private void WebView_NavigationFailed(object sender, WebViewNavigationFailedEventArgs e)
        {
            WebLoaded(this, new WebLoadedArgs(e.WebErrorStatus));
        }

        private async void WebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {

            var html = await sender.InvokeScriptAsync("eval", new string[] { "document.documentElement.outerHTML;" });
            webView = null;
            WebLoaded(this, new WebLoadedArgs(html, args.WebErrorStatus));
        }

        /// <summary>
        /// 异步实现获取Web内容
        /// </summary>
        /// <param name="Url">网址</param>
        /// <param name="TimeOut">超时时间</param>
        /// <returns>Web的Html内容</returns>
        public static Task<string> LoadWebAsync(string Url, int Timeout)
        {
            return LoadWebAsync(Url, "", Timeout);
        }


        /// <summary>
        /// 异步实现获取Web内容
        /// </summary>
        /// <param name="Url">网址</param>
        /// <param name="Referer">Header[Referer]，用以解决一些盗链效验</param>
        /// <param name="TimeOut">超时时间</param>
        /// <returns>Web的Html内容</returns>
        public static Task<string> LoadWebAsync(string Url, string Referer, int TimeOut)
        {

            WebView webView = new WebView(WebViewExecutionMode.SeparateThread);
            Uri uri = new Uri(Url);
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            requestMessage.Headers.Add("Referer", Referer);
            webView.NavigateWithHttpRequestMessage(requestMessage);

            TaskCompletionSource<string> completionSource = new TaskCompletionSource<string>();
            webView.NavigationCompleted += async (sender, args) =>
            {
                if (args.Uri != uri)
                    return;
                await Task.Delay(200);
                var html = await sender.InvokeScriptAsync("eval", new string[] { "document.documentElement.outerHTML;" });
                webView.NavigateToString("");
                webView = null;
                completionSource.SetResult(html);
            };
            webView.NavigationFailed += (sender, args) =>
            {
                webView = null;
                completionSource.SetException(new WebException("", (WebExceptionStatus)args.WebErrorStatus));
            };
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(TimeOut);
            timer.Tick += (sender, args) =>
            {
                timer = null;
                webView.NavigateToString("");
                webView = null;
                completionSource.SetException(new TimeoutException());
            };
            timer.Start();

            return completionSource.Task;
        }
    }
}
