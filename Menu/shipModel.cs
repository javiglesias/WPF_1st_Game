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
    class shipModel
    {
        public Polyline shipModelo()
        {
            Polyline asteroide = new Polyline();
            SolidColorBrush linea = new SolidColorBrush();
            PointCollection collecionPuntos = new PointCollection();
            Point p0, p1, p2, p3,p4;

            linea.Color = Colors.White;

            asteroide.Stroke = linea;
            asteroide.StrokeThickness = 2;

            p0 = new Point(400, 300);
            p1 = new Point(p0.X + 10, p0.Y + 40);
            p2 = new Point(p1.X-10, p1.Y -10);
            p3 = new Point(p2.X-10, p2.Y+10);
            p4 = new Point(p0.X, p0.Y);

            collecionPuntos.Add(p0);
            collecionPuntos.Add(p1);
            collecionPuntos.Add(p2);
            collecionPuntos.Add(p3);
            collecionPuntos.Add(p4);

            asteroide.Points = collecionPuntos;

            return (asteroide);
        }
    }
}
