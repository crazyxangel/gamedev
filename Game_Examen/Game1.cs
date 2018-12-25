﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Examen
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D tilesTexture;
        private Texture2D heroTexture;
        private Texture2D hero2Texture;
        private SpriteFont font;
        private Player player;
        private Player player2;
        private GameScreen gamescreen;
        private Menu menu;
        private GameOver gameOver;
        private Level level1;
        private GameState gameState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1920;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 1020;   // set this value to the desired height of your window
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            heroTexture = Content.Load<Texture2D>("Hero");
            hero2Texture = Content.Load<Texture2D>("Hero2");
            tilesTexture = Content.Load<Texture2D>("tiles");
            font = Content.Load<SpriteFont>("Font");


            level1 = new Level(tilesTexture);
            level1.CreateLevel();
            gamescreen = new GameScreen();
            gamescreen.startscreen = true;
            gameState = new GameState();

            gameOver = new GameOver(font, spriteBatch);
            menu = new Menu(font, spriteBatch);

            player = new Player(heroTexture, 1, level1.collisionTiles, level1.collisionLethal);
            player2 = new Player(hero2Texture, 2, level1.collisionTiles, level1.collisionLethal);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // TODO: Add your update logic here
            if (gameState.gameover)
                menu.gameover();

            gamescreen.update(menu.screen);

            if (gamescreen.startscreen)
                menu.update();

            if (gamescreen.playscreen)
            {
                player.Update(gameTime);
                player2.Update(gameTime);
                gameState.update(player.alive, player2.alive, player.playerRectangle, player2.playerRectangle);
            }
            if(gamescreen.gameoverscreen)
            {
                player.deadframesdone(gameTime);
                player2.deadframesdone(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            // TODO: Add your drawing code here

            /*switch (gamescreen.level)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }*/
            if (gamescreen.playscreen)
            {
                level1.DrawLevel(spriteBatch);
                player.Draw(spriteBatch);
                player2.Draw(spriteBatch);
            }
            if (gamescreen.startscreen)
                menu.Draw(spriteBatch);

            if(gamescreen.gameoverscreen)
            {
                player.Draw(spriteBatch);
                player2.Draw(spriteBatch);
                gameOver.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
