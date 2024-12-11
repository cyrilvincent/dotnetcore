using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole.Geometry
{
    public enum Color
    {
        Red=0,
        Green=10,
        Blue=20
    }

    public class Rectangle : IRectangle
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
        public Point? Point { get; set; } = new Point { };

        public List<Point> Points { get; set; } = new List<Point>();
        public Color Color { get; set; } = Color.Blue;

        // CONSTRUCTEUR
        public Rectangle(double length = 0, double width = 0)
        {
            this.length = length;
            Width = width;
        }
        public Rectangle() { }

        // COMMENT
        public double Surface
        {
            get { return Length * Width; }
        }

        public double Perimeter
        {
            get
            {
                return 2 * (length + Width);
            }
        }

        public override string ToString()
        {
            return $"Rectangle ({Length},{Width})";
        }

        // Rectangle - Point HAS
        // Rectangle - Carré IS
        // Différence entre ces 2 relations
        // Nommer les 2 relations avec un seul mot (verbe) compréhensible par un enfant de 2 ans
        // 
    }
}
