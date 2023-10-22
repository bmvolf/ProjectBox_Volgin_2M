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
    public class Item : IFall
    {
        #region Fields
        private Texture2D texture;
        private Rectangle destinationRectangle;
        private Vector2 position;
        private double fallSpeed;
        private int textureHeight = 70;
        private int textureWidth = 70;
        private Rectangle collision;
        private bool isAlive = true;
        #endregion
        #region Constructor
        public Item(double speed)
        {
            texture = null;
            position = Vector2.Zero;
            fallSpeed = speed;
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 70, 70);
        }
        public Item(Vector2 pos)
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
        public Rectangle Collision
        {
            get { return collision; }
        }
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }
        public double FallSpeed
        {
            get { return fallSpeed; }
            set { fallSpeed = value; }
        }
        #endregion
        #region Methods
        public void LoadContent(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            Fall(fallSpeed, gameTime);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, textureWidth, textureHeight);
            collision = new Rectangle((int)position.X, (int)position.Y + textureHeight, 70, 3);
        }

        public void Fall(double speed, GameTime gameTime)
        {
            position.Y += (float)speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        #endregion
    }
}
