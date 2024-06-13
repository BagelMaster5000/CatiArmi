using Blazorise;

namespace PachiArmy.Scripts
{
    public static class BoardManager
    {
        public const uint ROWS = 8;
        public const uint COLS = 8;

        public static List<Placeable> ActivePlaceables = new List<Placeable>();

        private static bool[,] occupiedSpaces = new bool[ROWS, COLS];


        public static void MovePlaceable(Placeable movingPlaceable, Position destination)
        {
            if (!GetSpaceOccupied(destination))
            {
                SetSpaceOccupied(movingPlaceable.Position, false);
                movingPlaceable.Position = destination;
                SetSpaceOccupied(movingPlaceable.Position, true);
            }
            else
            {
                var occupyingPlaceable = ActivePlaceables.Find(p => p.Position.Row == destination.Row && p.Position.Col == destination.Col);
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
            var activePachis = ActivePlaceables.OfType<Pachimari>().ToList();
            foreach (var pachi in activePachis)
            {
                pachi.ProcessTick();
            }
        }

        public static List<InteractablePlaceable> GetAllAdjacentInteractablePlaceables(uint row, uint col)
        {
            var interactablePlaceables = ActivePlaceables.OfType<InteractablePlaceable>().ToList();
            var adjacentInteractablePlaceables = new List<InteractablePlaceable>();

            // Top left
            if (row - 1 >= 0 || col - 1 >= 0)
            {
                var placeable = interactablePlaceables.Find(p => p.Position.Row == row - 1 && p.Position.Col == col - 1);
                if (placeable != null)
                {
                    adjacentInteractablePlaceables.Add(placeable);
                }
            }
            // Top
            if (row - 1 >= 0)
            {
                var placeable = interactablePlaceables.Find(p => p.Position.Row == row - 1 && p.Position.Col == col);
                if (placeable != null)
                {
                    adjacentInteractablePlaceables.Add(placeable);
                }
            }
            // Top right
            if (row - 1 >= 0 || col + 1 >= 0)
            {
                var placeable = interactablePlaceables.Find(p => p.Position.Row == row - 1 && p.Position.Col == col + 1);
                if (placeable != null)
                {
                    adjacentInteractablePlaceables.Add(placeable);
                }
            }
            // Left
            if (col - 1 >= 0)
            {
                var placeable = interactablePlaceables.Find(p => p.Position.Row == row && p.Position.Col == col - 1);
                if (placeable != null)
                {
                    adjacentInteractablePlaceables.Add(placeable);
                }
            }
            // Right
            if (col + 1 >= 0)
            {
                var placeable = interactablePlaceables.Find(p => p.Position.Row == row && p.Position.Col == col + 1);
                if (placeable != null)
                {
                    adjacentInteractablePlaceables.Add(placeable);
                }
            }
            // Bottom left
            if (row + 1 >= 0 || col - 1 >= 0)
            {
                var placeable = interactablePlaceables.Find(p => p.Position.Row == row + 1 && p.Position.Col == col - 1);
                if (placeable != null)
                {
                    adjacentInteractablePlaceables.Add(placeable);
                }
            }
            // Bottom
            if (row + 1 >= 0)
            {
                var placeable = interactablePlaceables.Find(p => p.Position.Row == row + 1 && p.Position.Col == col);
                if (placeable != null)
                {
                    adjacentInteractablePlaceables.Add(placeable);
                }
            }
            // Bottom right
            if (row + 1 >= 0 || col + 1 >= 0)
            {
                var placeable = interactablePlaceables.Find(p => p.Position.Row == row + 1 && p.Position.Col == col + 1);
                if (placeable != null)
                {
                    adjacentInteractablePlaceables.Add(placeable);
                }
            }

            return adjacentInteractablePlaceables;
        }


        public static bool IsSpaceOccupied(uint row, uint col) => occupiedSpaces[row, col];
        public static bool GetSpaceOccupied(Position position) => occupiedSpaces[position.Row, position.Col];
        public static void SetSpaceOccupied(uint row, uint col, bool occupied) => occupiedSpaces[row, col] = occupied;
        public static void SetSpaceOccupied(Position position, bool occupied) => occupiedSpaces[position.Row, position.Col] = occupied;
        public static Placeable? TryGetPlaceableOnSpace(uint row, uint col) => ActivePlaceables.Find(p => p.Position.Row == row && p.Position.Col == col);
        public static Placeable? TryGetPlaceableOnSpace(Position gridPosition) => ActivePlaceables.Find(p => p.Position.Row == gridPosition.Row && p.Position.Col == gridPosition.Col);
    }
}
