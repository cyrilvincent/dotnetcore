namespace FormationAPI.Entities
{
    public class Compte
    {
        public long Id { get; set; }
        public decimal Solde { get; set; }
        public string Devise { get; set; } = "EUR";
        public string? Commentaire { get; set; }
    }
}
