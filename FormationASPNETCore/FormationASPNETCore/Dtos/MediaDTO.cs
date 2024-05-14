using FormationASPNETCore.Entities;

namespace FormationASPNETCore.Dtos
{
    public class MediaDTO : IDTO
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public float Price { get; set; }
        public string? Comment { get; set; }
        public MediaType MediaType { get; set; }
        public string? PublisherName { get; set; }
    }
}
