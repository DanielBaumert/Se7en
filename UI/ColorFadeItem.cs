using System.Drawing;

namespace Se7en.UI
{
    public class ColorFadeItem
    {
        public Color Color { get; set; }
        /// <summary>
        /// Value between 0 and 1
        /// </summary>
        public float Position { get; set; }

        public ColorFadeItem()
        {
            Color = Color.Transparent;
            Position = 0;
        }

        public ColorFadeItem(Color color, float position)
        {
            Color = color;
            Position = position;
        }
    }
}
