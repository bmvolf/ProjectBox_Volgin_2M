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
    public class GameOver
    {
        private List<Label> buttonList = new List<Label>();
        private Label lblgameOver;
        private Label lblScore;
        private int selected = 0;
        private KeyboardState keyboardState;
        private KeyboardState prevkeyboardState;
        private Vector2 position = new Vector2(640, 120);
        public event Action ClickExit;
        public event Action ClickAgain;

        public string LblScoreText
        {
            get { return lblScore.Text; }
            set { lblScore.Text = value; }
        }

        public GameOver()
        {
            lblgameOver = new Label("Game is Over", position, Color.White);
            lblScore = new Label("Your record: 00", new Vector2(position.X, position.Y + 100), Color.White);
            buttonList.Add(new Label("Try again", new Vector2(position.X, position.Y + 200), Color.White));
            buttonList.Add(new Label("Exit", new Vector2(position.X, position.Y + 300), Color.White));
        }

        public void LoadContent(ContentManager content)
        {
            lblgameOver.LoadContent(content);
            lblScore.LoadContent(content);
            lblgameOver.Position = new Vector2(lblgameOver.Position.X - lblgameOver.Width / 2, lblgameOver.Position.Y);
            foreach (Label label in buttonList)
            {
                label.LoadContent(content);
                label.Position = new Vector2(label.Position.X - label.Width / 2, label.Position.Y);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            lblgameOver.Draw(spriteBatch, Color.Red);
            lblScore.Position = new Vector2(lblScore.Position.X - lblScore.Width / 2, lblScore.Position.Y);
            lblScore.Draw(spriteBatch, Color.Red);
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
                if(selected == 1)
                {
                    if(ClickExit != null)
                    {
                        ClickExit();
                    }
                }
                else if (selected == 0)
                {
                    if (ClickAgain != null)
                    {
                        ClickAgain();
                    }
                }
            }
            prevkeyboardState = keyboardState;
        }
    }
}
