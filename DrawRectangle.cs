using System;
using System.Drawing;

namespace WindowsFormsApp2
{
    // Define a class named DrawRectangle that inherits from the shapes class
    public class DrawRectangle : shapes
    {
        // Declare private fields to store the width and height of the rectangle
        private int width;
        private int height;

        // Constructor with parameters for x-coordinate, y-coordinate, width, and height
        public DrawRectangle(int x, int y, int width, int height) : base(x, y)
        {
            // Initialize the width and height fields with the provided values
            this.width = width;
            this.height = height;
        }

        // Default constructor
        public DrawRectangle() { }

        // Override the set method to set the parameters of the rectangle
        public override void set(params int[] list)
        {
            // Call the base class set method to set the x-coordinate and y-coordinate
            base.set(list[0], list[1]);

            // Set the width and height of the rectangle
            this.width = list[2];
            this.height = list[3];
        }

        // Override the Draw method to draw a rectangle
        public override void Draw(Graphics g, Pen pen, Brush brush)
        {
            // Fill and draw a rectangle with the specified dimensions
            g.FillRectangle(brush, x, y, width, height);
            g.DrawRectangle(pen, x, y, width, height);
        }
    }
}
