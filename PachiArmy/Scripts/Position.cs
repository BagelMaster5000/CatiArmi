namespace PachiArmy.Scripts
{
    public class Position
    {
        public uint Row;
        public uint Col;

        public Position(uint row, uint column)
        {
            Row = row;
            Col = column;
        }

        public static Position ParsePositionFromString(string gridPositionString)
        {
            try
            {
                string[] rowAndColumnString = gridPositionString.Split(' ');
                Position position = new Position(uint.Parse(rowAndColumnString[0]), uint.Parse(rowAndColumnString[1]));

                return position;
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
