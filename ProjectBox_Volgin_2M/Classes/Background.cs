using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectBox_Volgin_2M.Classes
{
    public class Background
    {
        private Texture2D texture;
        private Vector2 position;

        public Background()
        {
            texture = null;
            position = Vector2.Zero;
        }
        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public void LoadContent(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
