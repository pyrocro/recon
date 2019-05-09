using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using recon.Views;
//using System.Net.WebSockets;
using System.Threading;
using WebSocketSharp;
using recon.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace recon
{
    public partial class App : Application
    {
        public YWebSocketManager GlobalWebSocket = null;
        //string addStream= "{\n  \"isDone\": false,\n  clientData: {\"stream_name\": \"apt_cam\", \"stream_url\":\"https://6104b253.ngrok.io\" },\n  command: \"add_stream\"\n}";
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


            /*GlobalWebSocket = new WebSocket("ws://proxy.8codebubble.com:6021/api");
            GlobalWebSocket.OnMessage += (sender, e) => 
            Console.WriteLine("here ->>"+e.Data);
            GlobalWebSocket.Connect();
            GlobalWebSocket.Send("{\"isDone\": false, clientData: {\"stream_name\": \"TurtleCam\"},command: \"ready\"}");*/
            GlobalWebSocket = new YWebSocketManager(null);
            GlobalWebSocket.startFrameRequest();

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
