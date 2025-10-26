namespace Origins
{
    internal class StoryBuilder
    {
        private readonly Dictionary<string, StoryNode> nodes = [];

        public Dictionary<string, StoryNode> Load()
        {
            nodes.Clear();

            AddNode("intro",
                "You wake up in your spaceship, good old Mineral Rider 1.",
                ("Look around", "turned_left"),
                ("Go back to sleep", "back_to_sleep")
            );

            AddNode("back_to_sleep",
                "You try to go back to sleep but a rotten smell wakes you up...",
                ("Look around", "turned_left"),
                ("Go back to sleep", "drifting_death")
            );

            AddNode("drifting_death",
                "The putrid smell consumes all the oxygen of your body. You drift into space forever, into an eternal nightmare.",
                ending: new Ending { Number = 1, Title = "The Drifter" }
            );

            AddNode("turned_left",
                "You turn your head slowly to your left... you see your captain, " +
                    "or what's left of him, with a very dead expression on his face.",
                ("Look around", "found_lever"),
                ("Go back to sleep", "drifting_death")
            );

            AddNode("found_lever",
                "You see a lever that gets your attention, which says 'EJECT'",
                ("Push lever", "expelled"),
                ("Look around", "found_ship_controls"),
                ("Go back to sleep", "drifting_death")
            );

            AddNode("found_ship_controls",
                "Now fully awake and fully scared, you decided to take a moment to think and you found the ship's instructions manual.",
                ("Push lever", "expelled"),
                ("Read manual", "under_construction"),
                ("Go back to sleep", "drifting_death")
            );

            AddNode("expelled",
                "You are expelled into deep space... hopefully someone rescues you soon.",
                ending: new Ending { Number = 2, Title = "The Expelled" }
            );

            AddNode("under_construction",
                "This part of the story is still under construction. Stay tuned for more adventures!",
                ending: new Ending { Number = 3, Title = "Under Construction" }
            );

            return nodes;
        }

        private void AddNode(string name, string text, Ending ending)
        {
            var node = new StoryNode
            {
                Name = name,
                Text = text,
                Ending = ending
            };
            nodes.Add(node.Name, node);
        }

        private void AddNode(string name, string text, params (string Text, string Link)[] choices)
        {
            var storyChoices = choices.Select(c => new StoryChoice
            {
                Text = c.Text,
                Link = c.Link
            }).ToList();

            var node = new StoryNode
            {
                Name = name,
                Text = text,
                Choices = storyChoices
            };
            nodes.Add(node.Name, node);
        }
    }
}
