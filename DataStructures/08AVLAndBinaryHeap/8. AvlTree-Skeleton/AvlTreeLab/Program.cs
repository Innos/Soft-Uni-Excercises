namespace AvlTreeLab
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var nums = new int[] { 1, 2, 3, 5, 13, 22 };

            var tree = new AvlTree<int>();
            foreach (int num in nums)
            {
                tree.Add(num);
            }

            tree.Remove(3);
            tree.Remove(13);
            tree.Remove(1);
            tree.Add(4);

            foreach (var node in tree)
            {
                Console.WriteLine(node);
            }
        }
    }
}
