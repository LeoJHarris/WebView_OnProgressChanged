using Android.Content;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using WebView_OnProgressChanged.Controls;
using WebView_OnProgressChanged.Platforms.Droid;


[assembly: ExportRenderer(typeof(SharedCustomWebViewRenderer), typeof(CustomWebViewHandler))]
namespace WebView_OnProgressChanged.Platforms.Droid;
public class CustomWebViewRenderer(Context context) : WebViewRenderer(context)
{
    /// <summary>
    /// The OnElementChanged.
    /// </summary>
    /// <param name="e">The e <see cref="ElementChangedEventArgs{WebView}"/>.</param>
    protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
    {
        base.OnElementChanged(e);

        if (Control == null)
        {
            return;
        }

        if (e.NewElement is CustomWebView customWebView)
        {
            Control.SetWebChromeClient(new CustomWebChromeClient(customWebView));
        }

        Control.Settings.JavaScriptEnabled = true;
    }

    private class CustomWebChromeClient(CustomWebView customWebView) : WebChromeClient
    {
        private readonly CustomWebView _customWebView = customWebView;

        public override void OnProgressChanged(Android.Webkit.WebView view, int newProgress) => _customWebView.UpdateProgress(System.Math.Round((double)newProgress / 100, 2));
    }
}
