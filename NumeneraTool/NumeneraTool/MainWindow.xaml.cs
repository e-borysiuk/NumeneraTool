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

namespace NumeneraTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PlayersList.Players.Add(new Player("Felix"));
            PlayersList.Players.Add(new Player("Weaver"));
            PlayersList.Players.Add(new Player("Dorain"));
            LbPlayers.ItemsSource = PlayersList.Players;
        }

        private void AddValue(object sender, ExecutedRoutedEventArgs e)
        {
            var parent = (Grid)((Button)e.OriginalSource).Parent;
            Player currentPlayer = (Player)parent.DataContext;
            switch (e.Parameter.ToString())
            {
                case "Might":
                    currentPlayer.Might.Current++;
                    break;
                case "Speed":
                    currentPlayer.Speed.Current++;
                    break;
                case "Intellect":
                    currentPlayer.Intellect.Current++;
                    break;
            }

        }

        private void SubtactValue(object sender, ExecutedRoutedEventArgs e)
        {
            var parent = (Grid)((Button)e.OriginalSource).Parent;
            Player currentPlayer = (Player)parent.DataContext;
            switch (e.Parameter.ToString())
            {
                case "Might":
                    currentPlayer.Might.Current--;
                    break;
                case "Speed":
                    currentPlayer.Speed.Current--;
                    break;
                case "Intellect":
                    currentPlayer.Intellect.Current--;
                    break;
            }
        }

        private void MenuManage_Click(object sender, RoutedEventArgs e)
        {
            ManageWindow manageWindow = new ManageWindow();
            manageWindow.Show();
        }
    }
}
