using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW3
{
    public class RandomUtils
    {
        public static int[] GetRandomArray(int maxLength)
        {
            Random random = new Random();

            int elementLowerBound = -100;
            int elementUpperBound = 100;

            int[] arr = new int[random.Next(1, maxLength)];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(elementLowerBound, elementUpperBound);
            }

            return arr;
        }
    }
}
