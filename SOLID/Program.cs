using System;

namespace SOLID
{
    // Marker interface (not required but kept for your structure)
    public interface IShape { }

    // Interface for shapes that have Area
    public interface IShape1 : IShape
    {
        double Area();
    }

    // Interface for shapes that have Volume
    public interface IShape2 : IShape
    {
        double Volume();
    }

    // Rectangle implements IShape1
    public class Rectangle : IShape1
    {
        public double Length;
        public double Width;

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public double Area()
        {
            return Length * Width;
        }
    }

    // Circle implements IShape1
    public class Circle : IShape1
    {
        public double Radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }

    // Square implements IShape1
    //Square is a type of Rectangle but it has same sides.Here child class cannot overide the method of parent class.
    //so we define a separate property for side which follows the Liskov substitution principle as Square can be used wherever Rectangle is expected, but it has its own specific implementation.
    public class Square : IShape1
    {
        public double Side;

        public Square(double side)
        {
            Side = side;
        }

        public double Area()
        {
            return Side * Side;
        }
    }

    // Cube implements IShape2
    //This follows the interface segregation principle as Cube is a 3D shape and has a different method for Volume

    public class Cube : IShape2
    {
        public double Side;

        public Cube(double side)
        {
            Side = side;
        }

        public double Volume()
        {
            return Side * Side * Side;
        }
    }
    // Abstractions for printers (DIP)
    public interface IAreaPrinter
    {
        void Print(IShape1 shape);
    }

    public interface IVolumePrinter
    {
        void Print(IShape2 shape);
    }
    // concrete class responsible for printing area.
    //This follows single responsibility principle as it only handles the printing of area for shapes that implement IShape1
    public class AreaPrinter : IAreaPrinter
    {
        public void Print(IShape1 shape)
        {
            Console.WriteLine($"{shape.GetType().Name} Area: {shape.Area()}");
        }
    }

    // concrete class responsible for printing volume
    public class VolumePrinter : IVolumePrinter
    {
        public void Print(IShape2 shape)
        {
            Console.WriteLine($"{shape.GetType().Name} Volume: {shape.Volume()}");
        }
    }
    //program depends on abstractions (interfaces) rather than concrete implementations, adhering to the Dependency Inversion Principle (DIP).
    internal class Program
    {
        static void Main(string[] args)
        {
            IShape1 rectangle = new Rectangle(5, 10);
            IShape1 circle = new Circle(7);
            IShape1 square = new Square(4);
            IShape2 cube = new Cube(3);

            IAreaPrinter areaPrinter = new AreaPrinter();
            areaPrinter.Print(rectangle);
            areaPrinter.Print(circle);
            areaPrinter.Print(square);

            IVolumePrinter volumePrinter = new VolumePrinter();
            volumePrinter.Print(cube);
        }
    }
}
