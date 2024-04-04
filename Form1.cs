using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        private int x = 0, y = 0;

        //for partition
        private string[] splitw;
        private string[] parm = new string[50];
        private int[] strSplit = new int[50];
        private int[] strError = new int[50];

        //looping 
        private int loopmax;
        private int loopstart;
        private int loopfinish;
        private int loopcount;
        private int errorno = 0;


        //flag bits
        private bool lbit = false;
        private bool ifrslt = false;
        private bool strif = false;
        private bool condn = false;

        //universal colour
        private Color pencolor = Color.Black;
        private Color brushcolor = Color.Cyan;
        private Random rndm = new Random();

        //Shape Factory
        private shapes shape1;
        private ShapeFactory factory = new ShapeFactory();


        public Form1()
        {
            InitializeComponent();
            display.Image = new Bitmap(Size.Width, Size.Height);

        }



        private void button2_Click(object sender, EventArgs e) //save what is in the richtextbox
        {
            MemoryStream userInput = new MemoryStream(Encoding.UTF8.GetBytes(ControlePanel.Text));

            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = "txt";
            save.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult result = save.ShowDialog();
            Stream fileStream;

            if (result == DialogResult.OK)
            {

                fileStream = save.OpenFile();
                userInput.Position = 0;
                userInput.WriteTo(fileStream);
                fileStream.Close();
                userInput.Close();

            }
            save.Dispose();
        }




        private void button3_Click(object sender, EventArgs e)
        {
            String input = ControlePanel.Text;
            if (input.Trim() == "")
            {
                MessageBox.Show("Enter a command", "ERROR");

            }
            else
            {
                String[] line;
                String[] lines;
                ArrayList Currentline = new ArrayList();
                int i = 0;
                lines = ControlePanel.Lines.ToArray();
                while (lines.Length != i)
                {

                    line = lines[i].Split(' ');
                    Currentline.Add(line);
                    i++;
                }
                int length = lines.Length;

                Check(Currentline, lines, length);
                int L = 0;
                Array.Clear(parm, 0, parm.Length);//used to clear the vars array before exicution
                Array.Clear(strSplit, 0, strSplit.Length);
                string errors = string.Join(", ", strError.Where(x => x != 0));


                if (condn == false)
                {

                    MessageBox.Show("Error Occur in Line no. :" + errors + ".", "error");
                }
                else
                {

                    excecuteCommand(Currentline, lines, length);
                }

            }

        }



        private void button4_Click(object sender, EventArgs e)
        {

            ControlePanel.Text = "";
            commandline.Text = "";
        }






        public void excecuteCommand(ArrayList Currentline, string[] lines, int linecount)
        {


            int counter = 0;
            int jump = 0;


            while (lines.Length >= counter)
            {
                Graphics g = Graphics.FromImage(display.Image);
                Pen pen = new Pen(pencolor, 2);
                Brush brush = new SolidBrush(brushcolor);

                try
                {
                    if (jump != 0)
                    {
                        if (jump == counter)
                        {
                            counter++;
                            jump = 0;
                        }
                    }

                    splitw = (String[])Currentline[counter];


                    switch (splitw[0].ToLower())
                    {
                        case "circle":

                            int radius;
                            if (!int.TryParse(splitw[1], out radius))
                            {

                                radius = varCall((string)splitw[1]);
                                new DrawCircle(x, y, radius).Draw(g, pen, brush);
                            }
                            else if (int.TryParse(splitw[1], out radius))
                            {
                                int.TryParse(splitw[1], out radius);
                                new DrawCircle(x, y, radius).Draw(g, pen, brush);
                            }
                            else
                            {
                                MessageBox.Show("enter a radius or use a variable", "error");
                            }
                            break;
                        case "rect":

                            int width;

                            int height;
                            if (!int.TryParse(splitw[1], out width) || !int.TryParse(splitw[2], out height))
                            {
                                width = varCall(splitw[1]);
                                height = varCall(splitw[2]);
                                new DrawRectangle(x, y, width, height).Draw(g, pen, brush);

                            }
                            else
                            {
                                int.TryParse(splitw[1], out width);
                                int.TryParse(splitw[2], out height);
                                new DrawRectangle(x, y, width, height).Draw(g, pen, brush);
                            }
                            break;
                        case "square":
                            int side;
                            if (!int.TryParse(splitw[1], out side))
                            {
                                side = varCall(splitw[1]);
                                new DrawSquare(x, y, side).Draw(g, pen, brush);
                            }
                            else
                            {
                                int.TryParse(splitw[1], out side);
                                new DrawSquare(x, y, side).Draw(g, pen, brush);
                            }

                            break;
                        case "drawto":
                            int point1, point2;
                            if (!int.TryParse(splitw[1], out point1) || !int.TryParse(splitw[2], out point2))
                            {
                                point1 = varCall(splitw[1]);
                                point2 = varCall(splitw[2]);
                                g.DrawLine(pen, x, y, point1, point1);

                            }
                            else
                            {
                                int.TryParse(splitw[1], out point1);
                                int.TryParse(splitw[2], out point2);
                                g.DrawLine(pen, x, y, point1, point2);

                            }
                            break;
                        case "pen":
                            try
                            {
                                if (splitw[1] != "rand")
                                {
                                    pencolor = Color.FromName(splitw[1]);
                                }
                                else
                                {
                                    pencolor = Color.FromArgb(rndm.Next(256), rndm.Next(256), rndm.Next(256));
                                }
                            }
                            catch
                            {
                                pencolor = Color.Black;
                            }
                            break;
                        case "brush":
                            try
                            {
                                if (splitw[1] != "rand")
                                {
                                    brushcolor = Color.FromName(splitw[1]);
                                }
                                else
                                {
                                    brushcolor = Color.FromArgb(rndm.Next(256), rndm.Next(256), rndm.Next(256));

                                }

                            }
                            catch
                            {
                                brushcolor = Color.Black;
                            }
                            break;
                        case "triangle":
                            int p1, p2, p3;

                            if (!int.TryParse(splitw[1], out p1) || !int.TryParse(splitw[2], out p2) || !int.TryParse(splitw[3], out p3))
                            {
                                p1 = varCall(splitw[1]);
                                p2 = varCall(splitw[2]);
                                p3 = varCall(splitw[3]);
                                System.Drawing.Point pointa1 = new System.Drawing.Point(p1, p2);
                                System.Drawing.Point pointb1 = new System.Drawing.Point(p2, p3);
                                System.Drawing.Point pointc1 = new System.Drawing.Point(p3, p1);

                                System.Drawing.Point[] pnt1 = { pointa1, pointb1, pointc1 };
                                new DrawTriangle(pnt1).Draw(g, pen, brush);
                            }
                            else
                            {
                                int.TryParse(splitw[1], out p1);
                                int.TryParse(splitw[2], out p2);
                                int.TryParse(splitw[3], out p3);
                                System.Drawing.Point pointa1 = new System.Drawing.Point(p1, p2);
                                System.Drawing.Point pointb1 = new System.Drawing.Point(p2, p3);
                                System.Drawing.Point pointc1 = new System.Drawing.Point(p3, p1);

                                System.Drawing.Point[] pnt1 = { pointa1, pointb1, pointc1 };
                                new DrawTriangle(pnt1).Draw(g, pen, brush);
                            }
                            break;
                        case "clear":
                            g.Clear(Color.Transparent);
                            g.Dispose();
                            break;

                        case "moveto":

                            if (int.TryParse(splitw[1], out x) && int.TryParse(splitw[2], out y))
                            {
                                int.TryParse(splitw[1], out x);
                                int.TryParse(splitw[2], out y);
                            }
                            else
                            {
                                x = varCall(splitw[1]);
                                y = varCall(splitw[2]);
                            }

                            break;

                        case "var":
                            VarCheck(splitw[1], splitw[2]);
                            break;

                        case "loop":
                            lbit = true;
                            loopmax = 0;
                            loopcount = 0;
                            loopstart = counter;

                            if (int.TryParse(splitw[1], out loopmax))
                            {
                                int.TryParse(splitw[1], out loopmax);
                            }
                            else
                            {
                                loopmax = varCall(splitw[1]);
                            }

                            if (lines[counter] == "end" && loopcount != loopmax)
                            {
                                counter = loopfinish;
                                lbit = false;
                                break;
                            }
                            else if (lines[counter] == "end" && loopcount != loopmax)
                            {
                                loopcount++;
                                loopfinish = counter++;
                                counter = loopstart;
                                counter++;
                                break;

                            }
                            else
                            {
                                loopcount++;
                                break;
                            }
                        case "end":
                            if (loopcount == loopmax || loopcount > loopmax)
                            {

                            }
                            else
                            {
                                counter = loopstart;
                            }


                            break;
                        case "num":

                            x = rndm.Next(display.Width);
                            y = rndm.Next(display.Height);


                            brushcolor = Color.FromArgb(rndm.Next(256), rndm.Next(256), rndm.Next(256));
                            pencolor = Color.Black;

                            shape1 = factory.getShape(splitw[1]);
                            if (splitw[1].ToLower().Trim() == "circle")
                            {
                                radius = rndm.Next(Size.Width / 4);
                                shape1.set(x, y, radius);
                            }
                            else if (splitw[1].ToLower().Trim() == "rectangle")
                            {
                                width = rndm.Next(display.Width);
                                height = rndm.Next(display.Height);
                                shape1.set(x, y, width, height);
                            }
                            else if (splitw[1].ToLower().Trim() == "triangle")
                            {
                                p1 = rndm.Next(display.Width);
                                p2 = rndm.Next(display.Width);
                                p3 = rndm.Next(display.Width);
                                System.Drawing.Point pointa = new System.Drawing.Point(p1, p2);
                                System.Drawing.Point pointb = new System.Drawing.Point(p2, p3);
                                System.Drawing.Point pointc = new System.Drawing.Point(p3, p1);
                                System.Drawing.Point[] pnt = { pointa, pointb, pointc };
                                shape1.setTriangle(x, y, pnt);
                            }
                            shape1.Draw(g, pen, brush);
                            display.Refresh();
                            break;
                        case "if":
                            int left;
                            int right;
                            string condition;
                            if (splitw.Length > 4)
                            {
                                MessageBox.Show("need more input", "Error");
                            }
                            else
                            {
                                if (!int.TryParse(splitw[1], out left))
                                {
                                    left = varCall(splitw[1]);
                                }
                                else
                                {
                                    int.TryParse(splitw[1], out left);
                                }

                                if (!int.TryParse(splitw[3], out right))
                                {
                                    right = varCall(splitw[3]);
                                }
                                else
                                {
                                    int.TryParse(splitw[3], out right);
                                }
                                condition = splitw[2];
                                ifcheck(left, condition, right);
                                if (ifrslt == true)
                                {

                                    jump = counter;
                                    jump++;
                                    jump++;



                                    break;
                                }
                                else
                                {

                                    counter++;

                                }




                            }

                            break;
                        case "endif":
                            jump = 0;
                            strif = false;
                            break;


                        default:
                            if (splitw[0].Trim() == null)
                            {

                            }
                            else
                            {
                                int i = 0;
                                if (parm[0] != null)
                                {
                                    while (49 >= i)
                                    {
                                        if (parm[i] == splitw[0])
                                        {
                                            //  MessageBox.Show(element[0] + " called", "whoop");
                                            if (!int.TryParse(splitw[1], out strSplit[i]))
                                            {
                                                MessageBox.Show(splitw[0] + "is all ready set to " + splitw[1], "info");
                                            }
                                            else
                                            {
                                                int.TryParse(splitw[1], out strSplit[i]);
                                                MessageBox.Show(splitw[0] + " variable is set to " + splitw[1], "info");
                                            }
                                            i = 50;
                                        }
                                        else if (i != parm.Length)
                                        {
                                            i++;
                                        }

                                    }
                                }
                                else
                                {
                                    MessageBox.Show(splitw[0] + " not a Command", "Messgae");
                                }
                            }
                            break;

                    }
                    if (lbit == true)
                    {
                        loopcount++;
                    }
                    display.Refresh();

                }
                catch
                {
                }
                pen.Dispose();
                brush.Dispose();


                counter++;
            }



        }


        private bool ifcheck(int left, string condition, int right) // used to check if sattment 
        {
            switch (condition)
            {

                case "=":
                    if (left == right)
                    {
                        ifrslt = true;
                    }
                    else
                    {
                        ifrslt = false;
                    }
                    break;
                case ">":
                    if (left > right)
                    {
                        ifrslt = true;
                    }
                    else
                    {
                        ifrslt = false;
                    }

                    break;
                case "<":
                    if (left < right)
                    {
                        ifrslt = true;
                    }
                    else
                    {
                        ifrslt = false;
                    }

                    break;
                case "!":
                    if (left != right)
                    {
                        ifrslt = true;
                    }
                    else
                    {
                        ifrslt = false;
                    }

                    break;

                default:
                    MessageBox.Show("condition is not correct please check", "error");

                    break;

            }

            return ifrslt;
        }




        private void VarCheck(string element1, string element2)
        {
            try
            {
                bool variableExists = false;
                int index = 0;

                // Check if the variable already exists
                while (index < parm.Length && parm[index] != null)
                {
                    if (parm[index].Equals(element1))
                    {
                        variableExists = true;
                        break;
                    }
                    index++;
                }

                if (variableExists)
                {
                    MessageBox.Show("Variable already declared", "Error");
                }
                else
                {
                    // Find an empty slot or the first null element
                    index = 0;
                    while (index < parm.Length && parm[index] != null)
                    {
                        index++;
                    }

                    if (index < parm.Length)
                    {
                        parm[index] = element1;
                        int.TryParse(element2, out strSplit[index]);
                    }
                    else
                    {
                        MessageBox.Show("Reached maximum variable limit", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }

        private int varCall(string variable)
        {
            int i = 0;
            int number = -1;
            while (49 >= i)
            {
                if (parm[i] == variable)
                {

                    number = strSplit[i];
                    i = 50;
                }
                else
                {
                    i++;
                }

            }
            if (number == 0)
            {
                MessageBox.Show("not a variable", "error");
            }
            return number;

        }

        private void Commandline_KeyDown(object sender, KeyEventArgs e) //used to run the program
        {
            if (e.KeyCode == Keys.Enter)
            {

                String txtdata = commandline.Text;
                if (txtdata.Trim() == "")
                {
                    MessageBox.Show("Kindly enter any command first", "ERROR");

                }
                else
                {
                    String[] line;
                    String[] lines;
                    ArrayList Currentline = new ArrayList();
                    int i = 0;
                    if (txtdata.ToLower().Trim() == "run")
                    {
                        lines = ControlePanel.Lines.ToArray();
                        while (lines.Length != i)
                        {

                            line = lines[i].Split(' ');
                            Currentline.Add(line);
                            i++;
                        }

                    }
                    else
                    {
                        lines = commandline.Lines.ToArray();
                        line = commandline.Text.Split(' ');
                        Currentline.Add(line);


                    }
                    int length = lines.Length;

                    Check(Currentline, lines, length);
                    int L = 0;
                    Array.Clear(parm, 0, parm.Length);//used to cleare the vars array befreo exicution
                    Array.Clear(strSplit, 0, strSplit.Length);
                    string errors = string.Join(", ", strError.Where(x => x != 0));


                    if (condn == false)
                    {

                        MessageBox.Show("Errors on lines :" + errors + ".", "error");
                    }
                    else
                    {

                        excecuteCommand(Currentline, lines, length);
                    }


                }
            }


        }

        public void Check(ArrayList currentline, string[] lines, int length)// checks the syntax of the user input
        {
            int count = 0;
            int errors = 0;
            errorno = 0;
            condn = true;
            int k = 0;
            int linenumber = 0;


            while (lines.Length >= count)
            {

                errors = errorno;
                try
                {
                    splitw = (String[])currentline[count];


                    switch (splitw[0].ToLower())
                    {
                        case "circle":
                            if (splitw.Length != 2)
                            {
                                errorno++;
                            }

                            break;

                        case "rect":
                            if (splitw.Length != 3)
                            {
                                errorno++;
                            }

                            break;

                        case "square":
                            if (splitw.Length != 3)
                            {
                                errorno++;
                            }
                            break;

                        case "drawto":
                            if (splitw.Length != 3)
                            {
                                errorno++;
                            }

                            break;
                        case "pen":
                            if (splitw.Length != 2)
                            {
                                errorno++;
                            }
                            break;
                        case "brushcolor":
                            if (splitw.Length != 2)
                            {
                                errorno++;
                            }
                            break;
                        case "triangle":
                            if (splitw.Length != 4)
                            {
                                errorno++;
                            }

                            break;
                        case "clear":


                            break;
                        case "movex":
                            if (splitw.Length != 2)
                            {
                                errorno++;
                            }

                            break;
                        case "movey":
                            if (splitw.Length != 2)
                            {
                                errorno++;
                            }

                            break;
                        case "moveto":
                            if (splitw.Length != 3)
                            {
                                errorno++;
                            }


                            break;

                        case "var":

                            if (splitw.Length != 3)
                            {
                                errorno++;
                            }
                            else
                            {
                                VarCheck(splitw[1], splitw[2]);
                            }

                            break;

                        case "loop":
                            if (splitw.Length != 2)
                            {
                                errorno++;
                            }
                            break;
                        case "end":
                            if (splitw.Length != 1)
                            {
                                errorno++;
                            }
                            break;
                        case "factory":
                            if (splitw.Length != 2)
                            {
                                errorno++;
                            }

                            break;
                        case "if":
                            if (splitw.Length != 4)
                            {
                                errorno++;
                            }

                            break;
                        case "endif":
                            if (splitw.Length != 1)
                            {
                                errorno++;
                            }
                            break;
                        default:
                            if (splitw[0].Trim() == null)
                            {

                            }
                            else
                            {
                                int i = 0;
                                if (parm[0] != null)
                                {
                                    while (49 >= i)
                                    {
                                        if (parm[i] == splitw[0])
                                        {
                                            //  MessageBox.Show(element[0] + " called", "whoop");
                                            if (!int.TryParse(splitw[1], out strSplit[i]))
                                            {
                                                MessageBox.Show(splitw[0] + "is all ready set to " + splitw[1], "whoop");
                                            }
                                            else
                                            {
                                                int.TryParse(splitw[1], out strSplit[i]);
                                                MessageBox.Show(splitw[0] + " variable is set to " + splitw[1], "whoop");
                                            }
                                            i = 50;
                                        }
                                        else if (i != parm.Length)
                                        {
                                            i++;
                                        }

                                    }
                                }
                                else
                                {
                                    errorno++;
                                }
                            }
                            break;


                    }
                    if (errors != errorno)
                    {
                        linenumber = count;
                        linenumber++;
                        strError[k] = linenumber;
                        k++;
                        errors++;


                    }
                }
                catch
                {

                }
                count++;
                if (errorno != 0)
                {
                    condn = false;
                }
                else
                {
                    condn = true;
                }
            }

        }





    }
}
