namespace Origins
{
    internal class OldStoryBuilder
    {
        public static Dictionary<string, StoryNode> Load()
        {
            var nodes = new Dictionary<string, StoryNode>();

            var introNode = new StoryNode
            {
                Name = "intro",
                Text = "You wake up in your spaceship, good old Mineral Rider 1.",
                Choices =
                [
                    new StoryChoice { Text = "Look around", Link = "turned_left" },
                    new StoryChoice { Text = "Go back to sleep", Link = "back_to_sleep" }
                ]
            };
            nodes.Add("intro", introNode);

            var backToSleepNode = new StoryNode
            {
                Name = "back_to_sleep",
                Text = "You try to go back to sleep but a rotten smell wakes you up...",
                Choices =
                [
                    new StoryChoice { Text = "Look around", Link = "turned_left" },
                    new StoryChoice { Text = "Go back to sleep", Link = "drifting_death" }
                ]
            };
            nodes.Add("back_to_sleep", backToSleepNode);

            var driftingDeathNode = new StoryNode
            {
                Name = "drifting_death",
                Text = "The putrid smell consumes all the oxygen of your body. " +
                    "You drift into space forever, into an eternal nightmare.",
                Choices = [],
            };
            nodes.Add("drifting_death", driftingDeathNode);

            var turnedLeftNode = new StoryNode
            {
                Name = "turned_left",
                Text = "You turn your head slowly to your left... you see your captain, " +
                    "or what's left of him, with a very dead expression on his face.",
                Choices =
                [
                    new StoryChoice { Text = "Look around", Link = "found_lever" },
                    new StoryChoice { Text = "Go back to sleep", Link = "drifting_death" }
                ]
            };
            nodes.Add("turned_left", turnedLeftNode);

            var foundLeverNode = new StoryNode
            {
                Name = "found_lever",
                Text = "You see a lever that gets your attention, which says 'EJECT'",
                Choices =
                [
                    new StoryChoice { Text = "Push lever", Link = "expelled" },
                    new StoryChoice { Text = "Look around", Link = "found_ship_controls" },
                    new StoryChoice { Text = "Go back to sleep", Link = "drifting_death" },
                ]
            };
            nodes.Add("found_lever", foundLeverNode);

            var foundShipControlsNode = new StoryNode
            {
                Name = "found_ship_controls",
                Text = "Now fully awake and fully scared, you decided to take a moment to think and you found the ship's instructions manual.",
                Choices =
                [
                    new StoryChoice { Text = "Push lever", Link = "expelled" },
                    new StoryChoice { Text = "Read manual", Link = "under_construction" },
                    new StoryChoice { Text = "Go back to sleep", Link = "drifting_death" }
                ]
            };
            nodes.Add("found_ship_controls", foundShipControlsNode);

            var expelledNode = new StoryNode
            {
                Name = "expelled",
                Text = "You are expelled into deep space... hopefully someone rescues you soon.",
                Choices = [],
            };
            nodes.Add("expelled", expelledNode);

            var underConstructionNode = new StoryNode
            {
                Name = "under_construction",
                Text = "This part of the story is still under construction. Stay tuned for more adventures!",
                Choices = new List<StoryChoice>(),
            };
            nodes.Add("under_construction", underConstructionNode);

            return nodes;
        }
    }
}
