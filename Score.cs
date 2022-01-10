using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Score 
{
    private SpriteFont _font;
    public int score { get; set; }
    private Vector2 origin { get; set; }

    public Score(SpriteFont font, int score, Vector2 origin) 
    {
        this.score = score;
        _font = font;
        this.origin = origin;
    }

    public void Draw(SpriteBatch spriteBatch) 
    {
        spriteBatch.DrawString(_font,"Score:" + score, origin, Color.Black);
    }

}