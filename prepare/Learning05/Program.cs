using System;

class Program
{
    static void Main(string[] args)
    {

        List<Shape> _shapes= new List<Shape>();

        Square square = new Square(5, "Blue");
        Rectangle rectangle = new Rectangle (4, 3, "Red");
        Circle circle = new Circle(3, "Green");

        _shapes.Add(square);
        _shapes.Add(rectangle);
        _shapes.Add(circle);

        foreach (var shape in _shapes)
        {
            double area = shape.GetArea();
            string color = shape.GetColor();

            Console.WriteLine($"The color {color} has the shape area of {area}.");
            Console.WriteLine();
        }
    }
}