using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace FormationConsole.Geometry
{
    public class Rectangle2 : IRectangle
    {
        public Color Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Length { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double Perimeter => throw new NotImplementedException();

        public Point? Point { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Point> Points { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double Surface => throw new NotImplementedException();

        public double Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
