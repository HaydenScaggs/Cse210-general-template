// This defines a read-only struct named Position, which represents a point in a two-dimensional grid.
// The struct contains two integer fields: Top and Left, which represent the row and column coordinates of the point.
readonly struct Position
{
     // This is a constructor method that initializes a new Position instance with the specified row and column coordinates.
    public Position(int top, int left)
    {
        Top = top;
        Left = left;
    } 
    // These are property accessors that provide read-only access to the Top and Left fields.
    public int Top { get; }
    public int Left { get; }

    // These are two helper methods that return a new Position object offset by a specified number of rows or columns.
    // The methods do not modify the current object, but instead create a new one with the updated coordinates.
    public Position RightBy(int n) => new Position(Top, Left + n);
    public Position DownBy(int n) => new Position(Top + n, Left);
}