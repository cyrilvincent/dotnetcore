namespace FormationAPI.Entities
{
    public enum TransactionType { Credit, Debit};

    public class Transaction : IEntity
    {
        public long Id { get; set; }
        public decimal Montant { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public TransactionType Type { get; set; }
        public required Compte Compte { get; set; }
        public long CompteId { get; set; }
    }
}
