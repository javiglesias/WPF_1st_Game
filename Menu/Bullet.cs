using System;
using Microsoft;
using System.IO;
using System.Xaml;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Resources;
using System.Collections.Generic;
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

namespace Menu
{
    class Bullet
    {
        public Polyline BulletModel(Point posicion)
        {
            Polyline bullet = new Polyline();
            SolidColorBrush linea = new SolidColorBrush();
            PointCollection collecionPuntos = new PointCollection();
            Point p0, p1;
            linea.Color = Colors.Red;
            bullet.Stroke = linea;
            bullet.StrokeThickness = 2;
            p0 = posicion;
            p1 = new Point(p0.X, p0.Y-10);
            collecionPuntos.Add(p0);
            collecionPuntos.Add(p1);
            bullet.Points = collecionPuntos;
            return (bullet);
        }
    }
}
