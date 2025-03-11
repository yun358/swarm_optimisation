using System;
namespace ConsoleApp1
{
	public class RNG
	{
		//r is a random value
		private static Random r = new Random();

		static RNG()
		{
		}

		//get random number between minimum and maximum
		//to randomise the position for each particle
		public static Vector GetRNinInterval(double minimumX, double maximumX, double minimumY, double maximumY)
		{
			double randomNum1 = r.NextDouble();
			double x_pos = randomNum1 * (maximumX - minimumX) + minimumX;

            double randomNum2 = r.NextDouble();
			double y_pos = randomNum2 * (maximumY - minimumY) + minimumY;

            Vector re = new Vector(2);

            re[0] = x_pos;
            re[1] = y_pos;

            return re;

		}

        //for a number k, get random number between k/10 - k/50 and k-10 + k/50
		//to randomise the initial velocity for each particle
        public static Vector GetRN(double size_x, double size_y)
        {
			double maximumXv = (size_x / 10) + (size_x / 50);
			double minimumXv = (size_x / 10) - (size_x / 50);

            double maximumYv = (size_y / 10) + (size_y / 50);
            double minimumYv = (size_y / 10) - (size_y / 50);

            double randomNum1 = r.NextDouble();
            double velo_x = randomNum1 * (maximumXv - minimumXv) + minimumXv;

            double randomNum2 = r.NextDouble();
            double velo_y = randomNum2 * (maximumYv - minimumYv) + minimumYv;

            Vector re = new Vector(2);

            re[0] = velo_x;
            re[1] = velo_y;

            return re;
        }

        public static double rand0to1()
        {
            return r.NextDouble();
        }
    }
}

