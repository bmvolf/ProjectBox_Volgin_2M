﻿using System;
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

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Background");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
