using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;

namespace TcpTestSoft_P.Model
{
    public class TcpClientModel : ObservableObject
    {
        private string _remotePort;
        public string RemotePort
        {
            get
            {
                return _remotePort;
            }
            set
            {
                _remotePort = value;
                RaisePropertyChanged( () => RemotePort );
            }
        }

        private string _remoteAddress;
        public string RemoteAddress
        {
            get
            {
                return _remoteAddress;
            }
            set
            {
                _remoteAddress = value;
                RaisePropertyChanged( () => RemoteAddress );
            }
        }

        private string _sendMessage;
        public string SendMessage
        {
            get
            {
                return _sendMessage;
            }
            set
            {
                _sendMessage = value;
                RaisePropertyChanged(() => SendMessage);
            }
        }

        private string _clientState;
        public string ClientState
        {
            get
            {
                return _clientState;
            }
            set
            {
                _clientState = value;
                RaisePropertyChanged( () => ClientState );
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
                RaisePropertyChanged( () => ReceiveAndSendData );
            }
        }

        public void AddClientState(string newState)
        {
            ClientState = newState + "\n" + ClientState;
        }

        public void AddReceiveAndSendMessage(string data)
        {
            ReceiveAndSendData = data + "\n" + ReceiveAndSendData;
        }
    }
}
