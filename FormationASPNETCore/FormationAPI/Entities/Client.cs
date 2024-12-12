namespace FormationAPI.Entities
{
    public class Client : IEntity
    {
        public long Id { get; set; }
        public required string Nom { get; set; }

        public string? Prenom { get; set; }

        public virtual ICollection<Compte> Comptes { get; set; } = [];

    }
}
