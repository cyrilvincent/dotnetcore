namespace FormationASPNETCore.Entities
{
    public class Media
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public string? Comment { get; set; }
        public MediaType MediaType { get; set; }
        public Publisher? Publisher { get; set; }
        public long? PublisherId { get; set; }


    }

    public enum MediaType
    {
        Book,
        Cd,
        Dvd
    }
}
