using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole.Banque
{
    public class CompteEpargne : Compte
    {

        public decimal Taux { get; set; } = 0m;

        public CompteEpargne(ulong numero, Client client, decimal solde = 0, string devise = "EUR", decimal decouvert = 0m, decimal taux = 0m)
            : base(numero, client, solde, devise)
        {
            Taux = taux;
        }
        public CompteEpargne() { }

        public decimal Interet
        {
            get { return Solde * Taux; }
        }
    }
}
