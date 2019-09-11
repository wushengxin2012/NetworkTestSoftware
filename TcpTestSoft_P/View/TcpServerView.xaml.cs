using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TcpTestSoft_P.View
{
    /// <summary>
    /// TcpServer.xaml 的交互逻辑
    /// </summary>
    public partial class TcpServerView : UserControl
    {
        public TcpServerView()
        {
            InitializeComponent();
        }

        //private void StartButton_Click(object sender, RoutedEventArgs e)
        //{
        //    ViewModel.ViewModelLocator locator = (ViewModel.ViewModelLocator)Application.Current.Resources["Locator"];
        //    ViewModel.TcpServerViewModel viewModel = locator.TcpServerViewModelInstance;
        //    Model.TcpServerModel model = viewModel.TcpServerModelInstance;
        //    model.BindedPort = "1233";
        //    model.ReceiveData = "this is a receive data1\nthis is a receive data2";
        //    model.RemoteEndPoint = "192.168.1.2:2000";
        //    model.SendedMessage = "This is a send message";
        //    model.ServerState = "Waiting for Connect\nConnecton success\nstate net\n state 2\nstate 3";
        //}
    }
}
