using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole.Banque
{
    // enumeration TypeTransaction Credit Debit
    // Autoincrementer un compteur d'id = 0 + 1 (static)

    public enum TransactionType { Credit, Debit}

    public class Transaction
    {
        private static ulong counter = 0;
        public ulong Id { get; set; } = counter++;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public decimal Montant { get; set; }
        public TransactionType Type { get; set; }

        //public Transaction()
        //{
        //    Id = counter++;
        //}
    }
}
