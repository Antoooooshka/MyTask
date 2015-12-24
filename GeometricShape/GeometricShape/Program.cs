using System;

namespace Shape
{
    class Program
    {
        static void Main()
        {
            double Sum = 0;
            Shape[] shapes = new Shape[5];
            shapes[0] = new Circle(2);
            shapes[1] = new Triangle(4, 6, 5);
            shapes[2] = new Rectangle(2);
            shapes[3] = new Rectangle(2, 4);
            shapes[4] = new Triangle(3, 3, 4);
            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine(shapes[i].CalculateArea());
                Sum += shapes[i].CalculateArea();
            }
            Console.WriteLine("Общая площадь = {0} ", Sum.ToString());
            Console.ReadLine();
        }
    }
    abstract class Shape
    {
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }

    class Circle : Shape
    {
        public double Radius { get; private set; }
        public static readonly string Name;

        static Circle()
        {
            Console.WriteLine("Введите имя круга");
            Name = Console.ReadLine();
        }
        public Circle(double radius)
        {
            if (radius > 0)
                Radius = radius;
            else
                throw new Exception("Радиус не может быть отрицателььным числом");
        }

        public override double CalculateArea()
        {
            return Radius * Radius * Math.PI;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    class Triangle : Shape
    {
        public static readonly string Name;
        private double _sideA;
        private double _sideB;
        private double _sideC;
        public double SideA
        {
            get { return _sideA; }
            set
            {
                if (CheckTriangle(value, SideB, SideC))
                {
                    _sideA = value;
                }

            }
        }
        public double SideB
        {
            get { return _sideB; }
            set
            {
                if (CheckTriangle(SideA, value, SideC))
                    _sideB = value;
            }
        }
        public double SideC
        {
            get { return _sideC; }
            set
            {
                if (CheckTriangle(SideA, SideB, value))
                {
                    _sideC = value;
                }
            }
        }

        static Triangle()
        {
            Console.WriteLine("Введите имя треугольника");
            Name = Console.ReadLine();
        }

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (CheckTriangle(sideA, sideB, sideC))
            {
                _sideA = sideA;
                _sideB = sideB;
                _sideC = sideC;
            }
            else
                Console.WriteLine("Такой треугольник существовать не может");
        }
        public Triangle()
        {
        }

        private bool CheckTriangle(double sideA, double sideB, double sideC)
        {
            return sideA < sideB + sideC && sideB < sideA + sideC && sideC < sideA + sideB;
        }

        public override double CalculateArea()
        {
            return (_sideA + _sideB + _sideC) / 2;
        }

        public override double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }
    }

    class Rectangle : Shape
    {
        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public static readonly string Name;

        static Rectangle()
        {
            Console.WriteLine("Введите имя прямоугольника");
            Name = Console.ReadLine();
        }
        public Rectangle(double sideA, double sideB)
        {
            if (sideA > 0 && sideB > 0)
            {
                SideA = sideA;
                SideB = sideB;
            }
            else
            {
                throw new Exception("Длинна стороны не может быть отрицательной");
            }
        }

        public Rectangle(double side)
        {
            if (side > 0)
            {
                SideA = side;
                SideB = side;
            }
        }

        public override double CalculateArea()
        {
            return SideA * SideB;
        }

        public override double CalculatePerimeter()
        {
            return SideA * 4;
        }
    }
}

