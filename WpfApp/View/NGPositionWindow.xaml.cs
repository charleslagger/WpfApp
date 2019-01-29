using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp.ViewModel;

namespace WpfApp.View
{
    /// <summary>
    /// Interaction logic for NGPositionWindow.xaml
    /// </summary>
    public partial class NGPositionWindow : Window
    {
        private string Regex_Expression = @"^[-)!""#$%&'()*+,./:;<=>?@[\]^_`{|}0-9a-zA-Z]{8,32}$";
        public NGPositionWindow()
        {
            InitializeComponent();
            listRects = new ObservableCollection<Rectangle>();
        }

        private Point startPoint;
        private Point endPoint;
        private Rectangle rect;
        private bool isPressEsc;
        private MouseButtonState IsUsingMouse;
        private ObservableCollection<Rectangle> listRects;

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(canvas);

            rect = new Rectangle
            {
                Stroke = Brushes.Red,
                StrokeThickness = 4
            };
            Canvas.SetLeft(rect, startPoint.X);
            Canvas.SetTop(rect, startPoint.Y);
            
            listRects.Add(rect);

            //Console.WriteLine("==>Mouse down: startPoint.X: " + startPoint.X);
            //Console.WriteLine("==>Mouse down: startPoint.Y: " + startPoint.Y);
            canvas.Children.Add(rect);
        }

        //private void Canvas_MouseMove(object sender, MouseEventArgs e)
        //{
        //    IsUsingMouse = e.LeftButton;
        //    if (e.LeftButton == MouseButtonState.Released || rect == null)
        //        return;
            
        //        var pos = e.GetPosition(canvas);

        //        var x = Math.Min(pos.X, startPoint.X);
        //        var y = Math.Min(pos.Y, startPoint.Y);

        //        var w = Math.Max(pos.X, startPoint.X) - x;
        //        var h = Math.Max(pos.Y, startPoint.Y) - y;

        //        rect.Width = w;
        //        rect.Height = h;

        //        Canvas.SetLeft(rect, x);
        //        Canvas.SetTop(rect, y);
            
            
        //        //var pos = e.GetPosition(canvas);

        //        //var x = Math.Min(pos.X, startPoint.X);
        //        //var y = Math.Min(pos.Y, startPoint.Y);

        //        //var w = Math.Max(pos.X, startPoint.X) - x;
        //        //var h = Math.Max(pos.Y, startPoint.Y) - y;

        //        //rect.Width = w;
        //        //rect.Height = h;

        //        //Canvas.SetLeft(rect, x);
        //        //Canvas.SetTop(rect, y);
        //        //Console.WriteLine("==>Mouse move: x: " + x);
        //        //Console.WriteLine("==>Mouse move: y: " + y);
        //        //Console.WriteLine("==>Mouse move: startPoint.X: " + startPoint.X);
        //        //Console.WriteLine("==>Mouse move: startPoint.Y: " + startPoint.Y);
        //        //Console.WriteLine("==>Mouse move: pos.X: " + pos.X);
        //        //Console.WriteLine("==>Mouse move: pos.Y: " + pos.Y);
        //        //Console.WriteLine("==>Mouse move: width: " + w);
        //        //Console.WriteLine("==>Mouse move: height: " + h);
        //    }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            endPoint = e.GetPosition(canvas);
            //Console.WriteLine("==>Mouse move: startPoint.X: " + startPoint.X);
            //Console.WriteLine("==>Mouse move: startPoint.Y: " + startPoint.Y);
            //Console.WriteLine("==>Mouse up: endPoint.X: " + endPoint.X);
            //Console.WriteLine("==>Mouse up: endPoint.Y: " + endPoint.Y);
            if(endPoint.X - startPoint.X < 15 || endPoint.Y - startPoint.Y < 15 || isPressEsc == true)
            {
                canvas.Children.Remove(rect);
                isPressEsc = false;
            }
            rect = null;
        }
        public void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Hallo");
            //Console.WriteLine("==>>viewModelNGPosition.Position: " + ((ViewModelNGPosition)this.DataContext).Position);
            canvas.Children.Remove(listRects[1]);
            canvas.Children.Remove(listRects[3]);
            //canvas.Children.Remove(rect as UIElement);
            //MessageBox.Show("Hallo");
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
                if( e.Key == Key.Escape)
                {
                    isPressEsc = true;
            }
            else
            {
                isPressEsc = false;
            }
            
        }
    }
}
