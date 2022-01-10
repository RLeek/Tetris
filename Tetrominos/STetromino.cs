
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



public class STetromino: Tetromino 
{
    public STetromino(Block.Type color, Texture2D texture, Vector2 origin): base(color, texture, origin)
    {



        currRotation = new TetrominoRotation(new int[3,3] {{0, 1, 1}, {1, 1, 0}, {0, 0, 0}}, new Vector2[3] {new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 0)},  Rotation.Up);
        upRotation = currRotation;
        downRotation = new TetrominoRotation(new int[3,3] {{0, 0, 0}, {0, 1, 1}, {1, 1, 0}}, new Vector2[3] {new Vector2(0, 2), new Vector2(1, 2), new Vector2(2, 1)}, Rotation.Down);
        leftRotation = new TetrominoRotation(new int[3,3] {{1, 0, 0}, {1, 1, 0}, {0, 1, 0}}, new Vector2[2] {new Vector2(0, 1), new Vector2(1, 2)}, Rotation.Left);
        rightRotation = new TetrominoRotation(new int[3,3] {{0, 1, 0}, {0, 1, 1}, {0, 0, 1}}, new Vector2[2] {new Vector2(1, 1), new Vector2(2, 2)}, Rotation.Right);


        /*
        currGrid = new int[3,3] {{0, 1, 1}, {1, 1, 0}, {0, 0, 0}};
        currSpots = new Vector2[3] {new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 0)};

        upGrid = new int[3,3] {{0, 1, 1}, {1, 1, 0}, {0, 0, 0}};
        upSpots = new Vector2[3] {new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 0)};

        downGrid = new int[3,3] {{0, 0, 0}, {0, 1, 1}, {1, 1, 0}};
        downSpots = new Vector2[3] {new Vector2(0, 2), new Vector2(1, 2), new Vector2(2, 1)};

        leftGrid = new int[3,3] {{1, 0, 0}, {1, 1, 0}, {0, 1, 0}};
        leftSpots = new Vector2[2] {new Vector2(0, 1), new Vector2(1, 2)};

        rightGrid  = new int[3,3] {{0, 1, 0}, {0, 1, 1}, {0, 0, 1}};
        rightSpots = new Vector2[2] {new Vector2(1, 1), new Vector2(2, 2)};
        */

    }
    
}