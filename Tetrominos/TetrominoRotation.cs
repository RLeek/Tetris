using Microsoft.Xna.Framework;

public class TetrominoRotation
{
    public int [,] grid { get; }
    public Vector2[] currSpots { get; }
    public Rotation rotation;

    public TetrominoRotation(int [,] grid, Vector2[] currSpots, Rotation rotation) {
        this.grid = grid;
        this.currSpots = currSpots;
        this.rotation = rotation;
    }

}