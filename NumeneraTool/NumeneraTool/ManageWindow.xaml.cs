using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace NumeneraTool
{
    /// <summary>
    /// Interaction logic for Manage.xaml
    /// </summary>
    public partial class ManageWindow : Window
    {
        public ManageWindow()
        {
            InitializeComponent();
            LbPlayers.ItemsSource = PlayersList.Players;
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LbPlayers.SelectedIndex == -1) return;
            PlayersList.Players.RemoveAt(LbPlayers.SelectedIndex);
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            PlayersList.Players.Add(new Player("New player"));
            LbPlayers.SelectedIndex = LbPlayers.Items.Count - 1;
        }

    }
}
