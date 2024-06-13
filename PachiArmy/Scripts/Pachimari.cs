namespace PachiArmy.Scripts
{
    public class Pachimari : Placeable
    {
        public GridPosition Position { get; set; }

        enum PachiState
        {
            Idle,
            Eating,
            Drinking,
            Playing,
            Exhausted,
            Pet
        }
        private PachiState state;
        private bool readyToExplode;

        const uint HAPPINESS_THRESHOLD = 100;
        private uint happiness;

        const uint MAX_HUNGER = 100;
        private uint hunger;

        const uint MAX_THIRST = 100;
        private uint thirst;


        public Pachimari()
        {
            // TODO don't default this to 0,0. Find a random open spot on the board
            Position = new GridPosition(0, 0);
        }

        // Click behavior
        public void Clicked()
        {
            bool exploded = TryExplode();
            if (!exploded)
            {
                Pet();
            }
        }
        private bool TryExplode()
        {
            return false;
        }
        private void Explode()
        {

        }
        private void Pet()
        {

        }

        // Hover behavior
        public string GetHoverText()
        {
            throw new NotImplementedException();
        }


        public string GetImage()
        {
            return "placeholders/pachimari.png";
        }

        // Tick
        public void ProcessTick()
        {

        }
        private void ProcessInteractions()
        {

        }
    }
}
