using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Win32;

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
            PlayersList.Players.Add(new Player("Player"));
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
            manageWindow.Owner = this;
            manageWindow.Show();
        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            List<Player> saveList = new List<Player>();
            foreach (Player player in PlayersList.Players)
            {
                saveList.Add(player);
            }
            XmlSerializer x = new XmlSerializer(saveList.GetType());
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Campaign file (*.dat)|*.dat";
            if (saveFileDialog.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(saveFileDialog.FileName);
                x.Serialize(file, saveList);
                file.Close();
            }
        }

        private void MenuLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Campaign file (*.dat)|*.dat";
            if (openFileDialog.ShowDialog() == true)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Player>));
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                XmlReader reader = XmlReader.Create(fs);
                List<Player> loadList = (List<Player>)serializer.Deserialize(reader);
                PlayersList.Players.Clear();
                foreach (var player in loadList)
                {
                    PlayersList.Players.Add(player);
                }
            }
        }

        private void MenuNew_Click(object sender, RoutedEventArgs e)
        {
            if (PlayersList.Players.Count != 0)
            {
                var result = MessageBox.Show("Do you want to delete current players?", "Confirm", MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (result == MessageBoxResult.No) return;
            }
            PlayersList.Players.Clear();
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save changes?", "Confirm", MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) MenuSave_Click(null, null);
            else if(result == MessageBoxResult.Cancel) e.Cancel = true;
        }
    }
}
