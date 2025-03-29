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
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {

            string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"Images\" );
            Txt1.Text = "A játékban mozogni a nyilakkal lehet, lőni pedig a Space gombbal lehetséges";
            Txt2.Text = "A játék cálja minél hamarabb teljesíteni az összes pályát.";
            txt3.Text = "A tank ikont felvéve 4 lőszerhez jutunk \n \n A pajzsot felvéve túlélhetünk egy robbanást \n \n" +
                "Az ajtó az adott pálya végét jelzi \n \n A kupát felvéve fejezzük be a játékot";
            kep1.Source = (new ImageSourceConverter()).ConvertFromString(path + "nyilak.jpg") as ImageSource;
            kep2.Source = (new ImageSourceConverter()).ConvertFromString(path + "space.jpg") as ImageSource;
            kep3.Source = (new ImageSourceConverter()).ConvertFromString(path + "shield.png") as ImageSource;
            kep4.Source = (new ImageSourceConverter()).ConvertFromString(path + "exit.png") as ImageSource;
            kep5.Source = (new ImageSourceConverter()).ConvertFromString(path + "tank.png") as ImageSource;
            kupa.Source = (new ImageSourceConverter()).ConvertFromString(path + "award.png") as ImageSource;
            
            
            
            
        }
        
    }
}
