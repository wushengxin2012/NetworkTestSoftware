using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

namespace TcpTestSoft_P.TcpPart
{
    public class TcpClient
    {
        public Socket Client { get; set; }
        private Model.TcpClientModel ClientModel;
        private byte[] data = new byte[1024];

        public void StartTcpClient(Model.TcpClientModel model)
        {
            ClientModel = model;
            // 解析并开始建立客户端
            int port;
            IPEndPoint remoteEndPoint;
            try
            {
                port = int.Parse(model.RemotePort);
                remoteEndPoint = new IPEndPoint(IPAddress.Parse(model.RemoteAddress), port);
                Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Client.Connect(remoteEndPoint);
                model.AddClientState("客户端建立成功...");
            }
            catch (Exception)
            {
                model.AddClientState("建立客户端失败");
                return;
            }

            try
            {
                int rece;
                while (true)
                {
                    rece = Client.Receive(data);
                    model.AddReceiveAndSendMessage("接收 -->> " + Encoding.UTF8.GetString(data, 0, rece));
                }

            }catch(Exception)
            {
                model.AddClientState("接收数据出错，关闭客户端");
                if(Client.Connected)
                {
                    Client?.Shutdown(SocketShutdown.Both);
                    Client?.Close();
                }
            }
        }

        public void SendData(string data)
        {
            if (Client != null && Client.Connected)
            {
                try
                {
                    Client.Send(Encoding.UTF8.GetBytes(data));
                    ClientModel.AddReceiveAndSendMessage("发送 -->> " + data);
                }
                catch (Exception)
                {
                    ClientModel.AddClientState("发送数据失败，尝试关闭客户端");
                    Client?.Shutdown(SocketShutdown.Both);
                    Client?.Close();
                }
            }
            else
            {
                ClientModel.AddClientState("客户端已经关闭了");
            }
        }

        public void CloseClient()
        {
            Client?.Shutdown(SocketShutdown.Both);
            Client?.Close();
            ClientModel.AddClientState("关闭客户端成功");
        }
    }
}
