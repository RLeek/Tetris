using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Block.BlockExtensions;




public class Board
{
    private Texture2D _texture;
    public static int height { get; } = 20;
    public static int width { get; } = 10; 
    public Vector2 origin { get; }
    public Block.Type[][] grid { get; set; } = new Block.Type[Board.height][];
    public Board(Vector2 origin, Texture2D texture)
    {
        this.origin = origin;

        _texture = texture; 
        _texture.SetData(new Color[] {Color.White});

        for (int i = 0; i < Board.height; i++)
        {
            grid[i] = new Block.Type[Board.width];
        }    
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Vector2 currPos = origin;

        for (int i = 0; i < Board.height; i++)
        {
            for (int i2 = 0; i2 < Board.width; i2++)
            {
                spriteBatch.Draw(_texture, new Rectangle((int)currPos.X, (int)currPos.Y, 20, 20), grid[i][i2].getColor());
                currPos.X += 22;
            }
            currPos.X = origin.X; 
            currPos.Y +=22;
        }
    }

    private int Update(Vector2 origin) 
    {
        Vector2 coord = origin;
        coord.Y = (coord.Y - this.origin.Y)/22;
        int[] fullLines = new int [Board.height];

        // Check below coord.Y
        int fullLinesSize = 0; 
        for (int i = (int)coord.Y; i < Board.height; i++)
        {
            bool full = true;
            for (int i2 = 0; i2 < Board.width; i2++)
            {
                if (grid[i][i2] == Block.Type.None)
                {
                    full = false;
                    break;
                }
            }
            if (full)
            {
                fullLines[fullLinesSize]  = i;
                fullLinesSize++;
            }
        }

        if (fullLinesSize == 0) 
        {
            return 0;
        }

        Block.Type [][] newBoard = new Block.Type [Board.height][];

        int currIndex = 0;
        for (int i = 0; i < Board.height + fullLinesSize -currIndex; i++)
        {
            if (i < fullLinesSize)
            {
                newBoard[i] = new Block.Type[10];
            } else
            {
                if (i-fullLinesSize+currIndex == fullLines[currIndex]) {
                    currIndex +=1;
                    i -=1;
                    continue;
                }
                newBoard[i] = grid[i-fullLinesSize+currIndex];
            }
        } 

        this.grid = newBoard;
        return fullLinesSize * 10;
    }

    public int Update(int [,] shape, Block.Type color, Vector2 origin)
    {
        Vector2 coord = origin;
        coord.X = (coord.X-this.origin.X)/22;
        coord.Y = (coord.Y-this.origin.Y)/22;

        for (int i = 0; i < shape.GetLength(0); i++) 
        {
            for (int i2 = 0; i2 < shape.GetLength(1); i2++) 
            {
                if (shape[i, i2] > 0)
                {
                    grid[i + (int)coord.Y][i2 + (int)coord.X] = color;
                }
            }
        }
        return Update(origin);
    }



    public void Clear()
    {
        for (int i = 0; i < Board.height; i++)
        {
            grid[i] = new Block.Type[Board.width];
        }     
    }
}
