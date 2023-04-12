using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectBox_Volgin_2M.Classes.Interfaces;

namespace ProjectBox_Volgin_2M.Classes
{
    public class Banana : IFall
    {
        #region Fields
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Vector2 position;
        private float fallSpeed = 250;
        private int frameNumber = 0;
        private int frameHeight = 128;
        private int frameWidth = 128;
        private int textureHeight = 70;
        private int textureWidth = 70;
        #endregion
        #region Constructor
        public Banana()
        {
            texture = null;
            position = Vector2.Zero;
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 70, 70);
        }
        public Banana(Vector2 pos)
        {
            texture = null;
            position = pos;
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 70, 70);
        }
        #endregion
        #region Properties
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public int TextureWidth
        {
            get { return textureWidth; }
        }
        public int TextureHeight
        {
            get { return textureHeight; }
        }
        #endregion
        #region Methods
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Banana");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            Fall(fallSpeed, gameTime);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, textureWidth, textureHeight);
            sourceRectangle = new Rectangle(frameNumber * frameWidth, 0, frameWidth, frameHeight);
        }

        public void Fall(float speed, GameTime gameTime)
        {
            Debug.WriteLine(gameTime.ElapsedGameTime.TotalSeconds);
            position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        #endregion
    }
}
