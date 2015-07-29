namespace _01CommandInterpreter
{
    #region UsingDirectives

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    #endregion

    public class CommandInterpreter
    {
        public static void Main()
        {
            StringBuilder sb = new StringBuilder();
            string input = Console.ReadLine();
            List<string> collection = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            while (input != "end")
            {
                sb.Append(ReadCommands(collection, input));
                input = Console.ReadLine();
            }

            Console.Write(sb.ToString());
            Console.WriteLine("[{0}]", string.Join(", ", collection));
        }

        private static StringBuilder ReadCommands(List<string> collection, string input)
        {
            StringBuilder sb = new StringBuilder();
            List<string> temp = new List<string>();
            string[] commands = input.Split();

            switch (commands[0])
            {
                case "reverse":
                    {
                        int start = int.Parse(commands[2]);
                        int count = int.Parse(commands[4]);
                        if (IsValidOrder(collection, start, count))
                        {
                            ReverseSubArray(collection, temp, start, count);
                        }
                        else
                        {
                            sb.AppendLine("Invalid input parameters.");
                        }
                        break;
                    }
                case "sort":
                    {
                        int start = int.Parse(commands[2]);
                        int count = int.Parse(commands[4]);
                        if (IsValidOrder(collection, start, count))
                        {
                            SortSubArray(collection, temp, start, count);
                        }
                        else
                        {
                            sb.AppendLine("Invalid input parameters.");
                        }
                        break;
                    }
                case "rollLeft":
                    {
                        int count = int.Parse(commands[1]);
                        if (count >= 0)
                        {
                            ShiftArrayLeft(collection,count);
                        }
                        else
                        {
                            sb.AppendLine("Invalid input parameters.");
                        }
                        break;
                    }
                case "rollRight":
                    {
                        int count = int.Parse(commands[1]);
                        if (count >= 0)
                        {
                            ShiftArrayRight(collection, count);
                        }
                        else
                        {
                            sb.AppendLine("Invalid input parameters.");
                        }
                        break;
                    }
            }

            return sb;
        }

        private static void ShiftArrayRight(List<string> collection, int count)
        { 
                for (int i = 0; i < (count % collection.Count); i++)
                {
                    string tempString = collection.Last();
                    for (int l = collection.Count - 1; l > 0; l--)
                    {
                        collection[l] = collection[l - 1];
                    }

                    collection[0] = tempString;
                } 
        }

        private static void ShiftArrayLeft(List<string> collection, int count)
        {
                for (int i = 0; i < (count % collection.Count); i++)
                {
                    string tempString = collection[0];
                    for (int l = 0; l < collection.Count - 1; l++)
                    {
                        collection[l] = collection[l + 1];
                    }

                    collection[collection.Count - 1] = tempString;
                }
        }

        private static void SortSubArray(List<string> collection, List<string> temp, int start, int count)
        {
            for (int i = start; i < start + count; i++)
            {
                temp.Add(collection[i]);
            }

            temp.Sort();
            collection.RemoveRange(start, count);
            collection.InsertRange(start, temp);
        }

        private static void ReverseSubArray(List<string> collection, List<string> temp, int start, int count)
        {
            for (int i = start; i < start + count; i++)
            {
                temp.Add(collection[i]);
            }

            temp.Reverse();
            collection.RemoveRange(start, count);
            collection.InsertRange(start, temp);
        }

        private static bool IsValidOrder(List<string> collection, int start, int count)
        {
            if (start < 0 ||
                start >= collection.Count ||
                count < 0 ||
                start + count > collection.Count)
            {
                return false;
            }

            return true;
        }
    }
}