using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationConsole.Geometry
{
    public class DemoYield
    {

        public IEnumerable<double> Generator()
        {
            for (double i = 0; i < 100; i++)
            {
                yield return i;
            }
        }

        public IEnumerable<double> GeneratorEven()
        {
            for (double i = 0; i < 100000000000000000000000000000000000000000000d; i+=2)
            {
                yield return i;
            }
        }

        public IEnumerable<double> FilterPrime(IEnumerable<double> values)
        {
            foreach (double v in values)
            {
                if (is_prime(v))
                {
                    yield return v;
                }
            }
        }

        public bool is_prime(double n)
        {
            if (n < 2) { return false; }
            for (double i = 2; i < n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public void Root()
        {
            var res = Generator();
            var res2 = GeneratorEven();
            //var res3 = res2.Where(i => is_prime(i));
            var res3 = FilterPrime(res2);
            foreach (var i in res3)
            {
                Console.WriteLine(i);
            }

        }
    }
}
