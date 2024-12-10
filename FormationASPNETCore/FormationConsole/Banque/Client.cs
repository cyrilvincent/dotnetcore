using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole.Banque
{
    public class Client
    {
        // (id, prenom, nom, tel, mail)
        public ulong Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }

    }
}
