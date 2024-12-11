using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole.Banque
{
    public interface IBankable
    {
        List<Client> Clients { get; set; }
        List<Compte> Comptes { get; set; }

        void AddClient(Client client);
        void RemoveClient(Client client);
        void AddCompte(Compte compte);
        void RemoveCompte(Compte compte);

        decimal GetEncours(); // Somme de tous les soldes

        decimal GetInteretsEnCours(); // Somme des interets

    }
}
