using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BidCardCoin.DAL;
using BidCardCoin.ORM;
using BidCardCoin.Vue;


namespace BidCardCoin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            int count = PersonneORM.getLoginCount(TextboxUsername.Text, PasswordBox.Password);
            if (count == 1)
            {
                SecondaryWindow secondaryWindow = new SecondaryWindow();
                Close();
                secondaryWindow.Show();
            }
            else
            {
                MessageBox.Show("L'identifiant ou le mot de passe sont incorrects.");
            }

        }

        private void btnExit(object sender, RoutedEventArgs routedEventArgs)
        {
            this.Close();
        }

    }
}