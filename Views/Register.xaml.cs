using System.Windows;
using System.Windows.Controls;

namespace BidCardCoin.Vue
{
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Sucess(object sender, RoutedEventArgs e)
        {
            Login ucObj = new Login();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        
        private void btnLogin(object sender, RoutedEventArgs e)
        {
            Login ucObj = new Login();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        
    }
}