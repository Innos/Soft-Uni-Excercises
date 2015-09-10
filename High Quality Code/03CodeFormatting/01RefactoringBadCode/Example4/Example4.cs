namespace Example4
{
    using System;
    using System.Collections.Generic;

    public class Example4
    {
        public static void Main(string[] args)
        {
        }

        private int[] ListToArray(List<int> list)
        {
            try
            {
                int[] res = new int[list.Count];

                for (int i = 0; i < list.Count; i++)
                {
                    res[i] = list[i];
                }

                return res;
            }
            catch (Exception)
            {
                return new int[0];
            }
        }
    }
}
