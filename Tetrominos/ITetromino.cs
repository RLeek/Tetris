
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



public class ITetromino: Tetromino 
{
    public ITetromino(Block.Type color, Texture2D texture, Vector2 origin): base(color, texture, origin)
    {

        currRotation = new TetrominoRotation(new int[4,4] {{0, 0, 0, 0}, {1, 1, 1, 1}, {0, 0, 0, 0}, {0,0, 0, 0}}, new Vector2[4] {new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 1), new Vector2(3, 1)},  Rotation.Up);
        upRotation = currRotation;
        downRotation = new TetrominoRotation(new int[4,4] {{0, 0, 0, 0}, {0, 0, 0, 0}, {1, 1, 1, 1}, {0,0, 0, 0}}, new Vector2[4] {new Vector2(0, 2), new Vector2(1, 2), new Vector2(2, 2), new Vector2(3, 2)}, Rotation.Down);
        leftRotation = new TetrominoRotation(new int[4,4] {{0, 1, 0, 0}, {0, 1, 0, 0}, {0, 1, 0, 0}, {0, 1, 0, 0}}, new Vector2[1] {new Vector2(1, 3)}, Rotation.Left);
        rightRotation = new TetrominoRotation(new int[4,4] {{0, 0, 1, 0}, {0, 0, 1, 0}, {0, 0, 1, 0}, {0, 0, 1, 0}}, new Vector2[1] {new Vector2(2, 3)}, Rotation.Right);


