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
using System.Media;
using System.Windows.Media.Animation;
using System.Threading;

namespace Menu
{
    public partial class MainWindow : Window
    {
        SoundPlayer reproductor = new SoundPlayer("Training.wav");

        public MainWindow()
        {
            InitializeComponent();
            reproductor.PlayLooping();
        }

        private void SinglePlayer_Click(object sender, RoutedEventArgs e)
        {
            reproductor.Stop();
            Window1 single = new Window1();
            single.Show();
        }

        private void Tutorial_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("WPF_1_Introduccion.pdf");
        }

        private void Web_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://es.wikipedia.org/wiki/Asteroids");
        }

        private void Options_Click(object sender, RoutedEventArgs e)
        {
            Window1 opt = new Window1();
            opt.config_Background(sender,e);
        }

        private void VolumeOFF_Click(object sender, RoutedEventArgs e)
        {
            reproductor.Stop();
        }
    }
}
