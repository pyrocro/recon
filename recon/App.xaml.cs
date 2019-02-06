using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using recon.Views;
//using System.Net.WebSockets;
using System.Threading;
using WebSocketSharp;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace recon
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            /*var cts = new CancellationTokenSource();
            ClientWebSocket ws = new ClientWebSocket();
            ws.ConnectAsync(new Uri("ws://proxy.8codebubble.com:6021/api"),cts.Token);
            System.Console.ForegroundColor = ConsoleColor.DarkMagenta;
            System.Console.WriteLine("reached here!");
            System.Console.ResetColor();*/

            using (var ws = new WebSocket("ws://proxy.8codebubble.com:6021/api"))
            {
                ws.OnMessage += (sender, e) => Console.WriteLine("here");
                ws.Connect();
                ws.Send();

            }

            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
