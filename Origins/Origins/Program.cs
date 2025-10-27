namespace Origins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storyBuilder = new StoryBuilder();
            var story = storyBuilder.Load();
            var engine = new GameEngine(story);
            bool playAgain = true;

            while (playAgain)
            {
                engine.Start();
                while (!engine.IsGameOver)
                {
                    engine.DisplayCurrentNode();
                    if (engine.IsAtEnding)
                    {
                        engine.End();
                        break;
                    }
                    var nextNode = engine.GetPlayerChoice();
                    engine.MoveToNode(nextNode);
                }

                Console.Write("\nPlay again? (y/n): ");
                string response = Console.ReadLine()?.ToLower() ?? "n";
                playAgain = response == "y" || response == "yes";
            }

            Console.WriteLine(". _ - GAME OVER - _ .");
        }
    }
}
