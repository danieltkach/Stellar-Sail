namespace Origins
{
    internal class StoryNode
    {
        public string Name { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public List<StoryChoice> Choices { get; set; } = [];
        public Ending? Ending { get; set; } = null;
    }
}
