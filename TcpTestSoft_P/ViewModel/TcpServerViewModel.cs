using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace TcpTestSoft_P.ViewModel
{
    public class TcpServerViewModel : ViewModelBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public TcpServerViewModel()
        {
            TcpServerModelInstance = new Model.TcpServerModel();
            TcpServerInstance = new TcpPart.TcpServer();

        }

        /// <summary>
        /// 模型
        /// </summary>
        public Model.TcpServerModel _tcpServerModel;
        public Model.TcpServerModel TcpServerModelInstance
        {
            get
            {
                return _tcpServerModel;
            }
            set
            {
                _tcpServerModel = value;
                RaisePropertyChanged(() => TcpServerModelInstance);
            }
        }

        /// <summary>
        /// Tcp Server
        /// </summary>
        public TcpPart.TcpServer TcpServerInstance { get; set; }


        /// <summary>
        /// 启动服务器命令
        /// </summary>
        private RelayCommand _startUpCmd;
        public RelayCommand TcpStartUpCmd
        {
            get
            {
                if (_startUpCmd == null)
                {
                    _startUpCmd = new RelayCommand(() => StartUpTcp(), StartUpCmdCanExecute);
                }
                return _startUpCmd;
            }
        }
        private async void StartUpTcp()
        {
            if (TcpServerInstance.ServerSocket == null)
            {
                await Task.Run(() => TcpServerInstance.StartTcpServer(TcpServerModelInstance));
            }
            else
            {
                if (!TcpServerInstance.ServerSocket.Connected)
                {
                    await Task.Run(() => TcpServerInstance.StartTcpServer(TcpServerModelInstance));
                }
                else
                {
                    TcpServerModelInstance.AddServerState("服务器 已存在");
                }
            }
        }
        private bool StartUpCmdCanExecute()
        {
            if (TcpServerModelInstance.BindedPort != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 发送数据 命令
        /// </summary>
        private RelayCommand _sendDataCmd;
        public RelayCommand SendDataCmd
        {
            get
            {
                if (_sendDataCmd == null)
                {
                    _sendDataCmd = new RelayCommand(() => TcpSendData(), SendDataCmdCanExecute);
                }
                return _sendDataCmd;
            }
        }
        private async void TcpSendData()
        {
            await Task.Run(() => TcpServerInstance.SendBack(TcpServerModelInstance.SendedMessage));
        }
        private bool SendDataCmdCanExecute()
        {
            if (TcpServerInstance.Client != null && TcpServerInstance.Client.Connected && TcpServerModelInstance.SendedMessage != null)
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
                if (_clearCmd == null)
                {
                    _clearCmd = new RelayCommand(() => ClearCmdExecute(), ClearCmdCanExecute);
                }
                return _clearCmd;
            }
        }
        private void ClearCmdExecute()
        {
            if(TcpServerInstance.ServerSocket == null)
            {
                TcpServerModelInstance.BindedPort = null;
                TcpServerModelInstance.ReceiveAndSendData = null;
                TcpServerModelInstance.SendedMessage = null;
                TcpServerModelInstance.ServerState = null;
                TcpServerModelInstance.RemoteEndPoint = null;
            }
            else
            {
                TcpServerModelInstance.ServerState = null;
                TcpServerModelInstance.SendedMessage = null;
                TcpServerModelInstance.ReceiveAndSendData = null;
            }
            
        }
        private bool ClearCmdCanExecute()
        {
            if(TcpServerInstance.ServerSocket != null)
            {
                if (TcpServerModelInstance.ReceiveAndSendData != null ||
                TcpServerModelInstance.SendedMessage != null ||
                TcpServerModelInstance.ServerState != null )
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
                if (TcpServerModelInstance.BindedPort != null ||
                TcpServerModelInstance.ReceiveAndSendData != null ||
                TcpServerModelInstance.SendedMessage != null ||
                TcpServerModelInstance.ServerState != null ||
                TcpServerModelInstance.RemoteEndPoint != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        private RelayCommand _closeTcpServerCmd;
        public RelayCommand CloseTcpServerCmd
        {
            get
            {
                if(_closeTcpServerCmd == null)
                {
                    _closeTcpServerCmd = new RelayCommand(() => CloseTcpServer(), CloseTcpServerCmdCanExecute);
                }
                return _closeTcpServerCmd;
            }
        }
        private void CloseTcpServer()
        {
            TcpServerInstance.CloseTcpServer();
            TcpServerModelInstance.AddServerState("服务器关闭成功");
        }
        private bool CloseTcpServerCmdCanExecute()
        {
            if( TcpServerInstance.ServerSocket != null)
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
