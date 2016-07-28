using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
using System.Threading;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Menu
{
    public partial class Window1 : Window
    {
        private shipModel ship = new shipModel();
        AsteroidModel change = new AsteroidModel();

        Polyline Asteroides = new Polyline();
        Polyline bulleto = new Polyline();
        Polyline shipRotate = new Polyline();

        Point posicion = new Point();
        Point posicionRaton = new Point();
        Point position = new Point(400, 300);

        Options opt;
        Color config;
        SoundPlayer reproductor = new SoundPlayer("laser.wav");

        double alpha;

        public Window1()
        {
            DispatcherTimer timer = new DispatcherTimer();
            InitializeComponent();
            //this.Background = new SolidColorBrush(Colors.Red);
            Background = new SolidColorBrush(Colors.Black);
            Gride.Background = new SolidColorBrush(Colors.Transparent);
            timer.Tick += new EventHandler(move);
            timer.Interval = new TimeSpan(0, 0, 0, change.spawn);
            //System.Console.WriteLine("spawn valor Timer:" + change.spawn);
            timer.Start();
        }

        private void move(object sender, EventArgs e)
        {
            Random rand = new Random();
            posicion.X = rand.Next(800);
            posicion.Y = rand.Next(600);
            this.Dispatcher.Invoke((Action)(() =>
            {
                segAnim(Gride, posicion);
            }));
        }

        private void Gride_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            reproductor.Play();
            this.Dispatcher.Invoke((Action)(() =>
            {
                bulletAnim(position);
            }));
        }

        private void Gride_MouseMove(object sender, MouseEventArgs e)
        {
            posicionRaton = e.GetPosition(Gride);//posicion del raton
            this.Dispatcher.Invoke((Action)(() =>
            {
                rotateShip();
            })); 
        }

        public void segAnim(Grid MyGrid, Point position)
        {//esto corresponde a los asteroides
            System.Windows.Shapes.Path myPath = new System.Windows.Shapes.Path();
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

            PointAnimation pa0 = new PointAnimation(p0to, new Duration(new TimeSpan(0, 0, change.velocity)));
            PointAnimation pa1 = new PointAnimation(p1to, new Duration(new TimeSpan(0, 0, change.velocity)));
            PointAnimation pa2 = new PointAnimation(p2to, new Duration(new TimeSpan(0, 0, change.velocity)));
            PointAnimation pa3 = new PointAnimation(p3to, new Duration(new TimeSpan(0, 0, change.velocity)));
            PointAnimation pa4 = new PointAnimation(p4to, new Duration(new TimeSpan(0, 0, change.velocity)));
            PointAnimation pa5 = new PointAnimation(p5to, new Duration(new TimeSpan(0, 0, change.velocity)));
            System.Console.WriteLine("velocity valor segAnim:" + change.velocity);

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
            myPath.Stroke = Brushes.White;
            myPath.Data = pgeom;

            MyGrid.Children.Add(myPath);

            ls0.BeginAnimation(LineSegment.PointProperty, pa0);
            ls1.BeginAnimation(LineSegment.PointProperty, pa1);
            ls2.BeginAnimation(LineSegment.PointProperty, pa2);
            ls3.BeginAnimation(LineSegment.PointProperty, pa3);
            ls4.BeginAnimation(LineSegment.PointProperty, pa4);
            ls5.BeginAnimation(LineSegment.PointProperty, pa5);
            pfig.BeginAnimation(PathFigure.StartPointProperty, pa0);
        }

        public void rotateShip()
        {//PAra rotar na nave
            Gride.Children.Remove(shipRotate);
            RotateTransform rotar = new RotateTransform(0);
            int xr = (int)posicionRaton.X;
            int yr = (int)posicionRaton.Y;
            double d1, d2, H;
            shipRotate = ship.shipModelo();
            int xs = 400;
            int ys = 320;
            d1 = xr - xs;
            d2 = yr - ys;
            H = Math.Sqrt(Math.Pow(d1,2) + Math.Pow(d2,2));
            alpha = (Math.Asin(Math.Sin(d1/H)));
            if (posicionRaton.Y < 320)
            {
                rotar = new RotateTransform(alpha * 90);
            }
            if (posicionRaton.Y > 320)
            {
                rotar = new RotateTransform(-(alpha * 90) + 180);
            }
            rotar.CenterX = xs;
            rotar.CenterY = ys;
            shipRotate.RenderTransform = rotar;
            Gride.Children.Add(shipRotate);
        }

        public void bulletAnim(Point position)
        {//esto corresponde a los proyectiles
            Path myPath = new Path();
            Point p0, p1;
            p0 = position; //new Point(-(position.Y/Math.Sin(alpha+10)),position.Y); Esto no va como pensaba
            p1 = new Point(p0.X - 10, p0.Y - 5);

            Point p0to = new Point(posicionRaton.X, posicionRaton.Y);
            Point p1to = new Point(posicionRaton.X, posicionRaton.Y);

            PathGeometry pgeom = new PathGeometry();
            PathFigure pfig = new PathFigure();

            LineSegment ls0 = new LineSegment(p0, true);
            LineSegment ls1 = new LineSegment(p1, true);

            PointAnimation pa0 = new PointAnimation(p0to, new Duration(new TimeSpan(0, 0, change.velocityProj)));
            PointAnimation pa1 = new PointAnimation(p1to, new Duration(new TimeSpan(0, 0, change.velocityProj)));

            pfig.StartPoint = p0;
            pfig.Segments.Add(ls0);
            pfig.Segments.Add(ls1);

            pgeom.Figures.Add(pfig);

            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 3;
            myPath.Stroke = Brushes.Red;
            myPath.Data = pgeom;

            Gride.Children.Add(myPath);

            ls0.BeginAnimation(LineSegment.PointProperty, pa0);
            ls1.BeginAnimation(LineSegment.PointProperty, pa1);
            pfig.BeginAnimation(PathFigure.StartPointProperty, pa0);
            
        }
         public void config_Background(object sender, RoutedEventArgs e)
        { //registro el evento el la ventana que actualizara, se producira el cambio
           // Window1 esta = new Window1
            this.Show();
            opt = new Options();
            opt.valor += new changeBackgroundHandler(opt_valor);
            opt.Owner = this;
            opt.SliderRojo.Value = config.R;
            opt.Show();
        }
        private void opt_valor(object sender, refreshWindow e)
        {

            Background = new SolidColorBrush(Colors.Blue);
        }
    }
}
