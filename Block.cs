using Microsoft.Xna.Framework;

namespace Block {
    public enum Type 
    {
        None = 0,
        Red = 1, 
        Orange = 2,
        Yellow = 3,
        Green = 4,
        Blue = 5,
        Purple = 6
    }

    public static class BlockExtensions
    {
        public static Color getColor(this Type type)
        {
            switch (type)
            {
                case Type.None:
                {
                    return Color.Black;
                }
                case Type.Red:
                {
                    return Color.Red;
                }
                case Type.Orange:
                {
                    return Color.Orange;
                }
                case Type.Yellow:
                {
                    return Color.Yellow;
                }
                case Type.Green:
                {
                    return Color.Green;
                }
                case Type.Blue:
                {
                    return Color.Blue;
                }
                case Type.Purple:
                {
                    return Color.Purple;
                }
                default: 
                {
                    return Color.Black;
                }
            }
        }
    }
}