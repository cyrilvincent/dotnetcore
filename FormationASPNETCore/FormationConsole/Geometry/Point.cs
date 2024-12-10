using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole.Geometry
{
    public class Point
    {
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;

        public void Move(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void MoveRelative(double x, double y)
        {
            X += x;
            Y += y;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

    }
}
