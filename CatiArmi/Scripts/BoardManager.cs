﻿using CatiArmi.Pages;
using System.Timers;

namespace CatiArmi.Scripts
{
    public static class BoardManager
    {
        public const int ROWS = 8;
        public const int COLS = 8;

        public static bool timerStarted = false;

        private static List<Placeable> ActivePlaceables = new List<Placeable>();

        private static bool[,] occupiedSpaces = new bool[ROWS, COLS];

        public static Action ForceBoardRefresh = delegate { };
        public static void InvokeForceBoardRefresh() => ForceBoardRefresh?.Invoke();
        public static void ClearForceBoardRefresh() => ForceBoardRefresh = null;

        public static Action PachiTick = delegate { };
        public static void InvokePachiTick() => PachiTick?.Invoke();

        public static void Setup()
        {
            AddNewPachimari();
            AddNewFoodBowl();
            AddNewWaterBowl();
        }

        #region Board
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
            placeable.Position = new Position(0, 0);

            // Set up the places to check
            int[] randomRows = { 0, 1, 2, 3, 4, 5, 6, 7 };
            int[] randomCols = { 0, 1, 2, 3, 4, 5, 6, 7 };

            // Randomly pick a spot on the board continuously till an open one is found
            randomRows = RandomizeWithOrderByAndRandom(randomRows);
            for (int r = 0; r < ROWS; r++)
            {
                randomCols = RandomizeWithOrderByAndRandom(randomCols);

                for (int c = 0; c < COLS; c++)
                {
                    // Check the spot
                    if (!IsSpaceOccupied(randomRows[r], randomCols[c]))
                    {
                        placeable.Position.Row = randomRows[r];
                        placeable.Position.Col = randomCols[c];
                        SetSpaceOccupied(randomRows[r], randomRows[c], true);
                        ActivePlaceables.Add(placeable);

                        return true;
                    }
                }
            }

            return false;
        }

        public static bool TryFindOpenSpaceAndPlacePlaceable(Placeable placeable, int row, int col)
        {
            placeable.Position = new Position(0, 0);

            // Set up the places to check
            int distance = 2; // Can be changed as you please (or put in some kind of funky loop)

            int[] randomRows = new int[distance * 2 + 1];
            int[] randomCols = new int[distance * 2 + 1];

            int i = 0;
            for (int d = -distance; d < distance + 1; d++)
            {
                randomRows[i] = row + d;
                randomCols[i] = col + d;
                i++;
            }

            // Randomly pick a spot on the board continuously till an open one is found
            randomRows = RandomizeWithOrderByAndRandom(randomRows);
            for (int r = 0; r < randomRows.Length; r++)
            {
                randomCols = RandomizeWithOrderByAndRandom(randomCols);

                for (int c = 0; c < randomCols.Length; c++)
                {
                    // Make sure we don't go out of bounds nor use the center spot
                    if (randomRows[r] == row && randomCols[c] == col) continue;
                    else if (randomRows[r] < 0 || randomRows[r] >= ROWS) continue;
                    else if (randomCols[c] < 0 || randomCols[c] >= COLS) continue;
                    // Check the spot
                    else if (!IsSpaceOccupied(randomRows[r], randomCols[c]))
                    {
                        placeable.Position.Row = randomRows[r];
                        placeable.Position.Col = randomCols[c];
                        SetSpaceOccupied(randomRows[r], randomRows[c], true);
                        ActivePlaceables.Add(placeable);

                        return true;
                    }
                }
            }
            return false;
        }

        public static int[] RandomizeWithOrderByAndRandom(int[] array) => array.OrderBy(x => Random.Shared.Next()).ToArray(); // I got this off the internet (me being LAZY (sobs))

        public static void RemovePlaceable(Placeable placeable)
        {
            SetSpaceOccupied(placeable.Position, false);
            ActivePlaceables.Remove(placeable);
            placeable.Position = new Position(99, 99); // This is a scuffed way of removing it from the board. Fix if you have time

            ForceBoardRefresh?.Invoke();
        }

        public static void AddNewPachimari()
        {
            var pachi = new Pachimari();
            TryFindOpenSpaceAndPlacePlaceable(pachi);
        }
        public static void AddNewFoodBowl()
        {
            var foodbowl = new FoodBowl();
            TryFindOpenSpaceAndPlacePlaceable(foodbowl);
        }
        public static void AddNewWaterBowl()
        {
            var waterBowl = new WaterBowl();
            TryFindOpenSpaceAndPlacePlaceable(waterBowl);
        }
        public static void AddNewToy(int toyType)
        {
            var toy = new Toy();
            TryFindOpenSpaceAndPlacePlaceable(toy);
        }
        public static void AddNewSnack(int snackType)
        {
            var snack = new Snack();
            TryFindOpenSpaceAndPlacePlaceable(snack);
        }
        #endregion


        public static void PachiTicks(Object source, ElapsedEventArgs e)
        {
            List<Pachimari> pachimaris = GetAllActivePachis();
            foreach (Pachimari p in pachimaris)
            {
                p.ProcessTick();
            }

            InvokePachiTick();
        }

        #region Helpers
        public static List<InteractablePlaceable> GetAllAdjacentInteractablePlaceables(int row, int col)
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

        public static bool IsSpaceOccupied(int row, int col) => occupiedSpaces[row, col];
        public static bool GetSpaceOccupied(Position position) => occupiedSpaces[position.Row, position.Col];
        public static void SetSpaceOccupied(int row, int col, bool occupied) => occupiedSpaces[row, col] = occupied;
        public static void SetSpaceOccupied(Position position, bool occupied) => occupiedSpaces[position.Row, position.Col] = occupied;
        public static Placeable? TryGetPlaceableOnSpace(int row, int col) => ActivePlaceables.Find(p => p.Position.Row == row && p.Position.Col == col);
        public static Placeable? TryGetPlaceableOnSpace(Position gridPosition) => ActivePlaceables.Find(p => p.Position.Row == gridPosition.Row && p.Position.Col == gridPosition.Col);
        public static List<Placeable> GetAllActivePlaceables() => ActivePlaceables;
        public static List<Pachimari> GetAllActivePachis() => ActivePlaceables.OfType<Pachimari>().ToList();
        public static bool IsBoardFull() => ActivePlaceables.Count >= ROWS * COLS;
        #endregion
    }
}
