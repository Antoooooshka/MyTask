using System;

namespace Shape
{
    class Program
    {
        static void Main()
        {
            Circle crc = new Circle(5);
            Console.WriteLine("Площадь {0} = {1} периметр = {2}", Circle.Name, crc.CalculateArea(), crc.CalculatePerimeter());
            Triangle tr = new Triangle(3,3,3);
            Console.WriteLine("Площадь {0} = {1} периметр = {2}", Triangle.Name, tr.CalculateArea(), tr.CalculatePerimeter());
            Rectangle rec = new Rectangle(3, 3);
            Console.WriteLine("Площадь {0} = {1} периметр = {2}", Rectangle.Name, rec.CalculateArea(), rec.CalculatePerimeter());
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
        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public double SideC { get; private set; }

        static Triangle()
        {
            Console.WriteLine("Введите имя треугольника");
            Name = Console.ReadLine();
        }

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA > 0 && sideB > 0 && sideC > 0)
            {
                SideA = sideA;
                SideB = sideB;
                SideC = sideC;
            }
            else
            {
                throw new Exception("Сторона не может быть отрицательным числом");
            }
            CheckTriangle();
        }

        public void CheckTriangle()
        {
            if (SideA < SideB + SideC && SideB < SideA + SideC && SideC < SideA + SideB)
                Console.WriteLine("Такой треуголник может существовать");
            else
                throw new Exception("Треугольник с такими сторонами не может существовать");
        }

        public override double CalculateArea()
        {
            return (SideA + SideB + SideC)/2;
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

