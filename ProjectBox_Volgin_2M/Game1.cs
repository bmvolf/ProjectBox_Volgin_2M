using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectBox_Volgin_2M.Classes;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using ProjectBox_Volgin_2M.Classes.Tools;
using ProjectBox_Volgin_2M.Classes.HUD;
using System.Threading;

namespace ProjectBox_Volgin_2M
{
    public class Game1 : Game
    {
        //tools
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private int screenHeight = 720;
        private int screenWidth = 1280;
        private int maxItem = 3;
        private double itemTime = 0;
        private double speedItem = 260;
        private MainMenu menu;
        private int score = 0;
        private int record = 0;
        //сменить доступ если чо
        public static GameMode gameMode = GameMode.Menu;
        //fields
        private Player player;
        private Background background;
        private List<Item> items;
        private HUD hud;
        private GameOver gameOver;
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
            items = new List<Item>();
            hud = new HUD();
            menu = new MainMenu();
            gameOver = new GameOver();
            LoadTool.Initialize();

            menu.MenuClickPlay += Menu_MenuClickPlay;
            menu.MenuClickExit += Menu_MenuClickExit;
            player.PlayerDied += Player_PlayerDied;
            gameOver.ClickExit += Menu_MenuClickExit;
            gameOver.ClickAgain += GameOver_ClickAgain;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            LoadTool.LoadAllTextures(Content);
            background.LoadContent(LoadTool.BackGroundTexture);
            player.LoadContent(LoadTool.PlayerTexture);
            hud.LoadContent(LoadTool.HpTexture, Content);
            menu.LoadContent(Content);
            gameOver.LoadContent(Content);
            LoadItem();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            switch (gameMode)
            {
                case GameMode.Playing:
                    itemTime += gameTime.ElapsedGameTime.TotalSeconds;
                    if (itemTime >= 10)
                    {
                        maxItem++;
                        speedItem += 40;
                        itemTime = 0;
                    }
                    player.Update();
                    UpdateItem(gameTime);
                    CheckCollision();
                    Debug.WriteLine(items.Count);
                    hud.Update(score);
                    break;

                case GameMode.Menu:
                    menu.Update();
                    break;

                case GameMode.GameOver:
                    gameOver.Update();
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            switch (gameMode)
            {
                case GameMode.Playing:
                    background.Draw(_spriteBatch);
                    foreach (Item item in items)
                    {
                        item.Draw(_spriteBatch);
                    }
                    player.Draw(_spriteBatch);
                    hud.Draw(_spriteBatch, player.Health, score);
                    break;

                case GameMode.Menu:
                    background.Draw(_spriteBatch);
                    menu.Draw(_spriteBatch);
                    break;

                case GameMode.GameOver:
                    background.Draw(_spriteBatch);
                    gameOver.Draw(_spriteBatch);
                    break;
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        private void LoadItem()
        {
            Random random = new Random();
            Item item = new Item(speedItem);
            int isBomb = random.Next(0, 5);
            if(isBomb == 0)
            {
                item = new Bomb(speedItem);
                item.LoadContent(LoadTool.BombTexture);
            }
            else
            {
                item.LoadContent(LoadTool.ItemTexture);
            }
            int typePose = random.Next(0, 3);
            int leftSide = (player.TextureWidth + player.Distance) * typePose + player.Indent;
            int rightSide = leftSide + player.TextureWidth - item.TextureWidth;
            int x = random.Next(leftSide, rightSide);
            int y = random.Next(item.TextureHeight, item.TextureHeight * 8);
            item.Position = new Vector2(x, -y);
            items.Add(item);
        }
        private void UpdateItem(GameTime gameTime)
        {
            if(items.Count < maxItem)
            {
                LoadItem();
            }
            for(int i = 0; i < items.Count; i++)
            {
                items[i].Update(gameTime);
                if(items[i].Position.Y > screenHeight + items[i].TextureHeight)
                {
                    items[i].IsAlive = false;
                    if(!(items[i] is Bomb))
                    {
                        player.Health--;
                    }
                }
                if (!items[i].IsAlive)
                {
                    items.RemoveAt(i);
                    i--;
                }
            }
        }
        private void CheckCollision()
        {
            foreach(var item in items)
            {
                if (item.Collision.Intersects(player.Collision))
                {
                    item.IsAlive = false;
                    if(!(item is Bomb))
                    {
                        score++;
                    }
                    if (item is Bomb)
                    {
                        player.Health--;
                    }
                }
            }
        }

        private void Menu_MenuClickPlay()
        {
            gameMode = GameMode.Playing;
        }

        private void Menu_MenuClickExit()
        {
            Exit();
        }

        private void Player_PlayerDied()
        {
            if(score > record)
            {
                record = score;
            }
            gameOver.LblScoreText = $"Your record: {record}";
            background.Texture = LoadTool.DarkBgTexture;
            gameMode = GameMode.GameOver;
        }


        private void GameOver_ClickAgain()
        {
            Restart();
            Thread.Sleep(100);
        }

        private void Restart()
        {
            background.Texture = LoadTool.BackGroundTexture;
            player.Restart();
            maxItem = 3;
            speedItem = 260;
            items.Clear();
            score = 0;
            itemTime = 0;
            gameMode = GameMode.Menu;
        }
    }
}