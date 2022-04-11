using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// This program implements calculator with a GUI
/// </summary>
/// <Student>Joseph Smiley</Student>
/// <Class>CIS 297</Class>
/// <Semester>Winter 2022</Semester>
/// 
namespace CalculatorGUI
{
    /// <summary>
    /// Implementations for the different calculator functions
    /// </summary>
    public partial class CalculatorGUIForm : Form
   {
        public CalculatorGUIForm()
        {
           InitializeComponent();
        }
        /// <summary>
        /// remove whitespace
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            outputText.Clear();
            string charArray = inputText.Text;
            outputText.Text = charArray.Replace(" ", "");
            inputText.Clear();
        }
        /// <summary>
        /// reverses a string
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            outputText.Clear();
            char[] charArray = inputText.Text.ToCharArray();
            Array.Reverse(charArray);
            outputText.Text = String.Concat(charArray);
            inputText.Clear();
        }
        /// <summary>
        /// outputs the remainder and the quotient of 2 numbers
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            outputText.Clear();
            char[] charArray = inputText.Text.ToCharArray();
            int numer = int.Parse(charArray[0].ToString());
            int denom = int.Parse(charArray[2].ToString());
            int rem;
            int quotient = Math.DivRem(numer, denom, out rem);
            outputText.Text = "Quotient = " + quotient + " Remainder = " + rem;
            inputText.Clear();
        }
        /// <summary>
        /// finds the log base 10 of x
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            outputText.Clear();
            double log10Num = double.Parse(inputText.Text);
            outputText.Text = "" + Math.Log10(log10Num);
            inputText.Clear();
        }
        /// <summary>
        /// finds the log base x of y
        /// </summary>
        private void button5_Click(object sender, EventArgs e)
        {
            outputText.Clear();
            char[] charArray = inputText.Text.ToCharArray();
            double num = double.Parse(charArray[0].ToString());
            double logbase = double.Parse(charArray[2].ToString());
            outputText.Text = "" + Math.Log(num, logbase); ;
            inputText.Clear();
        }
        /// <summary>
        /// displays the min and max of 2 numbers
        /// </summary>
        private void button6_Click(object sender, EventArgs e)
        {
            outputText.Clear();
            char[] charArray = inputText.Text.ToCharArray();
            double number1 = double.Parse(charArray[0].ToString());
            double number2 = double.Parse(charArray[2].ToString());
            outputText.Text = "Min = " + Math.Min(number1, number2) + " Max = " + Math.Max(number1, number2);
            inputText.Clear();
        }
        /// <summary>
        /// takes a number to the power of a another number
        /// </summary>
        private void button7_Click(object sender, EventArgs e)
        {
            outputText.Clear();
            char[] charArray = inputText.Text.ToCharArray();
            double number1 = double.Parse(charArray[0].ToString());
            double number2 = double.Parse(charArray[2].ToString());
            outputText.Text = "" + Math.Pow(number1, number2);
            inputText.Clear();
        }
        /// <summary>
        /// computes roots of a quadratic equation
        /// </summary>
        private void button8_Click(object sender, EventArgs e)
        {
            outputText.Clear();
            char[] charArray = inputText.Text.ToCharArray();
            int A = int.Parse(charArray[0].ToString());
            int B = int.Parse(charArray[2].ToString());
            int C = int.Parse(charArray[4].ToString());
            QuadraticEquation1 quad = new QuadraticEquation1(A, B, C);
            quad.ComputeDisc();
            quad.ComputeSolution();
            outputText.Text = quad.DisplaySolution();
            inputText.Clear();
        }
        /// <summary>
        /// computes square root of a number
        /// </summary>
        private void button9_Click(object sender, EventArgs e)
        {
            outputText.Clear();
            double num = double.Parse(inputText.Text);
            outputText.Text = "" + Math.Sqrt(num);
            inputText.Clear();
        }
        /// <summary>
        /// exits application
        /// </summary>
        private void button10_Click(object sender, EventArgs e)
        {
            outputText.Clear();
            Application.Exit();
            inputText.Clear();
        }
    }
    /// <summary>
     /// class to handle quadratic equations
     /// </summary>
    class QuadraticEquation1
    {
        int A;
        int B;
        int C;
        double Discriminant;
        double X1;
        double X2;
        Boolean status = true;
        /// <summary>
        /// Creates the new quadratic equation object
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public QuadraticEquation1(int a, int b, int c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        /// <summary>
        /// Finds the discriminant of the quadratic equation and returns it
        /// </summary>
        public double ComputeDisc()
        {
            Discriminant = Math.Pow(B, 2) - 4 * A * C;
            return Discriminant;
        }

        /// <summary>
        /// Finds the roots of the quadratic equation using the discriminant and the A, B, and C values
        /// </summary>
        public void ComputeSolution()
        {
            if (Discriminant == 0)
            {
                X1 = -B / (2 * A);
                X2 = X1;
            }
            else if (Discriminant > 0)
            {
                X1 = (-B + Math.Sqrt(Discriminant)) / (2 * A);
                X2 = (-B - Math.Sqrt(Discriminant)) / (2 * A);
            }
            else
            {
                status = false;
            }
        }
        public string DisplaySolution()
        {
            if (X1 == X2)
            {
                return X1.ToString();
            }
            else
            {
                return X1 + " " + X2;
            }
        }
    }
}

/**************************************************************************
 * (C) Copyright 1992-2017 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/