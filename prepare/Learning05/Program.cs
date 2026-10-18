using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("Red", 3);
        Console.WriteLine($"{square.GetColor()} square area: {square.GetArea()}");

        Rectangle rectangle = new Rectangle("Blue", 4, 5);
        Console.WriteLine($"{rectangle.GetColor()} rectangle area: {rectangle.GetArea()}");

        Circle circle = new Circle("Green", 2);
        Console.WriteLine($"{circle.GetColor()} circle area: {circle.GetArea()}");

        Console.WriteLine();

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}
