using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;




public class TetrisGameState : GameState
{
    private Score _score;
    private Board _board;
    private Tetromino _tetromino;
    private TetrominoGenerator _tetrominoGenerator;
    private KeyboardState _prevKeyboardState;    
    private double _timeElapsed;

    public TetrisGameState(SpriteBatch spriteBatch): base(spriteBatch)
    {
    }

    public override void Initialize()
    {
        //pass
    }

    public override void LoadContent()
    {
        _score = new Score(GameManager.content.Load<SpriteFont>("Score"), 0, new Vector2(550,200)); 
        _board = new Board(new Vector2(275, 20), new Texture2D(GameManager.graphicsDevice, 1, 1));
        _tetrominoGenerator = new TetrominoGenerator(new Texture2D(GameManager.graphicsDevice, 1, 1));
        _tetromino = _tetrominoGenerator.GenerateTetromino();
    }

    public override void Update(GameTime gameTime, GameManager gameManager)
    {
        if (!Tetromino.checkValidPosition(_tetromino.origin, _tetromino.currRotation.grid, _board.origin, _board.grid))
        {
            gameManager.currGameState = new RestartMenu(_spriteBatch, _score.score);
            gameManager.currGameState.LoadContent();
        }


        _timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;

        KeyboardState currState = Keyboard.GetState();

        if (currState.IsKeyDown(Keys.Left) && _prevKeyboardState.IsKeyUp(Keys.Left))
        {
            _timeElapsed = 0;
            _tetromino.moveLeft(_board.origin, _board.grid);
        }
        if (currState.IsKeyDown(Keys.Left) && (_timeElapsed > 0.1))
        {
            _timeElapsed = 0;
            _tetromino.moveLeft(_board.origin, _board.grid);
        }

        if (currState.IsKeyDown(Keys.Right) && _prevKeyboardState.IsKeyUp(Keys.Right))
        {
            _timeElapsed = 0;
            _tetromino.moveRight(_board.origin, _board.grid);
        }
        if (currState.IsKeyDown(Keys.Right) && (_timeElapsed > 0.1))
        {
            _timeElapsed = 0;
            _tetromino.moveRight(_board.origin, _board.grid);
        }

        if (currState.IsKeyDown(Keys.Down) && _prevKeyboardState.IsKeyUp(Keys.Down))
        {
            _timeElapsed = 0;
            _tetromino.moveDown(_board.origin, _board.grid);
        }
        if (currState.IsKeyDown(Keys.Down) && (_timeElapsed > 0.1))
        {
            _timeElapsed = 0;
            _tetromino.moveDown(_board.origin, _board.grid);
        }

        if (currState.IsKeyDown(Keys.Up) && _prevKeyboardState.IsKeyUp(Keys.Up))
        {
            _tetromino.rotate(_board.origin, _board.grid);
        }

        if (currState.IsKeyDown(Keys.Space) && _prevKeyboardState.IsKeyUp(Keys.Space))
        {
            _score.score += _board.Update(_tetromino.currRotation.grid, _tetromino.color, _tetromino.calculatePhantomPosition(_board.origin, _board.grid));
            _tetromino = _tetrominoGenerator.GenerateTetromino();
        } else if (_tetromino.Update(gameTime, _score.score, _board.origin, _board.grid)) 
        {
            //First draw it to the board;
            _score.score += _board.Update(_tetromino.currRotation.grid, _tetromino.color, _tetromino.origin);
            _tetromino = _tetrominoGenerator.GenerateTetromino();
        } 

        _prevKeyboardState = currState;
    }

    public override void Draw(GameTime gameTime)
    {
        _board.Draw(_spriteBatch);
        _tetromino.DrawPhantom(_spriteBatch, _board.origin, _board.grid);
        _tetromino.Draw(_spriteBatch);
        _score.Draw(_spriteBatch);

    }
}
