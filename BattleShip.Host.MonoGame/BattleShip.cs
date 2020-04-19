using BattleShip.PlayerBehavior.IA;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BattleShip.Host.MonoGame.Game;
using MonoGame.Extended.ViewportAdapters;
using MonoGame.Extended;
using System;

namespace BattleShip.Host.MonoGame
{
    public class BattleShip : Microsoft.Xna.Framework.Game
    {
        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        readonly Engine.Game game;

        Game.Entities.Board player1Board;
        Game.Entities.Board player2Board;

        double drawTimer = 0d;
        double drawTimeout = 0.5d;

        RenderTarget2D renderTarget;

        public Point Size => new Point((int)(player2Board.Position.X + player2Board.Size.X), (int) player1Board.Size.Y);

        public BattleShip()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1600,
                PreferredBackBufferHeight = 900,
                SupportedOrientations = DisplayOrientation.LandscapeRight
            };

            Window.AllowUserResizing = true;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            game = new Engine.Game();
            game.InitializePlayers(new SmartBehavior(), new SmartBehavior());
        }

        protected override void Initialize()
        {
            base.Initialize();

            player1Board = new Game.Entities.Board(game.Player1);

            player2Board = new Game.Entities.Board(game.Player2)
            {
                Position = new Vector2(player1Board.Position.X + player1Board.Size.X, player1Board.Position.Y)
            };

            renderTarget = new RenderTarget2D(GraphicsDevice, Size.X, Size.Y, false,
                                              SurfaceFormat.Color, DepthFormat.None);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Art.Load(Content);
        }

        private bool start = false;

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                start = true;

            player1Board.Update();
            player2Board.Update();

            if (start)
            {
                drawTimer += gameTime.ElapsedGameTime.TotalSeconds;

                if (game.State != Engine.GameState.End && drawTimer > drawTimeout)
                {
                    drawTimer = 0;
                    game.Update();
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Back buffer
            GraphicsDevice.Clear(Color.Black);
            GraphicsDevice.SetRenderTarget(renderTarget);

            spriteBatch.Begin();

            spriteBatch.Draw(Art.Paper, GraphicsDevice.Viewport.Bounds, Color.White);

            player1Board.Draw(spriteBatch);
            player2Board.Draw(spriteBatch);

            spriteBatch.End();

            // Ecran

            GraphicsDevice.SetRenderTarget(null);

            spriteBatch.Begin();

            spriteBatch.Draw(Art.Paper, GraphicsDevice.Viewport.Bounds, Color.White);
            spriteBatch.Draw(renderTarget, new Vector2(GraphicsDevice.PresentationParameters.BackBufferWidth / 2,
                             GraphicsDevice.PresentationParameters.BackBufferHeight / 2), null, Color.White, 0f,
                             new Vector2(renderTarget.Width / 2, renderTarget.Height / 2), 
                             GraphicsDevice.PresentationParameters.BackBufferWidth / (float)renderTarget.Width, SpriteEffects.None, 0f);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
