using Laby.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Laby
{
    /// <summary>
    /// Interaction logic for GameMenu.xaml
    /// </summary>
    public partial class GameMenu : Window
    {
        public GameMenu()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            WriteText();
            this.Close();
        }

        public void WriteText()
        {

            string data = Enter_Name.Text;
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"Score\player.txt");
            File.WriteAllText(path, data);
        }

        private void ScoreBoard_show(object sender, RoutedEventArgs e)
        {
           
            Scoreboard scoreboard = new Scoreboard();
           
            scoreboard.Show();
            

        }
        private void open_help(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void start_TouchUp(object sender, TouchEventArgs e)
        {

        }
    }
}
