using System.Windows;
using System.Windows.Controls;
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
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var newTextBox = new TextBox();
            // here set new textbox parameters
            tbPanel.Children.Add(newTextBox);
        }

        private void BtnNext(object sender, RoutedEventArgs routedEventArgs)
        {
            SecondaryWindow secondaryWindow = new SecondaryWindow();
            this.Close();
            secondaryWindow.Show();
        }
        
        private void btnExit(object sender, RoutedEventArgs routedEventArgs)
        {
            this.Close();
        }

    }
}