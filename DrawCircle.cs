using System;
using System.Drawing;

namespace WindowsFormsApp2
{
    // Define a class named DrawCircle that inherits from the shapes class
    public class DrawCircle : shapes
    {
        // Declare a private field to store the radius of the circle
        private int radius;

        // Constructor with parameters for x-coordinate, y-coordinate, and radius
        public DrawCircle(int x, int y, int radius) : base(x, y)
        {
            // Initialize the radius field with the provided value
            this.radius = radius;
        }

        // Constructor with parameter for radius
        public DrawCircle(int radius)
        {
            // Initialize the radius field with the provided value
            this.radius = radius;
        }

        // Default constructor
        public DrawCircle() : base()
        {
            // No additional initialization is needed
        }

        // Override the Draw method to draw a circle
        public override void Draw(Graphics g, Pen pen, Brush brush)
        {
            // Fill and draw an ellipse with the specified dimensions
            g.FillEllipse(brush, x, y, radius * 2, radius * 2);
            g.DrawEllipse(pen, x, y, radius * 2, radius * 2);
        }

        // Override the set method to set the parameters of the circle
        public override void set(params int[] list)
        {
            // Call the base class set method to set the x-coordinate and y-coordinate
            base.set(list[0], list[1]);

            // Set the radius of the circle
            this.radius = list[2];
        }

        // Override the ToString method to return a string representation of the circle
        public override string ToString()
        {
            // Return the string representation of the base class along with the radius
            return base.ToString() + "  " + this.radius;
        }
    }
}
