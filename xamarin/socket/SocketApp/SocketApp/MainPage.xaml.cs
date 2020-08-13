using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocketApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        
        private async void ConnectButton_Clicked(object sender, EventArgs e)
        {
            string ipStr = _entryIP.Text; 
            string portStr = _entryPort.Text;

            int port;
            if (int.TryParse(portStr, out port))
            {
                //AsynchronousClient.StartClient(ipStr, port);
                SynchronousSocketClient.StartClient(ipStr, port);
            }
            
            //_entryIP.Text;
            //_entryPort.Text;
        }
    }
}
