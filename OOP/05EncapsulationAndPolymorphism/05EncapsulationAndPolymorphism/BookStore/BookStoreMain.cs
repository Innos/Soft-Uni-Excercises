namespace BookStore
{
    using Engine;
    using BookStore.UI;

    public class BookStoreMain
    {
        public static void Main()
        {
            ConsoleInputHandler iHandler = new ConsoleInputHandler();
            ConsoleRenderer renderer = new ConsoleRenderer();
            BookStoreEngine engine = new BookStoreEngine(renderer,iHandler);

            engine.Run();
        }
    }
}
