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
using System.Windows.Media.Animation;

namespace Menu
{
    class SegmAnimation
    {
        System.Windows.Shapes.Path myPath = new System.Windows.Shapes.Path();
        public void segAnim(Grid MyGrid, Point position)
        {
            Point p0, p1, p2, p3, p4, p5;
            p0 = position;
            p1 = new Point(p0.X - 10, p0.Y - 5);
            p2 = new Point(p1.X - 2, p1.Y - 15);
            p3 = new Point(p2.X + 10, p2.Y);
            p4 = new Point(p3.X + 10, p3.Y + 15);
            p5 = new Point(p0.X, p0.Y);

            Point p0to = new Point(400, 300);
            Point p1to = new Point(400, 300);
            Point p2to = new Point(400, 300);
            Point p3to = new Point(400, 300);
            Point p4to = new Point(400, 300);
            Point p5to = new Point(400, 300);

            PathGeometry pgeom = new PathGeometry();
            PathFigure pfig = new PathFigure();

            LineSegment ls0 = new LineSegment(p0, true);
            LineSegment ls1 = new LineSegment(p1, true);
            LineSegment ls2 = new LineSegment(p2, true);
            LineSegment ls3 = new LineSegment(p3, true);
            LineSegment ls4 = new LineSegment(p4, true);
            LineSegment ls5 = new LineSegment(p5, true);

            PointAnimation pa0 = new PointAnimation(p0to, new Duration(new TimeSpan(0, 0, 4)));
            PointAnimation pa1 = new PointAnimation(p1to, new Duration(new TimeSpan(0, 0, 4)));
            PointAnimation pa2 = new PointAnimation(p2to, new Duration(new TimeSpan(0, 0, 4)));
            PointAnimation pa3 = new PointAnimation(p3to, new Duration(new TimeSpan(0, 0, 4)));
            PointAnimation pa4 = new PointAnimation(p4to, new Duration(new TimeSpan(0, 0, 4)));
            PointAnimation pa5 = new PointAnimation(p5to, new Duration(new TimeSpan(0, 0, 4)));

            pfig.StartPoint = p0;
            pfig.Segments.Add(ls0);
            pfig.Segments.Add(ls1);
            pfig.Segments.Add(ls2);
            pfig.Segments.Add(ls3);
            pfig.Segments.Add(ls4);
            pfig.Segments.Add(ls5);

            pgeom.Figures.Add(pfig);
            
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 3;
            myPath.Fill = Brushes.Blue; 
            myPath.Data = pgeom;

            // Add this to the Grid I named 'MyGrid'
            MyGrid.Children.Add(myPath);
            ls0.BeginAnimation(LineSegment.PointProperty, pa0);
            ls1.BeginAnimation(LineSegment.PointProperty, pa1);
            ls2.BeginAnimation(LineSegment.PointProperty, pa2);
            ls3.BeginAnimation(LineSegment.PointProperty, pa3);
            ls4.BeginAnimation(LineSegment.PointProperty, pa4);
            ls5.BeginAnimation(LineSegment.PointProperty, pa5);
            pfig.BeginAnimation(PathFigure.StartPointProperty, pa0);
            MyGrid.Children.Remove(myPath);
        }
    }
}
