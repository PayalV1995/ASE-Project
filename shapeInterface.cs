using System; // Import the System namespace
using System.Collections.Generic; // Import the System.Collections.Generic namespace
using System.Drawing; // Import the System.Drawing namespace
using System.Linq; // Import the System.Linq namespace
using System.Text; // Import the System.Text namespace
using System.Threading.Tasks; // Import the System.Threading.Tasks namespace

namespace WindowsFormsApp2 // Declare the WindowsFormsApp2 namespace
{
    // Define an interface named shapeInterface
    interface shapeInterface
    {
        // Define a method named set that takes a variable number of integer parameters
        void set(params int[] list);

        // Define a method named setTriangle that takes integer parameters x and y, and an array of Point objects named points
        void setTriangle(int x, int y, Point[] points);

        // Define a method named Draw that takes Graphics object g, Pen object pen, and Brush object brush as parameters
        void Draw(Graphics g, Pen pen, Brush brush);
    }
}

