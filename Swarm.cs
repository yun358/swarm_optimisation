using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class Swarm
    {
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //weight
        private double w = 0.4;
        public double W   // property
        {
            get { return w; }   // get method
            set { w = value;}  // set method   
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //particle acceleration coefficient
        private double c_p = 2;
        public double C_P
        {
            get { return c_p; }
            set { c_p = value; }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //swarm acceleration coefficient
        private double c_s = 1.5;
        public double C_S
        {
            get { return c_s; }
            set { c_s = value; }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //best position in the swarm until this point (minimum)
        private Vector s_best = new Vector(); 
        public Vector S_BEST
        {
            get { return s_best; }
            set { s_best = new Vector(value); }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //number of steps to take in the algorithm
        private int m = 1; //default value is 1
        public int M
        {
            get { return m; }
            set { m = value; }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //number of particles
        private int n = 1;//default value is 1

        //array vector of particles
        private Particle[] particle_vector = new Particle[1]; //default value is 1

        public int N
        {
            get 
            { return n; }
            set 
            { n = value;
              particle_vector = new Particle[value];
            }
        }

        public Particle[] PARTICLE_VECTOR
        {
            get { return particle_vector;}
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------

        //constructor
        public Swarm()
        {
            
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //algorithm
        public Vector PSO(int functionchoice)//, double lowerXBound, double upperXBound, double lowerYBound, double upperYBound)
        {
            int numVariables = 2; //number of independent variables

            double w = this.w; //weight
            double c_p = this.c_p; //particle acceleration coefficient
            double c_s = this.c_s; //swarm acceleration coefficient
            Vector s_best = new Vector(numVariables); //swarm's best position
            int m = this.m; //number of iterations
            int n = this.n; //number of particles

            

            //set domain of function
            double lowerXBound = Functions.functionDomains(functionchoice)[0];
            double upperXBound = Functions.functionDomains(functionchoice)[1];
            double lowerYBound = Functions.functionDomains(functionchoice)[2];
            double upperYBound = Functions.functionDomains(functionchoice)[3];
         

            //store output of function(particle's position) at current iteration and current particle in the algorithm's calculation
            double[] p_func_output = new double[n];

            double[] p_best_output = new double[n];

            Particle[] pa = this.particle_vector;

            //Console.Write("Number of particles: ");
            //Console.WriteLine(pa.Length);

            //initialise each particle in the particle vector
            for (int i = 0; i < n; i++)
            {
                pa[i] = new Particle();
                pa[i].X = new Vector(numVariables);
                pa[i].V = new Vector(numVariables);
                pa[i].P_BEST = new Vector(numVariables);
            }

            //initialise s_best
            s_best = this.particle_vector[0].X;

            //initialise lowest function output
            double lowest_output = Functions.function(functionchoice, pa[0].P_BEST[0], pa[0].P_BEST[1]);

            //for each particle in the swarm
            for (int i = 0; i < particle_vector.Length; i++)
            {

                pa[i].X = RNG.GetRNinInterval(lowerXBound, upperXBound, lowerYBound, upperYBound);//initialise position
                pa[i].V = RNG.GetRN(upperXBound - lowerXBound, upperYBound - lowerYBound);//initialise velocity
                pa[i].P_BEST = pa[i].X; //initialise the best position for the particle as their initial positions

                p_best_output[i] = Functions.function(functionchoice, pa[i].P_BEST[0], pa[i].P_BEST[1]);
                                                                                         //initialise the vector of function outputs
                                                                                        //for each particle's best initial position
                if (p_best_output[i] < lowest_output)
                {
                    lowest_output = p_best_output[i];
                    s_best = pa[i].X;
                }

            }

            //over each iteration
            for (int j = 0; j < m; j++)
            {
                //for each particle in the swarm
                for (int i = 0; i < n; i++)
                {
                    //random numbers
                    double r_1 = RNG.rand0to1();

                    for (int c = 0; c < numVariables; c++)
                    {
                        //update velocities
                        pa[i].V[c] = w * pa[i].V[c] + c_p * r_1 * (pa[i].P_BEST[c] - pa[i].X[c]) + c_s * r_1 * (s_best[c] - pa[i].X[c]);
                    }

                    for (int c = 0; c < numVariables; c++)
                    {
                        //update positions
                        pa[i].X[c] = pa[i].X[c] + pa[i].V[c];
                    }

                    //calculate output of function from particle's position
                    //store function output
                    p_func_output[i] = Functions.function(functionchoice, pa[i].X[0], pa[i].X[1]);

                    //if the function's output for the current particle position is lower than for previous positions
                    //update it as the new best output for the particle
                    //update the new best position for the particle
                    if (p_func_output[i] < p_best_output[i])
                    {
                        p_best_output[i] = p_func_output[i];
                        pa[i].P_BEST = pa[i].X;
                    }

                    if (p_best_output[i] < lowest_output)
                    {
                        lowest_output = p_best_output[i];
                        s_best = pa[i].X;
                    }
                }
            }

            //Array.ForEach(s_best, Console.WriteLine);
            return s_best;

        }


    }
}
