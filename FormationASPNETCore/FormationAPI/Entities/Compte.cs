namespace FormationAPI.Entities
{
    public class Compte : IEntity
    {
        public long Id { get; set; }
        public decimal Solde { get; set; }
        public string Devise { get; set; } = "EUR";
        public string? Commentaire { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; } = [];
        public virtual ICollection<Client> Clients { get; set; } = [];
    }
}
