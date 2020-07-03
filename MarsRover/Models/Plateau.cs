using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Plateau
    {
        public static int X { get; set; }
        public static int Y { get; set; }

        public Plateau(List<int> limits)
        {
            X = limits[0];
            Y = limits[1];
        }

        public static List<int> GetPlateauBoundries()
        {
            List<int> result = new List<int>();
            result.Add(X);
            result.Add(Y);
            return result;
        }


    }
}
