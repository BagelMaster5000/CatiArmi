namespace PachiArmy.Scripts
{
    public interface Placeable
    {
        public GridPosition Position { get; set; }

        public void Clicked();
        public string GetImage();
        public string GetHoverText();
    }
}
