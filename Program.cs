using System;
using System.Runtime.ExceptionServices;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");

            int functionchoice = 1; //1 for first function, 2 for second function

            Swarm swarm1 = new Swarm();
            swarm1.N = 1000; //number of particles
            swarm1.M = 1000; //number of iterations for updating the velocities and positions of particles in each PSO instance
            swarm1.W = 0.001; //small weight gets better convergence

            //-----------------------------------------------------------------------------------------------------------------------------------------------------------
            //run a single instance

            Vector output = swarm1.PSO(functionchoice);

            Console.WriteLine("Single Instance:");
            Console.Write("Position of minimum (x, y) = (");
            Console.Write(output[0]);
            Console.Write(", ");
            Console.Write(output[1]);
            Console.Write(")");
            Console.WriteLine("");
        }
    }
}
