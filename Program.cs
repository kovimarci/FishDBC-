using System.ComponentModel.Design;

namespace FishDB
{
    internal class Program
    {
        public static ConsoleKey lastInput;
        public static ServerConnection server = new ServerConnection("http://127.255.255.254:3000");
        static async Task Main()
        {
            do
            {
                Console.Clear();
            }
            while (await Run());
        }

        static async Task<bool> Run()
        {
            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("\n\n\t(1)"); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("\tRegister");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("\t(2)"); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("\tGet Fishes");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("\t(Esc)"); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("\tExit");
            Console.Write("\n\t> ");
            lastInput = Console.ReadKey(false).Key;
            if (lastInput == ConsoleKey.D1 || lastInput == ConsoleKey.NumPad1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\n\n\tUsername: "); Console.ForegroundColor = ConsoleColor.White;
                string username = Console.ReadLine().Trim();
                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("\tPassword: "); Console.ForegroundColor = ConsoleColor.White;
                string password = Console.ReadLine().Trim();
                switch (await server.Register(username, password))
                {
                    case true: Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\n\tSuccess"); Console.ForegroundColor = ConsoleColor.White; break;
                    case false: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\tFailed"); Console.ForegroundColor = ConsoleColor.White; break;
                }
                Console.Write("\n\tBack "); Console.ReadKey();
                await Main();
                return true;
            }
            else if (lastInput == ConsoleKey.D2 || lastInput == ConsoleKey.NumPad2)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t- Fishes -");
                (await server.GetFish()).ForEach(x => Console.WriteLine("\t" + x));
                Console.Write("\n\tBack "); Console.ReadKey();
                await Main();
                return true;
            }
            else if (lastInput == ConsoleKey.Escape)
            {
                return false;
            }
            else { return false; }
        }
    }
}
