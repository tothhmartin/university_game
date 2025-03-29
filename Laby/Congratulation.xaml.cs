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
    /// Interaction logic for Congratulation.xaml
    /// </summary>
    public partial class Congratulation : Window
    {
        public Congratulation()
        {
            InitializeComponent();
            ImageBrush brush = new ImageBrush();
            brush = new ImageBrush
                           (new BitmapImage(new Uri(System.IO.Path.Combine("Images", "congrat.jpg"), UriKind.RelativeOrAbsolute)));
            grid.Background = brush;
        }
        public void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void NewGame(object sender, RoutedEventArgs e)
        {
            GameMenu menu = new GameMenu();
            menu.Show();
            this.Close();
        }
    }
}
