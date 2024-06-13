namespace PachiArmy.Scripts
{
    public class GridPosition
    {
        public uint Row;
        public uint Col;

        public GridPosition(uint row, uint column)
        {
            Row = row;
            Col = column;
        }

        public static GridPosition ParseGridPositionFromString(string gridPositionString)
        {
            try
            {
                string[] rowAndColumnString = gridPositionString.Split(' ');
                GridPosition gridPosition = new GridPosition(uint.Parse(rowAndColumnString[0]), uint.Parse(rowAndColumnString[1]));

                return gridPosition;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Couldn't parse GridPosition from string " + gridPositionString + ". Make sure format is \"<row> <col>\".\n", e.Message);

                return null;
            }
        }

        public override string ToString() => Row + " " + Col;
    }
}
