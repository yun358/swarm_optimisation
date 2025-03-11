using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Vector
    {
        //basically the vector object stores a double array called data
        private double[] data = new double[3];

        public int Size //read-only property
        { get { return data.Length; } }

        public Vector()
        {
            int i = 0;
            for (i = 0; i < data.Length; i++)
                data[i] = 0;
        }

        //create vector of certain size
        public Vector(int size)
        {
            if(size < 1)
            {
                Console.WriteLine("Invalid vector size {0}, set to default of 3 instead", size);
                size = 3;
            }

            data = new double[size];

            int i = 0;
            for (i = 0; i < data.Length; i++)
                data[i] = 0;
        }

        //clone vector
        public Vector(Vector v)
        {
            data = new double[v.Size];
            for (int i = 0; i < this.Size; i++)
                data[i] = v[i];
        }

        //finds the index of the maximum value in the vector
        public int MaxIndex()
        {
            int index = 0;
            double max = double.MinValue;
            for(int i = 0; i< Size; i++)
                if(max < data[i])
                {
                    max = data[i];
                    index = i;
                }
            return index;

        }

        //set or return element in a vector of index i
        public double this[int i]
        {
            get { return data[i]; }
            set { data[i] = value; }
        }

        //add two vectors element wise
        public static Vector operator+(Vector lhs, Vector rhs)
        {
            int i = 0;
            Vector res = new Vector(lhs.Size);
            for (i = 0; i < lhs.Size; i++)
                res[i] = lhs[i] + rhs[i];
            return res;
        }


        //returns the same vector (unary +)
        public static Vector operator +(Vector lhs)
        {
            int i = 0;
            Vector res = new Vector(lhs.Size);
            for (i = 0; i < lhs.Size; i++)
                res[i] = lhs[i];
            return res;
        }

        //returns lhs - rhs
        public static Vector operator -(Vector lhs, Vector rhs)
        {
            int i = 0;
            Vector res = new Vector(lhs.Size);
            for (i = 0; i < lhs.Size; i++)
                res[i] = lhs[i] - rhs[i];
            return res;
        }

        //returns vector with each element * -1
        public static Vector operator -(Vector lhs)
        {
            int i = 0;
            Vector res = new Vector(lhs.Size);
            for (i = 0; i < lhs.Size; i++)
                res[i] = -lhs[i];
            return res;
        }

        //element wise multiplication of two vectors
        public static double operator*(Vector lhs, Vector rhs)
        {
            int i;
            double res = 0;
            for (i = 0; i < lhs.Size; i++)
                res += lhs[i]*rhs[i];
            return res;
        }


        //scalar * vector operation
        public static Vector operator *(double lhs, Vector rhs)
        {
            int i;
            Vector res = new Vector(rhs.Size);
            for (i = 0; i < rhs.Size; i++)
                res[i] = lhs * rhs[i];
            return res;
        }

        //divides each element of vector by scalar value
        public static Vector operator /( Vector lhs, double rhs)
        {
            int i;
            Vector res = new Vector(lhs.Size);
            for (i = 0; i < lhs.Size; i++)
                res[i] = lhs[i]/rhs;
            return res;
        }

        //sets all elements of a vector to 0
        public void Zero()
        {
            int i = 0;            
            for (i = 0; i < this.Size; i++)
                this[i] = 0;
        }

        //generate a string representation of a vector
        public override string ToString()
        {
            int i;
            string tmp = "(";
            for (i = 0; i < this.Size - 1; i++)
            {
                tmp += string.Format("{0:F2}, ", this[i]);
            }
            tmp += string.Format("{0:F2}", this[i]);
            tmp += ")";
            return tmp;
        }
    }
}
