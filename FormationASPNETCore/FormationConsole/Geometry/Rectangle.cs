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
        
        // PROPERTY
        public double Length
        {
            get { return length; }
            set { length = value; }
        }
        public double Width { get; set; }

        // CONSTRUCTEUR
        //public Rectangle(double length=0, double width=0)
        //{
        //    this.length = length;
        //    Width = width;
        //}

        // COMMENT
        public double Surface
        {
            get { return Length * Width; }
        }

        public double Perimeter
        {
            get {
                return 2 * (length + Width);
            }
        }

        public override string ToString()
        {
            return $"Rectangle ({Length},{Width})";
        }
    }
}
