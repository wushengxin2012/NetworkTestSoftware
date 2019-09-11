using GalaSoft.MvvmLight;

using System.Collections.Generic;

namespace TcpTestSoft_P.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            // -------- test --------
            // -------- test --------
            ViewList = new List<Model.ViewItem>()
            {
                new Model.ViewItem(){Name = "Tcp 服务器", View = new View.TcpServerView()},
                new Model.ViewItem(){Name = "Tcp 客户端", View = new View.TcpClientView()},
                //new Model.ViewItem(){Name = "Udp 服务器", View = new View.UdpServerView()},
                //new Model.ViewItem(){Name = "Udp 客户端", View = new View.UdpClientView()}
            };
        }

        private List<Model.ViewItem> _viewList;
        public List<Model.ViewItem> ViewList
        {
            get { return _viewList; }
            set { _viewList = value; RaisePropertyChanged(() => ViewList); }
        }
    }
}