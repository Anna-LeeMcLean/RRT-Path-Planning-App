///  Mech 540-A  :  Team-2 Project; Path finding using A* Algorithm
///
///  Name        :  Ajay Nalla
///  Student ID  :  49640014
///  Source file :  Rectangle.cs
///  Purpose     :  To create obstacle data
///  Description :  Contains classes 
///                 RectangleData: Constructor for creating rectangle co-ordinates
///

/// ************************* USINGS *************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Layout
{
    /// ************************* CLASSES *************************
    /// Class       : RectangleData
    /// Description : Contains contructor to create rectangle obstacle data
    public class RectangleData
    {
        public double X1;
        public double Y1;
        public double X2;
        public double Y2;
        public double X3;
        public double Y3;
        public double X4;
        public double Y4;

        /// ************************* METHOD *************************
        /// Method    : RectangleData
        /// Arguments : four doule values of top left and bottom right co-ordinates of the rectangle element
        /// Returns   : Nothing
        /// This method allocates the co-ordinate points of rectangle element.
        public RectangleData(double X1, double Y1, double X2, double Y2,double X3, double Y3, double X4, double Y4)
        {
            this.X1 = X1;
            this.X2 = X2;
            this.Y1 = Y1;
            this.Y2 = Y2;
            this.X3 = X3;
            this.Y3 = Y3;
            this.X4 = X4;
            this.Y4 = Y4;
        }
    }
}
