namespace CatiArmi.Scripts
{
    public interface Placeable
    {
        public Position Position { get; set; }

        public void Clicked();
        public void Hovered();
        public string GetImage();
        public string GetHoverText();
    }
}
