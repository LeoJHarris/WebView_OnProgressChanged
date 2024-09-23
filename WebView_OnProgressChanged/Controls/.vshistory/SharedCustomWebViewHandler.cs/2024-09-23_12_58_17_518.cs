namespace WebView_OnProgressChanged.Controls;
public class SharedCustomWebViewHandler : WebView
{
    public SharedCustomWebViewHandler()
    {
        ProgressChanged += onProgressChanged;
    }

    public double Progress
    {
        get => (double)GetValue(ProgressProperty);
        set => SetValue(ProgressProperty, value);
    }

    public static readonly BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress), typeof(double), typeof(SharedCustomWebViewHandler));

    public event EventHandler<WebViewProgressChangedEventArgs> ProgressChanged;

    public void Cleanup() => ProgressChanged -= onProgressChanged;

    public void UpdateProgress(double progress) => ProgressChanged?.Invoke(this, new WebViewProgressChangedEventArgs(progress));

    private void onProgressChanged(object? sender, WebViewProgressChangedEventArgs e) => Progress = e.Progress;
}
