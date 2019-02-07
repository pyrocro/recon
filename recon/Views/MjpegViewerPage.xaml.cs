using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace recon.Views
{
    public partial class MjpegViewerPage : ContentPage
    {
        public MjpegViewerPage()
        {
            InitializeComponent();

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(recon.Views.AboutPage)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("recon.Views.MjpegViewerWeb.html");
            StreamReader reader = new StreamReader(stream);
            String _htmlString = reader.ReadToEnd();

            HtmlWebViewSource html = new HtmlWebViewSource();
            html.Html = _htmlString;
            mjpegViewer.Source = html;
            mjpegViewer.HorizontalOptions = LayoutOptions.Fill;
            mjpegViewer.VerticalOptions = LayoutOptions.Fill;

            /*mjpegViewer = new WebView
            {
                Source = html,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };*/
        }
    }
}
