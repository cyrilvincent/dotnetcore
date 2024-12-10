using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole.Banque
{
    // enumeration TypeTransaction Credit Debit
    // Autoincrementer un compteur d'id = 0 + 1 (static)
    public class Transaction
    {
        public ulong Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public decimal Montant { get; set; }

        //public Transaction()
        //{
        //    Id = 
        //}
    }
}
