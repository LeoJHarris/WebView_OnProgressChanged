namespace WebView_OnProgressChanged;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        webViewHandler.Source = "https://www.google.com";
        webViewRenderer.Source = "https://www.google.com";
    }
}

