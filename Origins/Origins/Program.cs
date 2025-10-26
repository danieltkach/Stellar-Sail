namespace Origins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Text strings ---
            string intro = "You wake up in your spaceship, good old Mineral Rider 1.";
            string trySleep1 = "You try to go back to sleep but a rotten smell wakes you up...";
            string turnLeft = "You turn your head slowly to your left... you see your captain, or what's left of him, " +
                "with a very dead expression on his face.";
            string eternalNightmare = "The putrid smell consumes all the oxygen of your body. " +
                        "You drift into space forever, into an eternal nightmare.";
            string seeLever = "You see a lever that gets your attention, which says 'EJECT'";
            string expelled = "You are expelled into deep space... hopefully someone rescues you soon.";

            string menuOption;

            // Game start ---
            Print(intro);
            menuOption = Menu()!;
            if (menuOption == "L")
            {
                Print(turnLeft);
                menuOption = Menu()!;     
                if (menuOption == "S")
                {
                    Print(eternalNightmare);
                }
                else if (menuOption == "L")
                {
                    Print(seeLever);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("L > Push lever \t S > Go back to sleep...");
                    menuOption = Console.ReadLine()!;
                    if (menuOption == "S")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Print(eternalNightmare);
                    }
                    else if (menuOption == "L")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Print(expelled);
                    }
                }
            }
            else if (menuOption == "S")
            {
                Print(trySleep1);
                menuOption = Menu()!;
                if (menuOption == "S")
                {
                    Print(eternalNightmare);
                }
                else if (menuOption == "L")
                {
                    Print(seeLever);
                    Console.WriteLine("L > Push lever \t S > Go back to sleep...");
                    menuOption = Console.ReadLine()!;
                    if (menuOption == "S")
                    {
                        Print(eternalNightmare);
                    }
                    else if (menuOption == "L")
                    {
                        Print(expelled);
                    }
                }
            }
        }

        private static void Print(string text, string type = "normal")
        {
            switch (type)
            {
                case "normal":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "highlight":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "alert":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine(text);
        }

        private static string? Menu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("L > look around \t S > go back to sleep");
            return Console.ReadLine();
        }
    }
}
