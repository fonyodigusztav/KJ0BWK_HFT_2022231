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

namespace KJ0BWK_WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayerCRUD_Click(object sender, RoutedEventArgs e)
        {
            PlayerWindow playerWindow = new PlayerWindow();
            this.Visibility = Visibility.Hidden;
            playerWindow.Show();
        }

        private void ClubCRUD_Click(object sender, RoutedEventArgs e)
        {
            ClubWindow clubWindow = new ClubWindow();
            this.Visibility = Visibility.Hidden;
            clubWindow.Show();
        }

        private void OwnerCRUD_Click(object sender, RoutedEventArgs e)
        {
            OwnerWindow ownerWindow = new OwnerWindow();
            this.Visibility = Visibility.Hidden;
            ownerWindow.Show();
        }
    }
}
