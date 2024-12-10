using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole.Geometry
{
    public static class Counter // Qui ne contient QUE du static, non instantiable
    {
        public static int Value { get; set; } = 0; // Static = Shared

        public static void Increment() // Ne peut accéder qu'à du static
        {
            Value++;
        }

        public static int GetValue()
        {
            return Value;
        }
    }

    // Singleton
}
