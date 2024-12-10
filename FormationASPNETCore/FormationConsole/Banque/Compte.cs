using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole.Banque
{
    public class Compte
    {
        private ulong numero;
        private decimal solde;
        private string devise;
        private decimal decouvert;
        private DateTime creationDate;

        public Compte(ulong numero, decimal solde=0, string devise="EUR", decimal decouvert=0m)
        {
            this.numero = numero;
            this.solde = solde;
            this.devise = devise;
            this.decouvert = decouvert;
            creationDate = DateTime.Now;
        }

        public void Crediter(decimal montant)
        {
            solde += montant;
        }

        public void Debiter(decimal montant)
        {
            if ((montant < 0) || (solde - decouvert < montant))
            {
                Console.WriteLine("Interdit");
            }
            else
            {
                solde -= montant;
            }
        }

        public override string ToString()
        {
            return $"Compte {numero}:{solde} {devise}";
        }
    }
}
