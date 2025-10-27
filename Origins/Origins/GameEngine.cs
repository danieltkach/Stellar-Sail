namespace Origins
{
    enum GameState
    {
        NotStarted,
        Playing,
        Ended
    }
    internal class GameEngine
    {
        private Dictionary<string, StoryNode> Story { get; set; }
        private StoryNode CurrentNode { get; set; }
        private List<int> DiscoveredEndings { get; set; }
        public GameState GameState { get; set; } = GameState.NotStarted;
        public bool IsGameOver => GameState == GameState.Ended;
        public bool IsAtEnding => CurrentNode.Ending != null;

        public GameEngine(Dictionary<string, StoryNode> story)
        {
            Story = story;
            CurrentNode = story["intro"];
            DiscoveredEndings = new List<int>();
            GameState = GameState.NotStarted;
        }

        public void Start()
        {
            CurrentNode = Story["intro"];
            GameState = GameState.Playing;
        }

        public void End()
        {
            if (CurrentNode.Ending != null)
            {
                Console.WriteLine($"\n=== ENDING #{CurrentNode.Ending.Number}: {CurrentNode.Ending.Title} ===");

                // Track discovered ending
                if (!DiscoveredEndings.Contains(CurrentNode.Ending.Number))
                {
                    DiscoveredEndings.Add(CurrentNode.Ending.Number);
                }

                Console.WriteLine($"\nYou've discovered {DiscoveredEndings.Count} ending(s) so far!");
            }

            GameState = GameState.Ended;
        }

        public void DisplayCurrentNode()
        {
            Console.WriteLine(CurrentNode.Text);
            if (CurrentNode.Choices.Count > 0)
            {
                for (int i = 0; i < CurrentNode.Choices.Count; i++)
                {
                    Console.WriteLine($"{i + 1} > {CurrentNode.Choices[i].Text}");
                }
            }
        }

        public string GetPlayerChoice()
        {
            while (true)
            {
                Console.Write("> ");
                var choice = Console.ReadLine();
                bool validInput = int.TryParse(choice, out int parsedChoice);
                bool choiceInRange = parsedChoice >= 1 && parsedChoice <= CurrentNode.Choices.Count;
                if (validInput && choiceInRange)
                {
                    return CurrentNode.Choices[parsedChoice - 1].Link;
                }
                Console.WriteLine("Invalid choice. Try again.");
            }
        }

        public void MoveToNode(string nodeName)
        {
            if (Story.ContainsKey(nodeName))
            {
                CurrentNode = Story[nodeName];
            }
            else
            {
                Console.WriteLine($"ERROR: Node '{nodeName}' not found!");
                GameState = GameState.Ended;  // End game on error
            }
        }

        private static void Print(string text, string type = "normal")
        {
            Console.ForegroundColor = type switch
            {
                "normal" => ConsoleColor.Green,        // Story text
                "highlight" => ConsoleColor.Yellow,    // Important info
                "alert" => ConsoleColor.Red,           // Errors/warnings
                "ending" => ConsoleColor.Cyan,         // Ending titles
                "menu" => ConsoleColor.DarkYellow,     // Choice menus
                _ => ConsoleColor.White,
            };
            Console.WriteLine(text);
        }
    }
}
