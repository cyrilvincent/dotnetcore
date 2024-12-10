using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole.Geometry
{
    public class Rectangle
    {
        // QUOI
        private double length;
        private double width;

        // CONSTRUCTEUR
        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        // COMMENT
        public double Surface()
        {
            return length * width;
        }

        public double Perimeter()
        {
            return 2 * (length + width);
        }

        public override string ToString()
        {
            return $"Rectangle ({length},{width})";
        }
    }
}
