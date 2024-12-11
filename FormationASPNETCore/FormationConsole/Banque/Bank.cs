using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole.Banque
{
    public class Bank : IBankable
    {
        public List<Client> Clients { get; set; } = new List<Client>();
        public List<Compte> Comptes { get;set; } = new List<Compte>();

        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public void AddCompte(Compte compte)
        {
            Comptes.Add(compte);
        }

        public decimal GetEncours()
        {
            decimal total = 0m;
            foreach (Compte compte in Comptes)
            {
                total += compte.Solde;
            }
            return total;
        }

        public decimal GetInteretsEnCours()
        {
            decimal total = 0m;
            foreach (Compte compte in Comptes)
            {
                if (compte is CompteEpargne)
                {
                    //CompteEpargne compteEpargne = (CompteEpargne)compte;
                    //total += compteEpargne.Interet;
                    total += ((CompteEpargne)compte).Interet;
                }
                
            }
            return total;
        }

        public void RemoveClient(Client client)
        {
            Clients.Remove(client);
        }

        public void RemoveCompte(Compte compte)
        {
            Comptes.Remove(compte);
        }
    }
}
