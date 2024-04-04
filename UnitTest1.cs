using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        // Test case for checking if two numbers are matched or not
        [TestMethod]
        public void TestIfStatements()
        {
            try
            {
                // Define two numbers and a comparison symbol
                int num = 25;
                int num2 = 35;
                string symbol = "=";

                // Check if the symbol is "="
                if (symbol == "=")
                {
                    // If symbol is "=", check if numbers are equal
                    if (num == num2)
                    {
                        // If numbers are equal, assert that they are equal with a delta
                        Assert.AreEqual(num, num2, 0.1, "Numbers are matched");
                    }
                    else
                    {
                        // If numbers are not equal, assert that they are not equal with a delta
                        Assert.AreNotEqual(num, num2, 0.1, "Numbers are not matched");
                    }
                }
            }
            catch (Exception)
            {
                // Handle exception if symbol is not correct
                Console.WriteLine("Symbol is not correct.");
            }
        }

        // Test case for setting parameters of a rectangle
        [TestMethod]
        public void TestSetRectangleParameters()
        {
            // Create an instance of DrawRectangle
            var rectangle = DrawShapeFactory.CreateShape("Rectangle");

            // Define parameters for rectangle
            int x = 200, y = 200, width = 100, height = 100;

            // Set parameters of rectangle
            rectangle.Set(x, y, width, height);

            // Assert that x-coordinate of rectangle is set correctly
            Assert.AreEqual(200, rectangle.X);
        }

        // Test case for setting parameters of a triangle
        [TestMethod]
        public void TestSetTriangleParameters()
        {
            // Create an instance of DrawTriangle
            var triangle = DrawShapeFactory.CreateShape("Triangle");

            // Define parameters for triangle
            int x = 200, y = 200, toX = 300, toY = 300;

            // Set parameters of triangle
            triangle.Set(x, y, toX, toY);

            // Assert that x-coordinate of triangle is set correctly
            Assert.AreEqual(200, triangle.X);
        }

        // Test case for setting parameters of a circle
        [TestMethod]
        public void TestSetCircleParameters()
        {
            // Create an instance of DrawCircle
            var circle = DrawShapeFactory.CreateShape("Circle");

            // Define parameters for circle
            int x = 200, y = 200, radius = 100;

            // Set parameters of circle
            circle.Set(x, y, radius);

            // Assert that y-coordinate of circle is set correctly
            Assert.AreEqual(200, circle.Y);
        }
    }

    // Factory class for creating shape instances
    public static class DrawShapeFactory
    {
        public static IDrawShape CreateShape(string shapeType)
        {
            switch (shapeType)
            {
                case "Rectangle":
                    return new DrawRectangle();
                case "Triangle":
                    return new DrawTriangle();
                case "Circle":
                    return new DrawCircle();
                default:
                    throw new ArgumentException("Invalid shape type");
            }
        }
    }

    // Interface for shape classes
    public interface IDrawShape
    {
        void Set(int x, int y, params int[] parameters);
    }

    // Concrete class for drawing rectangles
    public class DrawRectangle : IDrawShape
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public void Set(int x, int y, params int[] parameters)
        {
            if (parameters.Length != 2)
                throw new ArgumentException("Invalid number of parameters for rectangle");

            Width = parameters[0];
            Height = parameters[1];
            X = x;
            Y = y;
        }
    }

    // Concrete class for drawing triangles
    public class DrawTriangle : IDrawShape
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int ToX { get; private set; }
        public int ToY { get; private set; }

        public void Set(int x, int y, params int[] parameters)
        {
            if (parameters.Length != 2)
                throw new ArgumentException("Invalid number of parameters for triangle");

            ToX = parameters[0];
            ToY = parameters[1];
            X = x;
            Y = y;
        }
    }

    // Concrete class for drawing circles
    public class DrawCircle : IDrawShape
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Radius { get; private set; }

        public void Set(int x, int y, params int[] parameters)
        {
            if (parameters.Length != 1)
                throw new ArgumentException("Invalid number of parameters for circle");

            Radius = parameters[0];
            X = x;
            Y = y;
        }
    }
}
