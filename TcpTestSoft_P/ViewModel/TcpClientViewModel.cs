using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace TcpTestSoft_P.ViewModel
{
    public class TcpClientViewModel : ViewModelBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public TcpClientViewModel()
        {
            TcpClientModelInstance = new Model.TcpClientModel();
            TcpClientInstance = new TcpPart.TcpClient();

        }

        /// <summary>
        /// 数据模型
        /// </summary>
        public Model.TcpClientModel _tcpClientModel;
        public Model.TcpClientModel TcpClientModelInstance
        {
            get
            {
                return _tcpClientModel;
            }
            set
            {
                _tcpClientModel = value;
                RaisePropertyChanged( () => TcpClientModelInstance );
            }
        }

        /// <summary>
        /// Tcp 客户端实例
        /// </summary>
        public TcpPart.TcpClient TcpClientInstance { get; set; }


        /// <summary>
        /// 打开链接命令
        /// </summary>
        private RelayCommand _openConnectCmd;
        public RelayCommand OpenConnectCmd
        {
            get
            {
                if(_openConnectCmd == null)
                {
                    _openConnectCmd = new RelayCommand( () => OpenConnect(), OpenConnectCmdCanExecute );
                }
                return _openConnectCmd;
            }
        }
        private async void OpenConnect()
        {
            if (TcpClientInstance.Client == null || !TcpClientInstance.Client.Connected)
            {
                await Task.Run( () => TcpClientInstance.StartTcpClient( TcpClientModelInstance ) );
            }
            else
            {
                TcpClientModelInstance.AddClientState("客户端已经存在");
            }

        }
        public bool OpenConnectCmdCanExecute()
        {
            if(TcpClientModelInstance.RemotePort != null && TcpClientModelInstance.RemoteAddress != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 发送数据命令
        /// </summary>
        private RelayCommand _sendDataCmd;
        public RelayCommand SendDataCmd
        {
            get
            {
                if(_sendDataCmd == null)
                {
                    _sendDataCmd = new RelayCommand( () => SendData(), SendDataCmdCanExecute);
                }
                return _sendDataCmd;
            }
        }
        private async void SendData()
        {
            await Task.Run( () => TcpClientInstance.SendData( TcpClientModelInstance.SendMessage ) );
        }
        private bool SendDataCmdCanExecute()
        {
            if( TcpClientInstance.Client != null && TcpClientInstance.Client.Connected && TcpClientModelInstance.SendMessage != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 关闭链接命令
        /// </summary>
        private RelayCommand _closeConnectCmd;
        public RelayCommand CloseConnectCmd
        {
            get
            {
                if(_closeConnectCmd == null)
                {
                    _closeConnectCmd = new RelayCommand( () => CloseConnect() , CloseConnectCmdCanExecute);
                }
                return _closeConnectCmd;
            }
        }
        private void CloseConnect()
        {
            TcpClientInstance.CloseClient();
        }
        private bool CloseConnectCmdCanExecute()
        {
            if( TcpClientInstance.Client != null && TcpClientInstance.Client.Connected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 清除命令
        /// </summary>
        private RelayCommand _clearCmd;
        public RelayCommand ClearCmd
        {
            get
            {
                if(_clearCmd == null)
                {
                    _clearCmd = new RelayCommand( () => ClearContent() , ClearCmdCanExecute );
                }
                return _clearCmd;
            }
        }
        private void ClearContent()
        {
            TcpClientModelInstance.SendMessage = null;
            TcpClientModelInstance.ClientState = null;
            TcpClientModelInstance.ReceiveAndSendData = null;
            if (!TcpClientInstance.Client.Connected)
            {
                TcpClientModelInstance.RemotePort = null;
                TcpClientModelInstance.RemoteAddress = null;
            }
         
        }
        private bool ClearCmdCanExecute()
        {
            if( TcpClientInstance.Client !=null && TcpClientInstance.Client.Connected)
            {
                if( TcpClientModelInstance.SendMessage != null ||
                    TcpClientModelInstance.ClientState != null ||
                    TcpClientModelInstance.ReceiveAndSendData != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (TcpClientModelInstance.SendMessage != null ||
                    TcpClientModelInstance.ClientState != null ||
                    TcpClientModelInstance.ReceiveAndSendData != null ||
                    TcpClientModelInstance.RemotePort != null ||
                    TcpClientModelInstance.RemoteAddress != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
