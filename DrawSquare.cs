using System;
using System.Drawing;

namespace WindowsFormsApp2
{
    // Define a class named DrawSquare that inherits from the DrawRectangle class
    public class DrawSquare : DrawRectangle
    {
        // Declare a readonly field to store the size of the square
        readonly int size;

        // Constructor with parameters for x-coordinate, y-coordinate, and size
        public DrawSquare(int x, int y, int size) : base(x, y, size, size)
        {
            // Initialize the size field with the provided value
            this.size = size;
        }

        // Override the Draw method to draw the square
        public override void Draw(Graphics g, Pen pen, Brush brush)
        {
            // Call the Draw method of the base class (DrawRectangle) to draw the square
            base.Draw(g, pen, brush);
        }
    }
}
