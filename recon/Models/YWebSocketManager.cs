using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using WebSocketSharp;
using Xamarin.Forms;

namespace recon.Models
{
    public class YWebSocketManager
    {
        private WebSocket WS = null;
        public YWebSocketManager(string wsUrl)
        {
            if (wsUrl.IsNullOrEmpty())
            {
                wsUrl = "wss://proxy.8codebubble.com:6021/api";
            }
            WS = new WebSocket(wsUrl);
            WS.OnMessage += GlobalWebSocket_OnMessage;
            WS.OnOpen += GlobalWebSocket_OnOpen;
            WS.OnClose += GlobalWebSocket_OnClose;
            //WS.OnError += GlobalWebSocket_OnError;
            //WS.EmitOnPing = true;
            WS.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
            this.connect();
            WS.Send("{\"isDone\": false, clientData: {\"stream_name\": \"TurtleCam\"},command: \"ready\"}");
        }
        private void connect_reconnect()
        {
            if(!WS.IsAlive)
            {
                this.connect();
            }
        }
        private void connect()
        {
            WS.Connect();
        }

        void GlobalWebSocket_OnError(object sender, System.IO.ErrorEventArgs e)
        {
        }


        void GlobalWebSocket_OnClose(object sender, CloseEventArgs e)
        {
        }


        void GlobalWebSocket_OnOpen(object sender, EventArgs e)
        {
        }


        void GlobalWebSocket_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.IsPing)
            {
                string tmp_msg = "{\"isDone\": false, clientData: {\"text\": \"I was pinged\"},command: \"pong\"}";
                WS.Send(tmp_msg);
                Console.WriteLine("Message forum" + tmp_msg);
            }
            Console.WriteLine("Message Data->>" + e.Data);
            Dictionary<string,string> data = JsonConvert.DeserializeObject< Dictionary<string, string>>(e.Data);
            Console.WriteLine(data["serverData"]);
            var image = this.Base64ToImage(data["serverData"]);
        }
        public void startFrameRequest()
        {
            connect_reconnect();
            WS.Send("{\"isDone\": false, clientData: {\"stream_name\": \"TurtleCam\"},command: \"ready\"}");
        }

        /// <summary>
        /// Base64s to image.
        /// </summary>
        /// <returns>The to image.</returns>
        /// <param name="base64String">Base64 string.</param>
        /// <remarks>Taken from https://forums.xamarin.com/discussion/19853/load-image-form-byte-array</remarks>
        public Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            Image image = new Image();
            image.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
            return image;
        }
    }
}
