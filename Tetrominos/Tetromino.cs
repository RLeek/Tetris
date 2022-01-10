using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Block.BlockExtensions;

public abstract class Tetromino 
{
    // When timeElapsed > certain point then perform action and set time Elapsed to 0
    // If collided, then set collided true if not already true and set timeElapsed to 0, else if collided true already, then perform action when timeElapsed > certain point
    // When to add to board 

    // Technically a finite state machine?
    public Block.Type color { get; set; }
    public Vector2 origin { get; set; }
    private Texture2D _texture; 

    private bool collided;
    private double timeElapsed;

    public TetrominoRotation currRotation;
    protected TetrominoRotation upRotation;
    protected TetrominoRotation downRotation;
    protected TetrominoRotation leftRotation;
    protected TetrominoRotation rightRotation;

    public Tetromino(Block.Type color, Texture2D texture, Vector2 origin) {
        this.color = color;
        _texture = texture; 
        this.origin = origin;
        _texture.SetData(new Color[] {Color.White});    
    }

    public virtual Vector2 rotate(Vector2 gridOrigin, Block.Type[][] board)
    {
        switch (currRotation.rotation)
        {
            case Rotation.Up:
            {
                if (checkValidPosition(origin, rightRotation.grid, gridOrigin, board))
                {
                    currRotation = rightRotation;
                } else if (checkValidPosition(new Vector2(origin.X-22, origin.Y), rightRotation.grid, gridOrigin, board))
                {
                    origin = new Vector2(origin.X-22, origin.Y);
                    currRotation = rightRotation;
                }  else if (checkValidPosition(new Vector2(origin.X-22, origin.Y+22), rightRotation.grid, gridOrigin, board))
                {
                    origin = new Vector2(origin.X-22, origin.Y+22);
                    currRotation = rightRotation;
                }  else if (checkValidPosition(new Vector2(origin.X, origin.Y-44), rightRotation.grid, gridOrigin, board))
                {
                    origin = new Vector2(origin.X, origin.Y-44);
                    currRotation = rightRotation;
                }  else if (checkValidPosition(new Vector2(origin.X-22, origin.Y-44), rightRotation.grid, gridOrigin, board))
                {
                    origin = new Vector2(origin.X-22, origin.Y-44);
                    currRotation = rightRotation;
                }  
                break;
            }

            case Rotation.Right:
            {
                if (checkValidPosition(origin, downRotation.grid, gridOrigin, board))
                {
                    currRotation = downRotation;
                } else if (checkValidPosition(new Vector2(origin.X+22, origin.Y), downRotation.grid, gridOrigin, board))
                {
                    origin = new Vector2(origin.X+22, origin.Y);
                    currRotation = downRotation;
                }  else if (checkValidPosition(new Vector2(origin.X+22, origin.Y-22), downRotation.grid, gridOrigin, board))
                {
                    origin = new Vector2(origin.X+22, origin.Y-22);
                    currRotation = downRotation;
                }  else if (checkValidPosition(new Vector2(origin.X, origin.Y+44), downRotation.grid, gridOrigin, board))
                {
                    origin = new Vector2(origin.X, origin.Y+44);
                    currRotation = downRotation;
                }  else if (checkValidPosition(new Vector2(origin.X+22, origin.Y+44), downRotation.grid, gridOrigin, board))
                {
                    origin = new Vector2(origin.X+22, origin.Y+44);
                    currRotation = downRotation;
                }  
                break;
            }
            case Rotation.Down:
            {
                if (checkValidPosition(origin, leftRotation.grid, gridOrigin, board))
                {
                    currRotation = leftRotation;
                } else if (checkValidPosition(new Vector2(origin.X+22, origin.Y), leftRotation.grid, gridOrigin, board))
                {
                    origin = new Vector2(origin.X+22, origin.Y);
                    currRotation = leftRotation;
                }  else if (checkValidPosition(new Vector2(origin.X+22, origin.Y+22), leftRotation.grid, gridOrigin, board))
                {
                    origin = new Vector2(origin.X+22, origin.Y+22);
                    currRotation = leftRotation;
                }  else if (checkValidPosition(new Vector2(origin.X, origin.Y-44), leftRotation.grid, gridOrigin, board))
                {
                    origin = new Vector2(origin.X, origin.Y-44);
                    currRotation = leftRotation;
                }  else if (checkValidPosition(new Vector2(origin.X+22, origin.Y-44), leftRotation.grid, gridOrigin, board))
                {
                    origin = new Vector2(origin.X+22, origin.Y-44);
                    currRotation = leftRotation;
                }  
                break;            
            }
            case Rotation.Left:
            {
                if (checkValidPosition(origin, upRotation.grid, gridOrigin, board))
                {
                    currRotation = upRotation;
                } else if (checkValidPosition(new Vector2(origin.X-22, origin.Y), upRotation.grid, gridOrigin, board))
                {
                    origin = new Vector2(origin.X-22, origin.Y);
                    currRotation = upRotation;
                }  else if (checkValidPosition(new Vector2(origin.X-22, origin.Y-22), upRotation.grid, gridOrigin, board))
                {
                    origin = new Vector2(origin.X-22, origin.Y-22);
                    currRotation = upRotation;
                }  else if (checkValidPosition(new Vector2(origin.X, origin.Y+44), upRotation.grid, gridOrigin, board))
                {
                    origin = new Vector2(origin.X, origin.Y+44);
                    currRotation = upRotation;
                }  else if (checkValidPosition(new Vector2(origin.X-22, origin.Y+44), upRotation.grid, gridOrigin, board))
                {
                    origin = new Vector2(origin.X-22, origin.Y+44);
                    currRotation = upRotation;
                }  
                break;    
            }
        }
        return origin;
    }

