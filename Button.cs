using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


// Fixing how we draw things here



// Work out the length of the sprite and then offset it, such that
// the origin is equivalent to the centre

// The size of the rectangle is essentially based on padding
    // Make that an option (?)

    // Work out size of rectangle and then offset it, such that 
    // the origin is equivalent to the centre

public class Button 
{
    private SpriteFont _font;
    private Texture2D _texture;
    private Vector2 _size;
    private Vector2 origin { get; set; }
    public string _text { get; set; }

    //probably want to have an onPress function(?)
    // i.e. when  clicked on  do some kind of functionality

    public Button(SpriteFont font, Texture2D texture, Vector2 origin, string text) 
    {
        _font = font;
        _text = text;

        _texture = texture;
        _texture.SetData(new Color[] {Color.White});

        _size = _font.MeasureString(_text);


        this.origin = origin;
    }

    public void Draw(SpriteBatch spriteBatch, MouseState mouseState) 
    {
        Vector2 offSetPos = origin;

        offSetPos.X -= _size.X/2;
        offSetPos.Y -= _size.Y/2;



        if (mouseState.X > (offSetPos.X-2) && mouseState.X < (offSetPos.X + _size.X + 2))
        {
            if (mouseState.Y > (offSetPos.Y-2) && mouseState.Y < (offSetPos.Y + _size.Y + 2))
            {
                spriteBatch.Draw(_texture, new Rectangle((int)(offSetPos.X-2), (int)(offSetPos.Y-2), (int)(_size.X+4), (int)(_size.Y+4)), Color.White);
            } else {
                spriteBatch.Draw(_texture, new Rectangle((int)(offSetPos.X-2), (int)(offSetPos.Y-2), (int)(_size.X+4), (int)(_size.Y+4)), Color.Gray);
            }
        } else {
            spriteBatch.Draw(_texture, new Rectangle((int)(offSetPos.X-2), (int)(offSetPos.Y-2), (int)(_size.X+4), (int)(_size.Y+4)), Color.Gray);
        }

        //New origin 
        spriteBatch.DrawString(_font, _text, offSetPos, Color.Black);
    }

    public bool click(MouseState mouseState)
    {
        Vector2 offSetPos = origin;

        offSetPos.X -= _size.X/2;
        offSetPos.Y -= _size.Y/2;

        if (mouseState.X > (offSetPos.X-2) && mouseState.X < (offSetPos.X + _size.X + 2))
        {
            if (mouseState.Y > (offSetPos.Y-2) && mouseState.Y < (offSetPos.Y + _size.Y + 2))
            {
                return true;
            }
        }

        return false;
    }

}