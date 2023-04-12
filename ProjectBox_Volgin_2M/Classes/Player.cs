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
    public class Player
    {
        #region Fields
        private enum TypePosition { left = 0, midle = 1, right = 2 };
        private Texture2D texture; //текстура
        private Vector2 position; // позиция
        private int topOfBox = 464; //верх коробки
        private int distance = 216; //расстояние между позициями
        private int typePosition; //тип позиции от 0 до 2
        private int textureWidth = 256;
        private int indent = 40;
        private KeyboardState keyboardState; //нынешнее состояние
        private KeyboardState prevKeyboardState; //предыдущее состояние
        #endregion
        #region Constructor
        public Player()
        {
            texture = null;
            position = new Vector2(40, topOfBox);
        }
        #endregion
        #region Properties
        public int TextureWidth
        {
            get { return textureWidth; }
        }
        public int Distance
        {
            get { return distance; }
        }
        public int Indent
        {
            get { return indent; }
        }
        #endregion
        #region Methods
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Box");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
        public void Update()
        {
            #region Movement
            keyboardState = Keyboard.GetState();
            if (prevKeyboardState.IsKeyUp(Keys.D) && keyboardState.IsKeyDown(Keys.D))
            {
                typePosition++;
                if(typePosition == 3)
                {
                    typePosition = 2;
                }
                position.X = (textureWidth + distance) * typePosition + indent;
            }
            if (prevKeyboardState.IsKeyUp(Keys.A) && keyboardState.IsKeyDown(Keys.A))
            {
                typePosition--;
                if(typePosition == -1)
                {
                    typePosition = 0;
                }
                position.X = (textureWidth + distance) * typePosition + indent;
            }
            prevKeyboardState = keyboardState;
            #endregion
        }
        #endregion
    }
}