    public static bool checkValidPosition(Vector2 newOrigin, int[,] newGrid, Vector2 gridOrigin, Block.Type[][] board) 
    {
        if (!checkBoundary(newOrigin, newGrid, gridOrigin, board)) 
        {
            return false;
        }

        if (!checkCollision(newOrigin, newGrid, gridOrigin, board)) 
        {
            return false;
        }

        return true;
    }

    private static bool checkCollision(Vector2 newOrigin, int[,] newGrid, Vector2 gridOrigin, Block.Type[][] board)
    {   
        Vector2 Coord = newOrigin;
        Coord.X -= gridOrigin.X;
        Coord.Y -= gridOrigin.Y;
        Coord.X = Coord.X/(22);
        Coord.Y = Coord.Y/(22);

        for (int i = 0; i < newGrid.GetLength(0); i++) 
        {
            for (int i2 = 0; i2 < newGrid.GetLength(1); i2++) 
            {
                if ((newGrid[i, i2] > 0) && (board[i + (int)Coord.Y][i2 + (int)Coord.X] != 0))
                {
                    return false;
                }
            }
        }
        return true;
    }

    private static bool checkBoundary(Vector2 newOrigin, int[,] newGrid, Vector2 gridOrigin, Block.Type[][] board) 
    {
        //Left side out of boundaries
        if (newOrigin.X < gridOrigin.X) 
        {
            int overflow = (int)(gridOrigin.X - newOrigin.X)/22;
            for (int i = 0; i < newGrid.GetLength(0); i++) 
            {
                for (int i2 = 0; i2 < overflow; i2++) 
                {
                    if (newGrid[i,i2] > 0) 
                    {
                        return false;
                    }
                }
            }
        }
        
        //Right side of boundaries
        if ((newOrigin.X + (newGrid.GetLength(1) * 22)) > (gridOrigin.X + (Board.width *22))) 
        {
            int overflow = (int)((newOrigin.X + (newGrid.GetLength(1) * 22)) - (gridOrigin.X + (Board.width*22)))/22;
            for (int i = 0; i < newGrid.GetLength(0); i++) 
            {
                for (int i2 = newGrid.GetLength(1)-overflow; i2 < newGrid.GetLength(1); i2++) 
                {
                    if (newGrid[i, i2] > 0) 
                    {
                        return false;
                    }
                }
            }
        }
        
        //Bottom side of boundaries
        if ((newOrigin.Y + (newGrid.GetLength(0) *22)) > (gridOrigin.Y + (Board.height*22)))
        {
            int overflow = (int)((newOrigin.Y + (newGrid.GetLength(0) *22)) - (gridOrigin.Y + (Board.height*22)))/22;
            for (int i = newGrid.GetLength(0)-overflow; i < newGrid.GetLength(0); i++) 
            {
                for (int i2 = 0; i2 < newGrid.GetLength(1); i2++)
                {
                    if (newGrid[i, i2] > 0)
                    {
                        return false;
                    }
                } 
            }
        }

        return true;    
    }

    public void moveLeft(Vector2 gridOrigin, Block.Type [][] board)
    {
        if (checkValidPosition(new Vector2(origin.X - 22, origin.Y), currRotation.grid, gridOrigin, board)) {
            _moveLeft();
        }
    }

