using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectBox_Volgin_2M.Classes;
using System.Collections.Generic;
using System;

namespace ProjectBox_Volgin_2M
{
    public class Game1 : Game
    {
        //tools
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private int screenHeight = 720;
        private int screenWidth = 1280;
        //fields
        private Player player;
        private Background background;
        private List<Banana> bananas;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            background = new Background();
            player = new Player();
            bananas = new List<Banana>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            background.LoadContent(Content);
            player.LoadContent(Content);
            LoadBanana();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update();
            UpdateBanana(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            background.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            foreach(Banana banana in bananas)
            {
                banana.Draw(_spriteBatch);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        private void LoadBanana()
        {
            Banana banana = new Banana();
            banana.LoadContent(Content);
            Random random = new Random();
            int typePose = random.Next(0, 3);
            int leftSide = (player.TextureWidth + player.Distance) * typePose + player.Indent;
            int rightSide = leftSide + player.TextureWidth - banana.TextureWidth;
            int x = random.Next(leftSide, rightSide);
            banana.Position = new Vector2(x, 0);
            bananas.Add(banana);
        }
        private void UpdateBanana(GameTime gameTime)
        {
            if(bananas.Count < 5)
            {
                LoadBanana();
            }
            for(int i = 0; i < bananas.Count; i++)
            {
                bananas[i].Update(gameTime);
            }
        }
    }
}