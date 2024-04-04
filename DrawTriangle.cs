using System;
using System.Drawing;

namespace WindowsFormsApp2
{
    // Define a class named DrawTriangle that inherits from the shapes class
    public class DrawTriangle : shapes
    {
        // Declare a private field to store the points of the triangle
        private Point[] points;

        // Constructor with parameters for the points of the triangle
        public DrawTriangle(Point[] points)
        {
            // Initialize the points field with the provided points
            this.points = points;
        }

        // Default constructor
        public DrawTriangle()
        {
        }

        // Method to set the triangle with specified coordinates and points
        public override void setTriangle(int x, int y, Point[] points)
        {
            // Call the set method of the base class to set the coordinates
            base.set(x, y);
            // Set the points of the triangle
            this.points = points;
        }

        // Override the Draw method to draw the triangle
        public override void Draw(Graphics g, Pen pen, Brush brush)
        {
            // Draw the polygon defined by the points
            g.DrawPolygon(pen, points);
            // Fill the polygon with the specified brush
            g.FillPolygon(brush, points);
        }
    }
}

