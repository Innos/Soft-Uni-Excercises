namespace _02Example2
{
    using System;

    public class Parent
    {
        public string Id;

        public Parent parent;
    }

    public class Example2
    {
        private Parent parent;

        public static void Main(string[] args)
        {
        }

        protected virtual string GetParentTableControlId()
        {
            try
            {
                if (this.parent is Parent)
                {
                    return this.parent.Id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }
    }
}
