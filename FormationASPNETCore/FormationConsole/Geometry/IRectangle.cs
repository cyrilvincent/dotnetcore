
namespace FormationConsole.Geometry
{
    public interface IRectangle
    {
        Color Color { get; set; }
        double Length { get; set; }
        double Perimeter { get; }
        Point? Point { get; set; }
        List<Point> Points { get; set; }
        double Surface { get; }
        double Width { get; set; }

        string ToString();
    }
}