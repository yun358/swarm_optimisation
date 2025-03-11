using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Particle
    {

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //position
        private Vector x = new Vector();
        public Vector X
        {
            get { return x; }
            set { x = new Vector(value); }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //velocity array vector
        private Vector v = new Vector();
        public Vector V
        {
            get { return v; }
            set { v = new Vector(value); }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //best position until this point (particle's record of most minimal position)
        private Vector p_best = new Vector();
        public Vector P_BEST
        {
            get { return p_best; }
            set { p_best = new Vector(value); }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //constructor
        public Particle()
        {

        }

    }
}
