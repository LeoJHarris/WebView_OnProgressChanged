using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebView_OnProgressChanged;
public class WebViewProgressChangedEventArgs(double progressPercentage) : System.EventArgs
{
    public double Progress { get; } = progressPercentage;
}