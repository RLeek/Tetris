using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

    public class GameManager: Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static GameManager self;
        public static ContentManager content;
        public static GraphicsDevice graphicsDevice;

        public GameState currGameState { get; set; }
    
        public GameManager()
        {
            _graphics = new GraphicsDeviceManager(this);
            self = this;
            content = Content;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            IsFixedTimeStep = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            graphicsDevice = GraphicsDevice;
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            currGameState = new StartMenu(_spriteBatch);
            currGameState.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            currGameState.Update(gameTime, this);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            _spriteBatch.Begin();
            currGameState.Draw(gameTime);
            _spriteBatch.End();
        
            base.Draw(gameTime);
        }
    }
