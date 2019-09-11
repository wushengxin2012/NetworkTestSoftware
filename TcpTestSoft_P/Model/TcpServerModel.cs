using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;

namespace TcpTestSoft_P.Model
{
    public class TcpServerModel : ObservableObject
    {
        private string _bindedPort;
        public string BindedPort
        {
            get
            {
                return _bindedPort;
            }
            set
            {
                _bindedPort = value;
                RaisePropertyChanged(() => BindedPort);
            }
        }

        private string _serverState;
        public string ServerState
        {
            get
            {
                return _serverState;
            }
            set
            {
                _serverState = value;
                RaisePropertyChanged(() => ServerState);
            }
        }

        private string _remoteEndPoint;
        public string RemoteEndPoint
        {
            get
            {
                return _remoteEndPoint;
            }
            set
            {
                _remoteEndPoint = value;
                RaisePropertyChanged(() => RemoteEndPoint);
            }
        }

        private string _sendedMessage;
        public string SendedMessage
        {
            get
            {
                return _sendedMessage;
            }
            set
            {
                _sendedMessage = value;
                RaisePropertyChanged(() => SendedMessage);
            }
        }

        private string _receiveAndSendData;
        public string ReceiveAndSendData
        {
            get
            {
                return _receiveAndSendData;
            }
            set
            {
                _receiveAndSendData = value;
                RaisePropertyChanged(() => ReceiveAndSendData);
            }
        }

        public void AddServerState(string state)
        {
            ServerState = state + "\n" + ServerState;
        }

        public void AddReceiveAndSendData(string data)
        {
            ReceiveAndSendData = data + " \n" + ReceiveAndSendData;
        }

    }
}