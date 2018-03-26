using System;
using System.Collections.Generic;
using System.Text;

namespace SKit.Common.Utils
{
    public static class MathUtil
    {
        private static readonly Random Random = new Random();

        public static int RandomNumber(int min, int max)
        {
            return Random.Next(min, max);
        }

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

        public static T RandomElement<T>(IEnumerable<T> elements, Func<T, int> weightFunc)
            where T : class
        {
            int sum = 0;
            int length = 0;
            foreach (T element in elements)
            {
                sum += weightFunc(element);
                length++;
            }

            int rand = Random.Next(0, sum);
            int cur = 0;
            foreach (T element in elements)
            {
                cur += weightFunc(element);
                if (rand < cur)
                {
                    return element;
                }
            }
            return null;
        }
    }
}
