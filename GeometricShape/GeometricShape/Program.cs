using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricShape
{
    interface ISide
    {
        int Length { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }

   public class Side : ISide
    {

        public int Length { get; set; }
        public Side(int length)
        {
            Length = length;
        }
    }

    abstract class Shape
    {
        public Side lengt {get;set;}
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public virtual void CalculateArea() { }
        public virtual void CalculatePerimeter() { }
    }

    class Circle : Shape
    {
        public static readonly string Name;
        public double Radius { get; private set; }


        static Circle()
        {
            Console.WriteLine("Введите имя круга:");
            Name = Console.ReadLine();
        }

        public Circle(double radius)
        {
            if (radius > 0)
                Radius = radius;
            else
                throw new Exception("Не может быть отрицательное значение радиуса");
        }

        public override void CalculateArea()
        {
            Area = Radius * Radius * Math.PI;
        }

        public override void CalculatePerimeter()
        {
            Perimeter = 2 * Math.PI * Radius;
        }

    }

    class Rectangle : Shape
    {
        Dictionary<char, ISide> side = new Dictionary<char, ISide>();

        public static readonly string Name;

        static Rectangle()
        {
            Console.WriteLine("Введите имя круга:");
            Name = Console.ReadLine();
        }


        public Rectangle(ISide a, int length)
        {
            if (length > 0)
                side.Add('a', new Side(length));
            else
                throw new Exception("Длина стороны не может быть отрицательным числом");
        }

        public Rectangle(ISide a, ISide b, int length, int width)
        {
            if (length > 0 && width > 0)
            {
                side.Add('a', new Side(length));
                side.Add('b', new Side(width));
            }
            else
                throw new Exception("Длинна не может быть отрицательным числом");
        }

            

        public override void CalculateArea()
        {
            Area = a.Length * a.Length;
        }
        public  void CalculateArea(ISide a, ISide b)
        {
            Area = a.Length * b.Length;
        }

        public override void CalculatePerimeter(ISide a)
        {
            Perimeter = a.Length * 4;
        }

        public override void CalculatePerimeter(ISide a, ISide b)
        {
            Perimeter = (a.Length + b.Length) * 2;
        }

    }


    class Triangle : Shape
    {
        public static readonly string Name;
        Dictionary<char, ISide> side = new Dictionary<char, ISide>();

        static Triangle()
        {
            Console.WriteLine("Введите имя круга:");
            Name = Console.ReadLine();
        }

        public Triangle(ISide a ,int length)
        {
            if (length > 0)
                side.Add('a', new Side(length));
            else
                throw new Exception("Сторона не может быть отрицательным числом");
        }

        public Triangle(ISide a, ISide b, ISide c, int a_length, int b_length, int c_length)
        {
            if (a_length > 0 && b_length > 0 && c_length > 0)
            {
                side.Add('a', new Side(a_length));
                side.Add('b', new Side(b_length));
                side.Add('c', new Side(c_length));
            }
            else
                throw new Exception("Сторона не может быть отрицательным числом");
        }

        public void CheckTriangle(ISide a, ISide b, ISide c)                                // проверка на возможность существования
        {
            if (a.Length < b.Length + c.Length && b.Length < a.Length + c.Length && c.Length < a.Length + b.Length)
                Console.WriteLine("Такой треугольник может сущестовать");
            else
                throw new Exception("Треугольник с такими сторонами существовать не может");
        }
       
    }


}
