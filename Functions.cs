using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Functions
    {
        //functions
        public static double function(int functionchoice, double x, double y, double z = 0)
        {
            //--------------------------------------------------------------
            //first function
            double f1 = (x - 1) * (x - 1) + 10 * (x * x - y) * (x * x - y);

            //second function
            double f2 = x * (Math.Exp(-(x * x + y * y)));

            //--------------------------------------------------------------
            double f = 0;

            if (functionchoice == 1)
            {
                f = f1;
            }
            else if (functionchoice == 2)
            {
                f = f2;
            }

            return f;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //domains of functions
        public static Vector functionDomains(int functionchoice)
        {
            //[lower x bound, upper x bound, lower y bound, upper y bound]

            Vector bounds = new Vector(4);

            //domain for first function
            if (functionchoice == 1)
            {
                bounds[0] = -1;
                bounds[1] = 1.5;
                bounds[2] = -1;
                bounds[3] = 1.5;
            }

            //domain for second function
            else if (functionchoice == 2)
            {
                bounds[0] = -2;
                bounds[1] = 2;
                bounds[2] = -2;
                bounds[3] = 2;
            }
            return bounds;
        }
    }
}
