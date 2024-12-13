namespace FormationAPI.DTOs
{
    public class CompteClientDTO : IDTO
    {
        public long Id { get; set; }
        public decimal Solde { get; set; }
        public string? Comment { get; set; }
        public string? FullName { get; set; }
    }
}
