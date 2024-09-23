namespace FormationASPNETCore.Entities
{
    public class Author
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; } = "";
        public virtual ICollection<Media> Medias { get; set; } = [];
    }
}
