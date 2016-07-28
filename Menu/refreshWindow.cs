using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
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
    public enum Colores  {Rojo,Verde,Negro};
    public class refreshWindow : EventArgs
    {//creo el tipo de evento que voy a utilizar
        public Colores value;
        /*public static Action EmptyDelegate = delegate(){};
        public static void Refresh(this UIElement element)
        {
            element.Dispatcher.Invoke(DispatcherPriority.Render,EmptyDelegate);
            System.Console.WriteLine("refrescando");
            
        }*/
    }
    public delegate void changeBackgroundHandler(object sender, refreshWindow e);
    //creo un delegado que se encargue del tipo de evento
}
