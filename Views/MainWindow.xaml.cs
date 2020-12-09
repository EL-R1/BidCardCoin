using System.Windows;
using BidCardCoin.Vue;


namespace BidCardCoin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void BtnNext(object sender, RoutedEventArgs routedEventArgs)
        {
            SecondaryWindow secondaryWindow = new SecondaryWindow();
            this.Close();
            secondaryWindow.Show();
        }

    }
}