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
                Print($"\n=== ENDING #{CurrentNode.Ending.Number}: {CurrentNode.Ending.Title} ===", "ending");

                // Track discovered ending
                if (!DiscoveredEndings.Contains(CurrentNode.Ending.Number))
                {
                    DiscoveredEndings.Add(CurrentNode.Ending.Number);
                }

                Print($"You've discovered {DiscoveredEndings.Count} ending(s) so far!", "highlight");
            }

            GameState = GameState.Ended;
        }

        public void DisplayCurrentNode()
        {
            Console.WriteLine();
            Print(CurrentNode.Text, "normal");

            if (CurrentNode.Choices.Count > 0)
            {
                Console.WriteLine(); 
                for (int i = 0; i < CurrentNode.Choices.Count; i++)
                {
                    Print($"{i + 1}. {CurrentNode.Choices[i].Text}", "menu");
                }
            }
        }

        public string GetPlayerChoice()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> ");
                Console.ResetColor();

                var choice = Console.ReadLine();
                bool validInput = int.TryParse(choice, out int parsedChoice);
                bool choiceInRange = parsedChoice >= 1 && parsedChoice <= CurrentNode.Choices.Count;

                if (validInput && choiceInRange)
                {
                    return CurrentNode.Choices[parsedChoice - 1].Link;
                }

                Print("Invalid choice. Try again.", "alert");
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
                GameState = GameState.Ended;
            }
        }

        // Private helper method for colored output
        private void Print(string text, string type = "normal")
        {
            Console.ForegroundColor = type switch
            {
                "normal" => ConsoleColor.Green,
                "highlight" => ConsoleColor.Yellow,
                "alert" => ConsoleColor.Red,
                "ending" => ConsoleColor.Cyan,
                "menu" => ConsoleColor.DarkYellow,
                _ => ConsoleColor.White,
            };
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
