using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebView_OnProgressChanged.Controls;

namespace WebView_OnProgressChanged.Platforms.Android;
public class CustomWebViewHandler : WebViewHandler
{
    private CustomWebViewRenderer? Element => VirtualView as WebView_OnProgressChanged.Controls.CustomWebViewRenderer;

    protected override void ConnectHandler(Android.Webkit.WebView platformView)
    {
        base.ConnectHandler(platformView);

        if (Element is not null) { platformView.SetWebChromeClient(new CustomWebChromeClient(Element)); }

        platformView.Settings.JavaScriptEnabled = true;
    }

    private class CustomWebChromeClient(CustomWebView customWebView) : WebChromeClient
    {
        public override void OnProgressChanged(Android.Webkit.WebView? view, int newProgress) => customWebView.UpdateProgress(Math.Round((double)newProgress / 100, 2));
    }
}