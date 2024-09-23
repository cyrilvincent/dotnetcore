namespace FormationASPNETCore.Entities
{
    public class Media : IEntity
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public float Price { get; set; }
        public string? Comment { get; set; }
        public MediaType MediaType { get; set; }
        public Publisher? Publisher { get; set; }
        public long? PublisherId { get; set; }
        public virtual ICollection<Author> Authors { get; set; } = [];


    }

    public enum MediaType
    {
        Book,
        Cd,
        Dvd
    }
}
