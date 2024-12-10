using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole.Banque
{
    public class Transaction
    {
        public ulong Id { get; set; } = 0;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public decimal Montant { get; set; }
    }
}
