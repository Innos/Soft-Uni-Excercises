namespace Longest_Common_Subsequence
{
    using System;
    using System.Collections.Generic;

    public class LongestCommonSubsequence
    {
        private static int[,] lcs;


        public static void Main()
        {
            string firstStr = "tree";
            string secondStr = "team";

            var lcsResult = FindLongestCommonSubsequence(firstStr, secondStr);

            Console.WriteLine("Longest common subsequence:");
            Console.WriteLine("  first  = {0}", firstStr);
            Console.WriteLine("  second = {0}", secondStr);
            Console.WriteLine("  lcs    = {0}", lcsResult);
        }

        // iterative solution
        public static string FindLongestCommonSubsequence(string firstStr, string secondStr)
        {
            int firstLen = firstStr.Length + 1;
            int secondLen = secondStr.Length + 1;
            lcs = new int[firstLen, secondLen];

            // we start iterating from cell 1,1 because all cells with row == 0 or col == 0 will always be equal to 0 (and the lcs array is initialized with 0 values by default)
            for (int i = 1; i < firstLen; i++)
            {
                for (int j = 1; j < secondLen; j++)
                {
                    if (firstStr[i - 1] == secondStr[j - 1])
                    {
                        lcs[i, j] = lcs[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                    }
                }
            }

            return RetrieveLCS(firstStr, secondStr);
        }


        // recursive solution
        // firstStr and secondStr should be available for the class
        //private static int CalcLCS(int x, int y)
        //{
        //    if (x < 0 || y < 0)
        //    {
        //        return 0;
        //    }

        //    if (lcs[x, y] == -1)
        //    {
        //        if (firstStr[x] == secondStr[y])
        //        {
        //            lcs[x, y] = CalcLCS(x - 1, y - 1) + 1;
        //        }
        //        else
        //        {
        //            lcs[x, y] = Math.Max(CalcLCS(x - 1, y), CalcLCS(x, y - 1));
        //        }
        //    }
        //    return lcs[x, y];
        //}

        private static string RetrieveLCS(string firstStr, string secondStr)
        {
            List<char> lcsWord = new List<char>();

            for (int i = lcs.GetUpperBound(0); i >= 0; i--)
            {
                for (int j = lcs.GetUpperBound(1); j >= 0; j--)
                {
                    while (i > 0 && j > 0)
                    {
                        if (firstStr[i - 1] == secondStr[j - 1])
                        {
                            lcsWord.Add(firstStr[i - 1]);
                            j--;
                            i--;
                        }
                        else if (lcs[i, j] == lcs[i - 1, j])
                        {
                            i--;
                        }
                        else
                        {
                            j--;
                        }
                    }
                }
            }
            lcsWord.Reverse();
            return new string(lcsWord.ToArray());
        }
    }
}
