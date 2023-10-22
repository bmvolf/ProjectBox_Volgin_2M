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

namespace ProjectBox_Volgin_2M.Classes.HUD
{
    public class HUD
    {
        private Texture2D textureHP;
        private Vector2 position;
        private List<Rectangle> points;
        private Label lblScore;
        public HUD()
        {
            textureHP = null;
            position = Vector2.Zero;
            points = new List<Rectangle>();
            lblScore = new Label("Score: 0", new Vector2(50, 5), Color.White);
        }
        public void LoadContent(Texture2D texture, ContentManager content)
        {
            textureHP = texture;
            lblScore.LoadContent(content);
        }
        public void Update(int score)
        {
            lblScore.Text = $"Score: {score}";
        }
        public void Draw(SpriteBatch spriteBatch, int health, int score)
        {
            for(int i = 0; i < health; i++)
            {
                points.Add(new Rectangle((int)position.X, (int)position.Y, 30, 30));
                spriteBatch.Draw(textureHP, points[i], Color.White);
                position.Y += 40;
            }
            position = Vector2.Zero;
            lblScore.Draw(spriteBatch, Color.White);
        }
    }
}
