
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

public class TetrominoGenerator 
{
    private Random rand = new Random();        
    private Texture2D _texture;

    public TetrominoGenerator(Texture2D texture) {
        _texture = texture;

    }

    public Tetromino GenerateTetromino() {
        Tetromino piece = null;

        switch(rand.Next(7))
        {
            case 0: 
            {
                piece = new ITetromino((Block.Type)(rand.Next(5)+1), _texture, new Vector2(275+88, 20));
                break;
            }
            case 1: 
            {
                piece = new JTetromino((Block.Type)(rand.Next(5)+1), _texture, new Vector2(275+88, 20));
                break;
            }
            case 2: 
            {
                piece = new LTetromino((Block.Type)(rand.Next(5)+1), _texture, new Vector2(275+88, 20));
                break;
            }
            case 3: 
            {
                piece = new OTetromino((Block.Type)(rand.Next(5)+1), _texture, new Vector2(275+88, 20));
                break;
            }
            case 4: 
            {
                piece = new STetromino((Block.Type)(rand.Next(5)+1), _texture, new Vector2(275+88, 20));
                break;
            }
            case 5: 
            {
                piece = new TTetromino((Block.Type)(rand.Next(5)+1), _texture, new Vector2(275+88, 20));
                break;
            }
            case 6: 
            {
                piece = new ZTetromino((Block.Type)(rand.Next(5)+1), _texture, new Vector2(275+88, 20));
                break;
            }
        }
    
        return piece;
    }



}