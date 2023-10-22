using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectBox_Volgin_2M.Classes.HUD;

namespace ProjectBox_Volgin_2M.Classes
{
    public class MainMenu
    {
        private List<Label> buttonList = new List<Label>();
        private int selected = 0;
        private KeyboardState keyboardState;
        private KeyboardState prevkeyboardState;
        public event Action MenuClickPlay;
        public event Action MenuClickExit;
        private Vector2 position = new Vector2(640, 250);

        public MainMenu()
        {
            selected = 0;
            buttonList.Add(new Label("Play", position, Color.White));
            buttonList.Add(new Label("Exit", new Vector2(position.X, position.Y + 100), Color.White));

        }

        public void Update()
        {
            keyboardState = Keyboard.GetState();
            if (prevkeyboardState.IsKeyUp(Keys.S) && keyboardState.IsKeyDown(Keys.S))
            {
                if (selected < buttonList.Count - 1)
                {
                    selected++;
                }
            }
            if (prevkeyboardState.IsKeyUp(Keys.W) && keyboardState.IsKeyDown(Keys.W))
            {
                if (selected > 0)
                {
                    selected--;
                }
            }
            if (prevkeyboardState.IsKeyUp(Keys.Enter) && keyboardState.IsKeyDown(Keys.Enter))
            {
                if (selected == 0)
                {
                    if (MenuClickPlay != null)
                    {
                        MenuClickPlay();
                    }
                }
                else if (selected == 1)
                {
                    if (MenuClickExit != null)
                    {
                        MenuClickExit();
                    }
                }
            }
            prevkeyboardState = keyboardState;
        }

            public void LoadContent(ContentManager content)
        {
            foreach(Label label in buttonList)
            {
                label.LoadContent(content);
            }
            foreach(Label label in buttonList)
            {
                label.Position = new Vector2(label.Position.X - label.Width / 2, label.Position.Y);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < buttonList.Count; i++)
            {
                if (selected == i)
                {
                    buttonList[i].Draw(spriteBatch, Color.Orange);
                }
                else
                {
                    buttonList[i].Draw(spriteBatch, Color.White);
                }
            }
        }
    }
}
