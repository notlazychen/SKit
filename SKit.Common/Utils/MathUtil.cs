using System;
using System.Collections.Generic;
using System.Text;

namespace SKit.Common.Utils
{
    public static class MathUtil
    {
        private static readonly Random Random = new Random();

        public static int RandomIndex(int[] weight)
        {
            int sum = 0;
            foreach (int item in weight)
            {
                sum += item;
            }

            int rand = Random.Next(0, sum);
            int cur = 0;
            for(int i = 0; i< weight.Length; i++)
            {
                cur += weight[i];
                if(rand < cur)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
