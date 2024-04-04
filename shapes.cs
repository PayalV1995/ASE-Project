using System.Collections.Generic; // Import the System.Collections.Generic namespace
using System.Drawing; // Import the System.Drawing namespace
using System.Linq; // Import the System.Linq namespace
using System.Text; // Import the System.Text namespace
using System.Threading.Tasks; // Import the System.Threading.Tasks namespace

namespace WindowsFormsApp2 // Declare the WindowsFormsApp2 namespace
{
    // Define an abstract class named shapes that implements the shapeInterface interface
    public abstract class shapes : shapeInterface
    {
        // Declare protected integer variables x and y
        protected int x, y;

        // Constructor with parameters x and y
        public shapes(int x, int y)
        {
            // Initialize the x and y variables with the provided values
            this.x = x;
            this.y = y;
        }

        // Default constructor
        public shapes()
        {
        }

        // Virtual method to set the coordinates of the shape
        public virtual void set(params int[] list)
        {
            // Assign the first and second elements of the list to x and y respectively
            this.x = list[0];
            this.y = list[1];
        }

        // Virtual method to set the coordinates of a triangle
        public virtual void setTriangle(int x, int y, Point[] points)
        {
            // Set the x and y coordinates of the triangle
            this.x = x;
            this.y = y;
        }

        // Abstract method to draw the shape
        public abstract void Draw(Graphics g, Pen pen, Brush brush);

        // Override the ToString method to return the coordinates of the shape
        public override string ToString()
        {
            return base.ToString() + "    " + this.x + "," + this.y + " : ";
        }
    }
}

