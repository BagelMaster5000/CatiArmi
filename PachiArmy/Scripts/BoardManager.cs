namespace PachiArmy.Scripts
{
    public static class BoardManager
    {
        public const uint ROWS = 8;
        public const uint COLS = 8;

        public static List<Placeable> ActivePlaceables = new List<Placeable>()
        {
            new Pachimari() { Position = new GridPosition(0,0)},
            new Pachimari() { Position = new GridPosition(0,1)},
            new Pachimari() { Position = new GridPosition(0,2)},
            new Pachimari() { Position = new GridPosition(0,3)},
        };

        private static bool[,] occupiedSpaces = new bool[ROWS, COLS];


        public static void MovePlaceable(Placeable movingPlaceable, GridPosition destination)
        {
            if (!GetSpaceOccupied(destination))
            {
                SetSpaceOccupied(movingPlaceable.Position, false);
                movingPlaceable.Position = destination;
                SetSpaceOccupied(movingPlaceable.Position, true);
            }
            else
            {
                var occupyingPlaceable = ActivePlaceables.Find(p => p.Position == destination);
                if (occupyingPlaceable != null)
                {
                    SwapPlaceables(movingPlaceable, occupyingPlaceable);
                }
            }
        }

        public static void SwapPlaceables(Placeable placeable1, Placeable placeable2)
        {
            var temp = placeable1.Position;
            placeable1.Position = placeable2.Position;
            placeable2.Position = temp;
        }

        public static bool TryFindOpenSpaceAndPlacePlaceable(Placeable placeable)
        {
            for (uint r = 0; r < ROWS; r++)
            {
                for (uint c = 0; c < COLS; c++)
                {
                    if (!IsSpaceOccupied(r, c))
                    {
                        placeable.Position.Row = r;
                        placeable.Position.Col = c;
                        SetSpaceOccupied(r, c, true);
                        ActivePlaceables.Add(placeable);

                        return true;
                    }
                }
            }

            return false;
        }

        public static void ProcessTick()
        {
            List<Pachimari> activePachis = ActivePlaceables.OfType<Pachimari>().ToList();
            foreach (Pachimari pachi in activePachis)
            {
                pachi.ProcessTick();
            }
        }


        public static bool IsSpaceOccupied(uint row, uint col) => occupiedSpaces[row, col];
        public static bool GetSpaceOccupied(GridPosition gridPosition) => occupiedSpaces[gridPosition.Row, gridPosition.Col];
        public static void SetSpaceOccupied(uint row, uint col, bool occupied) => occupiedSpaces[row, col] = occupied;
        public static void SetSpaceOccupied(GridPosition gridPosition, bool occupied) => occupiedSpaces[gridPosition.Row, gridPosition.Col] = occupied;
    }
}
