using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

namespace TcpTestSoft_P.TcpPart
{
    public class TcpServer
    {
        public Socket ServerSocket { get; set; }
        public Socket Client { get; set; }
        public Model.TcpServerModel ServerModel { get; set; }


        /// <summary>
        /// 启动 TCP 服务
        /// </summary>
        public void StartTcpServer(Model.TcpServerModel serverModel)
        {
            ServerModel = serverModel;
            // 解析 端口
            int port = 0;
            try
            {
                port = int.Parse(serverModel.BindedPort);
            }
            catch (Exception)
            {
                serverModel.AddServerState("端口转换错误");
            }

            // 开始建立服务器
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, port);
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ServerSocket.Bind(serverEndPoint);
            ServerSocket.Listen(5);
            serverModel.AddServerState("建立服务器 成功，等待 TCP 客户端连接");

            while (true)
            {
                Client = ServerSocket.Accept();
                IPEndPoint clientEndPoint = (IPEndPoint)Client.RemoteEndPoint;
                serverModel.AddServerState("连接 到 客户端");
                serverModel.RemoteEndPoint = string.Format("{0}:{1}", clientEndPoint.Address, clientEndPoint.Port);

                int rece;
                string receiveString;
                byte[] data = new byte[1024];
                while (true)
                {
                    try
                    {
                        rece = Client.Receive(data);
                    }
                    catch (SocketException)
                    {
                        serverModel.AddServerState("接收数据出错，尝试关闭服务器");
                        Client?.Shutdown(SocketShutdown.Both);
                        Client?.Close();
                        ServerSocket?.Close();
                        return;
                    }
                    if(rece == 0)
                    {
                        serverModel.AddServerState("客户端 请求关闭，失去连接");
                        serverModel.AddServerState("服务器 等待 新TCP客户端");
                        break;
                    }

                    receiveString = Encoding.UTF8.GetString(data, 0, rece);
                    serverModel.AddReceiveAndSendData("接收 -> "+receiveString);
                }
                Client?.Shutdown(SocketShutdown.Both);
                Client?.Close();
                Client?.Dispose();
            }
        }

        public void SendBack(string sendedData)
        {
            if(Client.Connected)
            {
                Client.Send(Encoding.UTF8.GetBytes(sendedData));
                ServerModel.AddReceiveAndSendData("发送 -> " + sendedData);
            }
            else
            {
                ServerModel.AddServerState("客户端 已关闭");
            }
        }
    }
}
