
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



public class OTetromino: Tetromino 
{



    public OTetromino(Block.Type color, Texture2D texture, Vector2 origin): base(color, texture, origin)
    {

        currRotation = new TetrominoRotation(new int[2,2] {{1, 1}, {1, 1}}, new Vector2[2] {new Vector2(0, 1), new Vector2(1, 1)},  Rotation.Up);
        upRotation = currRotation;
        downRotation = new TetrominoRotation(new int[2,2] {{1, 1}, {1, 1}}, new Vector2[2] {new Vector2(0, 1), new Vector2(1, 1)}, Rotation.Down);
        leftRotation = new TetrominoRotation(new int[2,2] {{1, 1}, {1, 1}}, new Vector2[2] {new Vector2(0, 1), new Vector2(1, 1)}, Rotation.Left);
        rightRotation = new TetrominoRotation(new int[2,2] {{1, 1}, {1, 1}}, new Vector2[2] {new Vector2(0, 1), new Vector2(1, 1)}, Rotation.Right);



        /*
        currGrid = new int[2,2] {{1, 1}, {1, 1}};
        currSpots = new Vector2[2] {new Vector2(0, 1), new Vector2(1, 1)};
        upGrid = new int[2,2] {{1, 1}, {1, 1}};
        upSpots = new Vector2[2] {new Vector2(0, 1), new Vector2(1, 1)};
        downGrid = new int[2,2] {{1, 1}, {1, 1}};
        downSpots = new Vector2[2] {new Vector2(0, 1), new Vector2(1, 1)};
        leftGrid = new int[2,2] {{1, 1}, {1, 1}};
        leftSpots = new Vector2[2] {new Vector2(0, 1), new Vector2(1, 1)};
        rightGrid  = new int[2,2] {{1, 1}, {1, 1}};
        rightSpots = new Vector2[2] {new Vector2(0, 1), new Vector2(1, 1)};
        */
    }
    
    public override Vector2 rotate(Vector2 gridOrigin, Block.Type[][] board)
    {
        return origin;
    }

}