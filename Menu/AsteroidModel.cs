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
    public class AsteroidModel
    {
        public int spawn = 4, velocity = 5, velocityProj = 1;

       /*public Polyline AsteroideModel(Point position)
        {
            Polyline asteroide = new Polyline();
            SolidColorBrush linea = new SolidColorBrush();
            PointCollection collecionPuntos = new PointCollection();
            Point p0, p1, p2, p3, p4, p5;
            linea.Color = Colors.White;
            asteroide.Stroke = linea;
            p0 = position;
            p1 = new Point(p0.X - 10, p0.Y - 5);
            p2 = new Point(p1.X - 2, p1.Y - 15);
            p3 = new Point(p2.X + 10, p2.Y);
            p4 = new Point(p3.X + 10, p3.Y + 15);
            p5 = new Point(p0.X, p0.Y);
            collecionPuntos.Add(p0);
            collecionPuntos.Add(p1);
            collecionPuntos.Add(p2);
            collecionPuntos.Add(p3);
            collecionPuntos.Add(p4);
            collecionPuntos.Add(p5);
            asteroide.Points = collecionPuntos;
            return(asteroide);
        }*/
    }
}
