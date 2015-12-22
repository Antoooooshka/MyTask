using System;

namespace Point
{
    internal interface IColor
    {
        string Color { get; set; }
        void SetColor(string color);
        void DefaultColor();
    }

    public class Program
    {
        private static void Main()
        {
            Object a = new object();
            Console.WriteLine("Задайте цвет в какой будут перекрашены цветные точки");
            string pointColor = Console.ReadLine();
            ColoredPoint a = new ColoredPoint(15,19,pointColor);
            a.SetColor();

            a.Color = "";
            a.SetColor();
            Console.WriteLine("переменные X = {0}, Y = {1} ", a.X, a.Y);
            a.DefaultColor();
            Console.WriteLine("переменные X = {0}, Y = {1} ", a.X, a.Y);
            Console.ReadLine();
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class ColoredPoint : Point, IColor
    {
        public string Color { get; set; }
        public ColoredPoint(int x, int y, string color)
            : base(x, y)
        {
            Color = color;
        }

        public void SetColor()
        {
            switch (Color)
            {
                case "Red": Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "Yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.WriteLine("ТОчки не перекрасились");
                    break;

            }
        }

        public void DefaultColor()
        {
            Console.ResetColor();
        }
    }

    public class Line
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public Line(Point start, Point end)
        {
            StartPoint = start;
            EndPoint = end;
        }

        public Line(int x1, int y1, int x2, int y2)
            : this(new Point(x1, y1), new Point(x2, y2))
        {

        }
    }

    public class ColoredLine : Line, IColor
    {
        public string Color { get; set; }
        public ColoredLine(Point start, Point end, string color)
            : base(start, end)
        {
            Color = color;
        }

        public ColoredLine(int x1, int y1, int x2, int y2, string color)
            : base(new Point(x1, y1), new Point(x2, y2))
        {
            Color = color;
        }

        public void SetColor(string color)
        {
            switch (color)
            {
                case "Red": Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "Yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.WriteLine("Точки не перекрашены");
                    break;
            }
        }

        public void DefaultColor()
        {
            Console.ResetColor();
        }
    }

    public class PolyLine
    {
        public Line A { get; set; }
        public Line B { get; set; }
        public Line C { get; set; }
        public Line D { get; set; }

        public PolyLine(Line a, Line b, Line c, Line d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
    }
}




