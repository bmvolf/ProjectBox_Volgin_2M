using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectBox_Volgin_2M.Classes.HUD
{
    public class Label
    {
        private Vector2 position;
        private Color color;
        private string text;
        private SpriteFont spriteFont;

        #region prop
        public Vector2 Position { get { return position; } set { position = value; } }
        public Color Color { get { return color; } set { color = value; } }
        public float Width { get { return spriteFont.MeasureString(text).X; } }
        public float Height { get { return spriteFont.MeasureString(text).Y; } }
        public string Text { get { return text; } set { text = value; } }
        #endregion
        public Label(string text, Vector2 position, Color color)
        {
            this.text = text;
            this.position = position;
            this.color = color;
        }
        public void LoadContent(ContentManager content)
        {
            spriteFont = content.Load<SpriteFont>("GameFontBlack");
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.DrawString(spriteFont, text, position, color);
        }
    }
}