    public void moveRight(Vector2 gridOrigin, Block.Type [][] board)
    {
        if (checkValidPosition(new Vector2(origin.X + 22, origin.Y), currRotation.grid, gridOrigin, board)) {
            _moveRight();
        }
    }

    public void moveDown(Vector2 gridOrigin, Block.Type [][] board)
    {
        if (checkValidPosition(new Vector2(origin.X, origin.Y+22), currRotation.grid, gridOrigin, board)) {
            _moveDown();
        }
    }

    private void _moveDown()
    {
        origin = new Vector2(origin.X, origin.Y + 22);
    }

    private void _moveRight()
    {
        origin = new Vector2(origin.X + 22, origin.Y);
    }

    private void _moveLeft()
    {
        origin = new Vector2(origin.X - 22, origin.Y);
    }



    public void Draw(SpriteBatch spriteBatch) 
    {
        Vector2 currPos = origin;
        for (int i = 0; i < currRotation.grid.GetLength(0); i++)
        {
            for (int i2 = 0; i2 < currRotation.grid.GetLength(1); i2 ++)
            {
                if (currRotation.grid[i, i2] == 1)
                {
                    spriteBatch.Draw(_texture, new Rectangle((int)currPos.X, (int)currPos.Y, 20, 20), this.color.getColor());
                }
                currPos.X += 22;
            }
            currPos.X = origin.X; 
            currPos.Y +=22;
        }
    }

    public bool Update(GameTime gameTime, int score, Vector2 gridOrigin, Block.Type[][] board) 
    {
        //Shift downwards at certain times
        //If collision then wait 1 sec and stop
        timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;

        // First check if currently collided
        if (!collided) 
        {
            // Not currently collided 
            // Then do what is expected
            if (timeElapsed > (1 - (score/50 * 0.025)))
            {
                timeElapsed = 0;
                _moveDown();
            }
            
            if (!checkValidPosition(new Vector2(origin.X, origin.Y+22), currRotation.grid, gridOrigin, board))
            {
                //Currently touching
                collided = true;
            }
            return false;
        } else 
        {
            // First check that we are still collided 
            if (checkValidPosition(new Vector2(origin.X, origin.Y+22), currRotation.grid, gridOrigin, board))
            {
                //Currently touching
                collided = false;
                timeElapsed = 0;
                return false;
            }

            // Still collided
            if (timeElapsed > 1) 
            {     
                return true;
            }
            return false;
        }
    }

    public void DrawPhantom(SpriteBatch spriteBatch, Vector2 boardOrigin, Block.Type[][] board)
    {
        Vector2 currPos = calculatePhantomPosition(boardOrigin, board);
        for (int i = 0; i < currRotation.grid.GetLength(0); i++)
        {
            for (int i2 = 0; i2 < currRotation.grid.GetLength(1); i2 ++)
            {                if (currRotation.grid[i, i2] == 1)
                {
                    spriteBatch.Draw(_texture, new Rectangle((int)currPos.X, (int)currPos.Y, 20, 20), Color.White);
                }

                currPos.X += 22;
            }
            currPos.X = origin.X; 
            currPos.Y +=22;
        }

    }


    public Vector2 calculatePhantomPosition(Vector2 boardOrigin, Block.Type[][] board)
    {
        // We know our current origin
        // So we shift downwards check the hot spots and then continue

        Vector2 origin = this.origin;
        origin.X -= boardOrigin.X;
        origin.Y -= boardOrigin.Y;
        origin.X  = origin.X/22;
        origin.Y = origin.Y/22 +1;

        while(true)
        {
            // We want the same thing except we only check the hotspots and if it exceeds the lower boundary
            if (!checkBoundary(new Vector2 (origin.X *22 + boardOrigin.X, origin.Y *22 + boardOrigin.Y), currRotation.grid, boardOrigin, board))
            {
                break;
            }

            bool collision = false;
            // Check hotspots
            for (int i = 0; i < currRotation.currSpots.GetLength(0); i++)
            {
                if (board[(int)(origin.Y + currRotation.currSpots[i].Y)][(int)(origin.X + currRotation.currSpots[i].X)] > 0)
                {
                    collision = true;
                    break;
                }
            }
            if (collision) {
                break;
            }
            origin.Y +=1;
        }       

        origin.Y-=1;
        return new Vector2 (this.origin.X, origin.Y *22 + boardOrigin.Y);
    }

}