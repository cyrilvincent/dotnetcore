using FormationAPI.DTOs;
using FormationAPI.Entities;

namespace FormationAPI.Adapters
{
    public static class CompteAdapters
    {
        public static CompteClientDTO ToCompteClientDTO(this Compte entity)
        {
            return new CompteClientDTO
            {
                Id = entity.Id,
                Solde = entity.Solde,
                Comment = entity.Commentaire,
                FullName = $"{entity.Clients.First().Nom} {entity.Clients.First().Prenom}"
            };
        }
    }
}
