using Magnum.FileSystem;
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
using System.Windows.Shapes;
using System.IO;

namespace Laby
{
    /// <summary>
    /// Interaction logic for Scoreboard.xaml
    /// </summary>
    public partial class Scoreboard : Window
    {

        public string name;
        public Scoreboard()
        {
            InitializeComponent();
            Load_Data();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Load_Data()
        {
            
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"Score\data.txt");
            string data =  name + "  " + System.IO.File.ReadAllText(path);
            score_list.Text = data;



        }


    }
}
