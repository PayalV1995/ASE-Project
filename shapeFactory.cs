using System;
using WindowsFormsApp2;

namespace ShapeFactoryNamespace
{
    // Define a class named ShapeFactory
    public class ShapeFactory
    {
        // Define a public method named GetShape that returns a shapes object based on the provided shapeType
        public shapes GetShape(string shapeType)
        {
            // Convert the shapeType to lowercase and trim any leading or trailing whitespace
            shapeType = shapeType.ToLower().Trim();

            // Use a switch statement to determine which shape to create based on the shapeType
            switch (shapeType)
            {
                case "circle":
                    // If shapeType is "circle", return a new DrawCircle object
                    return new DrawCircle();
                case "rect":
                    // If shapeType is "rect", return a new DrawRectangle object
                    return new DrawRectangle();
                case "triangle":
                    // If shapeType is "triangle", return a new DrawTriangle object
                    return new DrawTriangle();
                default:
                    // If shapeType is not recognized, throw an ArgumentException
                    throw new ArgumentException($"Factory Exception occur: {shapeType} is not available");
            }
        }
    }
}

