using System;
using System.IO;
using System.Reflection;
using System.Windows;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;

namespace WebViewTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // html 위치를 찾아 등록하는 것으로, 경로가 이미 있다면 Skip
            var executionPath = Assembly.GetExecutingAssembly().Location.AsSpan();
            var solutionPath = Path.GetDirectoryName(executionPath);
            var sampleHtmlPath = Path.Combine(solutionPath.ToString(), "Sample.html");
            WebView2.Source = new Uri(sampleHtmlPath);

            // WebView가 Navigation이 끝낼 때의 작업 등록
            WebView2.NavigationCompleted += WhenNavigationCompleted;
        }

        private void WhenNavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (!(sender is WebView2 webView2 && e.IsSuccess))
                return;

            try
            {
                //
                var hostObj = new HtmlInterop();
                webView2.CoreWebView2.AddHostObjectToScript("hostObj", hostObj);
            }
            catch
            {
                // ignored
            }
        }
    }
}
