using Microsoft.Maui.Handlers;
using WebView_OnProgressChanged.Controls;

namespace WebView_OnProgressChanged.Platforms.Android;
public class CustomWebViewHandler : WebViewHandler
{
    private SharedCustomWebViewRenderer? Element => VirtualView as SharedCustomWebViewRenderer;

    protected override void ConnectHandler(Android.Webkit.WebView platformView)
    {
        base.ConnectHandler(platformView);

        if (Element is not null) { platformView.SetWebChromeClient(new CustomWebChromeClient(Element)); }

        platformView.Settings.JavaScriptEnabled = true;
    }

    private class CustomWebChromeClient(SharedCustomWebViewHandler sharedCustomWebView) : WebChromeClient
    {
        public override void OnProgressChanged(Android.Webkit.WebView? view, int newProgress) => sharedCustomWebView.UpdateProgress(Math.Round((double)newProgress / 100, 2));
    }
}