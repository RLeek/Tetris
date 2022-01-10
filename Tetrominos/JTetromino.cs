
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



public class JTetromino: Tetromino 
{
    public JTetromino(Block.Type color, Texture2D texture, Vector2 origin): base(color, texture, origin)
    {
        currRotation = new TetrominoRotation(new int[3,3] {{1, 0, 0}, {1, 1, 1}, {0, 0, 0}}, new Vector2[3] {new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 1)},  Rotation.Up);
        upRotation = currRotation;
        downRotation = new TetrominoRotation(new int[3,3] {{0, 0, 0}, {1, 1, 1}, {0, 0, 1}}, new Vector2[3] {new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 2)}, Rotation.Down);
        leftRotation = new TetrominoRotation(new int[3,3] {{0, 1, 0}, {0, 1, 0}, {1, 1, 0}}, new Vector2[2] {new Vector2(0, 2), new Vector2(1, 2)}, Rotation.Left);
        rightRotation = new TetrominoRotation(new int[3,3] {{0, 1, 1}, {0, 1, 0}, {0, 1, 0}}, new Vector2[2] {new Vector2(1, 2), new Vector2(2, 0)}, Rotation.Right);

    /*
        currGrid = new int[3,3] {{1, 0, 0}, {1, 1, 1}, {0, 0, 0}};
        currSpots = new Vector2[3] {new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 1)};
        
        upGrid =  new int[3,3] {{1, 0, 0}, {1, 1, 1}, {0, 0, 0}};
        upSpots = new Vector2[3] {new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 1)};

        downGrid = new int[3,3] {{0, 0, 0}, {1, 1, 1}, {0, 0, 1}};
        downSpots = new Vector2[3] {new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 2)};

        leftGrid = new int[3,3] {{0, 1, 0}, {0, 1, 0}, {1, 1, 0}};
        leftSpots = new Vector2[2] {new Vector2(0, 2), new Vector2(1, 2)};

        rightGrid  = new int[3,3] {{0, 1, 1}, {0, 1, 0}, {0, 1, 0}};
        rightSpots = new Vector2[2] {new Vector2(1, 2), new Vector2(2, 0)};
    */
    }
}