namespace PachiArmy.Scripts
{
    public interface Placeable
    {
        public Position Position { get; set; }

        public void Clicked();
        public string GetImage();
        public string GetHoverText();
    }
}
