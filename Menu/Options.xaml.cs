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

namespace Menu
{

    public partial class Options : Window
    {
        AsteroidModel change = new AsteroidModel();
        public event changeBackgroundHandler valor;
        public Slider SliderRojo = new Slider();
        public Options()
        {
            InitializeComponent();
            SliderRojo.Value = 0;
        }

        private void DevTutorial_Click(object sender, RoutedEventArgs e)
        {
            //llamo al pdf de la documentacion del programador
            System.Diagnostics.Process.Start("WPF_1_Introduccion.pdf");
        }

        protected virtual void OnchangeBackground(refreshWindow e)
        {//gestiono la invocacion al evento
            if (this.valor != null)
                this.valor(this,e);
        }

        private void window_changeBackground(object sender, RoutedEventArgs e)
        { //gestiono cuando se envia los eventos
            refreshWindow argumento = new refreshWindow();
               // argumento.value =  Colores.Negro;
            OnchangeBackground(argumento);
        }
    }
}
