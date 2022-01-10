using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class RestartMenu: GameState
{

    private Button _restart;
    private Button _exit; 
    private SpriteFont _font;
    private Vector2 _size;
    private Vector2 _screenSize;
    private MouseState _prevMouseState;
    public int score { get; set; }


    public RestartMenu(SpriteBatch spriteBatch, int score): base(spriteBatch)
    {   
        Viewport viewport = GameManager.graphicsDevice.Viewport;
        _screenSize = new Vector2(viewport.Width, viewport.Height);
        this.score = score;
    }

    public override void Initialize()
    {
        //pass
    }

    public override void LoadContent() 
    {
        _restart = new Button(GameManager.content.Load<SpriteFont>("Button"), new Texture2D(GameManager.graphicsDevice, 1, 1), new Vector2(_screenSize.X/2,200), "Restart");
        _exit = new Button(GameManager.content.Load<SpriteFont>("Button"), new Texture2D(GameManager.graphicsDevice, 1, 1), new Vector2(_screenSize.X/2,350), "Exit");
        _font = GameManager.content.Load<SpriteFont>("Title");
        _size = _font.MeasureString("Score: "  + score);
    }

    public override void Update(GameTime gameTime, GameManager gameManager)
    {
        MouseState currState = Mouse.GetState();
        if(currState.LeftButton == ButtonState.Pressed && _prevMouseState.LeftButton == ButtonState.Released)
        {
            // give mouse coordinates to each button
            if (_restart.click(currState))
            {
                gameManager.currGameState = new TetrisGameState(_spriteBatch);
                gameManager.currGameState.LoadContent();
            } else if (_exit.click(currState))
            {
                GameManager.self.Exit();
            }
        }
        _prevMouseState = currState;
    }

    public override void Draw(GameTime gameTime)
    {
        Vector2 offSetPos = new Vector2(_screenSize.X/2, 100);
        offSetPos.X -= _size.X/2;
        offSetPos.Y -= _size.Y/2;

        _spriteBatch.DrawString(_font, "Score: "  + score, offSetPos, Color.Black);
        _restart.Draw(_spriteBatch, Mouse.GetState());
        _exit.Draw(_spriteBatch, Mouse.GetState());
    }


}


