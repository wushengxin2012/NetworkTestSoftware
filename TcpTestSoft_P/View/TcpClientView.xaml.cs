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
    /// TcpClientView.xaml 的交互逻辑
    /// </summary>
    public partial class TcpClientView : UserControl
    {
        public TcpClientView()
        {
            InitializeComponent();
        }

        //private void Connect_Click(object sender, RoutedEventArgs e)
        //{
        //    ViewModel.ViewModelLocator locator = (ViewModel.ViewModelLocator)Application.Current.Resources["Locator"];
        //    ViewModel.TcpClientViewModel viewModel = locator.TcpClientViewModelInstance;
        //    Model.TcpClientModel model = viewModel.TcpClientModelInstance;
        //    model.ClientState = "it is connection";
        //    model.SendMessage = " receving data ...";
        //    model.RemoteAddress = "127.0.0.4";
        //    model.RemotePort = "125";
        //    model.ReceiveAndSendData = "rece --> \n send ---> ";

        //}
    }
}
