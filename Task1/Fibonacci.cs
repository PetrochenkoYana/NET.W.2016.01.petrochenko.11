using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class Fibonacci
    {
        public static IEnumerable<long> GetEnumerator(int numbersAmount)
        {
            long prev = -1;
            long next = 1;
            int i = 0;
            while (i < numbersAmount)
            {
                long sum = prev + next;
                prev = next;
                next = sum;
                yield return sum;
                i++;
            }

        }
    }
}
