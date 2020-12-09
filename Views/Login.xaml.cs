using System.Windows;
using System.Windows.Controls;

namespace BidCardCoin.Vue
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }
        private void btnRegister(object sender, RoutedEventArgs e)
        {
            Register ucObj = new Register();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnLogin_Sucess(object sender, RoutedEventArgs e)
        {
            Enchere ucObj = new Enchere();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
    }
}