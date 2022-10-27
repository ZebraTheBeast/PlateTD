namespace PlateTD.Utilities.Grid
{
    public class GridCell<T>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Occupied { get; set; }
        public T Value { get; set; }

        public GridCell(int x, int y, bool occupied = false, T value = default(T))
        {
            X = x;
            Y = y;
            Occupied = occupied;
            Value = value;
        }
    }

}
