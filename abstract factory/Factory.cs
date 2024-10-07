using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using abstract_factory;

namespace abstract_factory
{
    public interface IShapeDrawable
    {
        void Draw(Canvas canvas);
    }
    public interface IShape
    {
        void Draw();
    }

    public interface IShapeFactory
    {
        IShape CreateCircle();
        IShape CreateSquare();
        IShape CreateTriangle();
    }
    public class RedCircle : IShape, IShapeDrawable
    {
        public void Draw()
        {
            Console.WriteLine("красный круг");
        }

        public void Draw(Canvas canvas)
        {
            var ellipse = new Ellipse
            {
                Width = 50,
                Height = 50,
                Fill = Brushes.Red
            };
            Canvas.SetLeft(ellipse, 10);  
            Canvas.SetTop(ellipse, 10);   
            canvas.Children.Add(ellipse);
        }
    }

    public class RedSquare : IShape, IShapeDrawable
    {
        public void Draw()
        {
            Console.WriteLine("красный квадрат");
        }

        public void Draw(Canvas canvas)
        {
            var rectangle = new Rectangle
            {
                Width = 50,
                Height = 50,
                Fill = Brushes.Red
            };
            Canvas.SetLeft(rectangle, 70);  
            Canvas.SetTop(rectangle, 10);   
            canvas.Children.Add(rectangle);
        }
    }

    public class RedTriangle : IShape, IShapeDrawable
    {
        public void Draw()
        {
            Console.WriteLine("красный треугольник");
        }

        public void Draw(Canvas canvas)
        {
            var polygon = new Polygon
            {
                Points = new PointCollection
            {
                new Point(0, 50),
                new Point(25, 0),
                new Point(50, 50)
            },
                Fill = Brushes.Red
            };
            Canvas.SetLeft(polygon, 130);  
            Canvas.SetTop(polygon, 10);   
            canvas.Children.Add(polygon);
        }
    }

    public class BlueCircle : IShape, IShapeDrawable
    {
        public void Draw()
        {
            Console.WriteLine("синий круг");
        }

        public void Draw(Canvas canvas)
        {
            var ellipse = new Ellipse
            {
                Width = 50,
                Height = 50,
                Fill = Brushes.Blue
            };
            Canvas.SetLeft(ellipse, 10);  
            Canvas.SetTop(ellipse, 10);  
            canvas.Children.Add(ellipse);
        }
    }

    public class BlueSquare : IShape, IShapeDrawable
    {
        public void Draw()
        {
            Console.WriteLine("синий квадрат");
        }

        public void Draw(Canvas canvas)
        {
            var rectangle = new Rectangle
            {
                Width = 50,
                Height = 50,
                Fill = Brushes.Blue
            };
            Canvas.SetLeft(rectangle, 70);  
            Canvas.SetTop(rectangle, 10);   
            canvas.Children.Add(rectangle);
        }
    }

    public class BlueTriangle : IShape, IShapeDrawable
    {
        public void Draw()
        {
            Console.WriteLine("синий треугольник");
        }

        public void Draw(Canvas canvas)
        {
            var polygon = new Polygon
            {
                Points = new PointCollection
            {
                new Point(0, 50),
                new Point(25, 0),
                new Point(50, 50)
            },
                Fill = Brushes.Blue
            };
            Canvas.SetLeft(polygon, 130);  
            Canvas.SetTop(polygon, 10);   
            canvas.Children.Add(polygon);
        }
    }

    public class GreenCircle : IShape, IShapeDrawable
    {
        public void Draw()
        {
            Console.WriteLine("зеленый круг");
        }

        public void Draw(Canvas canvas)
        {
            var ellipse = new Ellipse
            {
                Width = 50,
                Height = 50,
                Fill = Brushes.Green
            };
            Canvas.SetLeft(ellipse, 10);  
            Canvas.SetTop(ellipse, 10);   
            canvas.Children.Add(ellipse);
        }
    }

    public class GreenSquare : IShape, IShapeDrawable
    {
        public void Draw()
        {
            Console.WriteLine("зеленый квадрат");
        }

        public void Draw(Canvas canvas)
        {
            var rectangle = new Rectangle
            {
                Width = 50,
                Height = 50,
                Fill = Brushes.Green
            };
            Canvas.SetLeft(rectangle, 70);  
            Canvas.SetTop(rectangle, 10);   
            canvas.Children.Add(rectangle);
        }
    }

    public class GreenTriangle : IShape, IShapeDrawable
    {
        public void Draw()
        {
            Console.WriteLine("зеленый треугольник");
        }

        public void Draw(Canvas canvas)
        {
            var polygon = new Polygon
            {
                Points = new PointCollection
            {
                new Point(0, 50),
                new Point(25, 0),
                new Point(50, 50)
            },
                Fill = Brushes.Green
            };
            Canvas.SetLeft(polygon, 130);  
            Canvas.SetTop(polygon, 10);   
            canvas.Children.Add(polygon);
        }
    }

    public class RedFactory : IShapeFactory
    {
        public IShape CreateCircle() => new RedCircle();
        public IShape CreateSquare() => new RedSquare();
        public IShape CreateTriangle() => new RedTriangle();
    }

    public class BlueFactory : IShapeFactory
    {
        public IShape CreateCircle() => new BlueCircle();
        public IShape CreateSquare() => new BlueSquare();
        public IShape CreateTriangle() => new BlueTriangle();
    }

    public class GreenFactory : IShapeFactory
    {
        public IShape CreateCircle() => new GreenCircle();
        public IShape CreateSquare() => new GreenSquare();
        public IShape CreateTriangle() => new GreenTriangle();
    }
}