        /*
        currGrid = new int[4,4] {{0, 0, 0, 0}, {1, 1, 1, 1}, {0, 0, 0, 0}, {0,0, 0, 0}};
        currSpots = new Vector2[4] {new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 1), new Vector2(3, 1)};

        upGrid = new int[4,4] {{0, 0, 0, 0}, {1, 1, 1, 1}, {0, 0, 0, 0}, {0,0, 0, 0}};
        upSpots = new Vector2[4] {new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 1), new Vector2(3, 1)};

        downGrid = new int[4,4] {{0, 0, 0, 0}, {0, 0, 0, 0}, {1, 1, 1, 1}, {0,0, 0, 0}};
        downSpots = new Vector2[4] {new Vector2(0, 2), new Vector2(1, 2), new Vector2(2, 2), new Vector2(3, 2)};

        leftGrid = new int[4,4] {{0, 1, 0, 0}, {0, 1, 0, 0}, {0, 1, 0, 0}, {0, 1, 0, 0}};
        leftSpots = new Vector2[1] {new Vector2(1, 3)};

        rightGrid  = new int[4,4] {{0, 0, 1, 0}, {0, 0, 1, 0}, {0, 0, 1, 0}, {0, 0, 1, 0}};
        rightSpots = new Vector2[1] {new Vector2(2, 3)};
        */
        
    }
    


    public override Vector2 rotate(Vector2 gridOrigin, Block.Type[][] board)
    {
        Vector2 newOrigin = origin;
        switch (currRotation.rotation)
        {
            case Rotation.Up:
            {
                if (checkValidPosition(newOrigin, leftRotation.grid, gridOrigin, board))
                {
                    currRotation = leftRotation;
                } else if (checkValidPosition(new Vector2(newOrigin.X-44, newOrigin.Y), leftRotation.grid, gridOrigin, board))
                {
                    newOrigin = new Vector2(newOrigin.X-44, newOrigin.Y);
                    currRotation = leftRotation;
                }  else if (checkValidPosition(new Vector2(newOrigin.X+22, newOrigin.Y), leftRotation.grid, gridOrigin, board))
                {
                    newOrigin = new Vector2(newOrigin.X+22, newOrigin.Y);
                    currRotation = leftRotation;
                }  else if (checkValidPosition(new Vector2(newOrigin.X-44, newOrigin.Y-22), leftRotation.grid, gridOrigin, board))
                {
                    newOrigin = new Vector2(newOrigin.X-44, newOrigin.Y-22);
                    currRotation = leftRotation;
                }  else if (checkValidPosition(new Vector2(newOrigin.X+ 22, newOrigin.Y+44), leftRotation.grid, gridOrigin, board))
                {
                    newOrigin = new Vector2(newOrigin.X+ 22, newOrigin.Y+44);
                    currRotation = leftRotation;
                }  
                break;
            }
            case Rotation.Right:
            {
                if (checkValidPosition(newOrigin, downRotation.grid, gridOrigin, board))
                {
                    currRotation = downRotation;
                } else if (checkValidPosition(new Vector2(newOrigin.X-22, newOrigin.Y), downRotation.grid, gridOrigin, board))
                {
                    newOrigin = new Vector2(newOrigin.X-22, newOrigin.Y);
                    currRotation = downRotation;
                }  else if (checkValidPosition(new Vector2(newOrigin.X+44, newOrigin.Y), downRotation.grid, gridOrigin, board))
                {
                    newOrigin = new Vector2(newOrigin.X+44, newOrigin.Y);
                    currRotation = downRotation;
                }  else if (checkValidPosition(new Vector2(newOrigin.X-22, newOrigin.Y+44), downRotation.grid, gridOrigin, board))
                {
                    newOrigin = new Vector2(newOrigin.X-22, newOrigin.Y+44);
                    currRotation = downRotation;
                }  else if (checkValidPosition(new Vector2(newOrigin.X+44, newOrigin.Y-22), downRotation.grid, gridOrigin, board))
                {
                    newOrigin = new Vector2(newOrigin.X+44, newOrigin.Y-22);
                    currRotation = downRotation;
                }  
                break;
            }
            case Rotation.Down:
            {
                if (checkValidPosition(newOrigin, rightRotation.grid, gridOrigin, board))
                {
                    currRotation = rightRotation;
                } else if (checkValidPosition(new Vector2(newOrigin.X+44, newOrigin.Y), rightRotation.grid, gridOrigin, board))
                {
                    newOrigin = new Vector2(newOrigin.X+44, newOrigin.Y);
                    currRotation = rightRotation;
                }  else if (checkValidPosition(new Vector2(newOrigin.X-22, newOrigin.Y), rightRotation.grid, gridOrigin, board))
                {
                    newOrigin = new Vector2(newOrigin.X-22, newOrigin.Y);
                    currRotation = rightRotation;
                }  else if (checkValidPosition(new Vector2(newOrigin.X+44, newOrigin.Y+22), rightRotation.grid, gridOrigin, board))
                {
                    newOrigin = new Vector2(newOrigin.X+44, newOrigin.Y+22);
                    currRotation = rightRotation;
                }  else if (checkValidPosition(new Vector2(newOrigin.X-22, newOrigin.Y-44), rightRotation.grid, gridOrigin, board))
                {
                    newOrigin = new Vector2(newOrigin.X-22, newOrigin.Y-44);
                    currRotation = rightRotation;
                }  
                break;            
            }
            case Rotation.Left:
            {
                if (checkValidPosition(newOrigin, upRotation.grid, gridOrigin, board))
                {
                    currRotation = upRotation;
                } else if (checkValidPosition(new Vector2(newOrigin.X+22, newOrigin.Y), upRotation.grid, gridOrigin, board))
                {
                    newOrigin = new Vector2(newOrigin.X+22, newOrigin.Y);
                    currRotation = upRotation;
                }  else if (checkValidPosition(new Vector2(newOrigin.X-44, newOrigin.Y), upRotation.grid, gridOrigin, board))
                {
                    newOrigin = new Vector2(newOrigin.X-44, newOrigin.Y);
                    currRotation = upRotation;
                }  else if (checkValidPosition(new Vector2(newOrigin.X+22, newOrigin.Y-44), upRotation.grid, gridOrigin, board))
                {
                    newOrigin = new Vector2(newOrigin.X+22, newOrigin.Y-44);
                    currRotation = upRotation;
                }  else if (checkValidPosition(new Vector2(newOrigin.X-44, newOrigin.Y+22), upRotation.grid, gridOrigin, board))
                {
                    newOrigin = new Vector2(newOrigin.X-44, newOrigin.Y+22);
                    currRotation = upRotation;
                }  
                break;    
            }
        }
        origin = newOrigin;
        return newOrigin;
    }


}