using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class GameState {
    protected SpriteBatch _spriteBatch;

    public GameState(SpriteBatch spriteBatch)
    {
        _spriteBatch = spriteBatch;
    }

    public abstract void Initialize();
    public abstract void LoadContent();
    public abstract void Update(GameTime gameTime, GameManager gameManager);
    public abstract void Draw(GameTime gameTime);

}