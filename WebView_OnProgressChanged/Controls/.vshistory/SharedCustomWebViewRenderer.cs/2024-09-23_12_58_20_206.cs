namespace WebView_OnProgressChanged.Controls;
public class SharedCustomWebViewRenderer : WebView
{
    public SharedCustomWebViewRenderer()
    {
        ProgressChanged += onProgressChanged;
    }

    public double Progress
    {
        get => (double)GetValue(ProgressProperty);
        set => SetValue(ProgressProperty, value);
    }

    public static readonly BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress), typeof(double), typeof(SharedCustomWebViewRenderer));

    public event EventHandler<WebViewProgressChangedEventArgs> ProgressChanged;

    public void Cleanup() => ProgressChanged -= onProgressChanged;

    public void UpdateProgress(double progress) => ProgressChanged?.Invoke(this, new WebViewProgressChangedEventArgs(progress));

    private void onProgressChanged(object? sender, WebViewProgressChangedEventArgs e) => Progress = e.Progress;
}
