using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tutorial
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        float alpha;
        Texture2D texture;
        bool Increase;
        int FadeSpeed;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = ((int)ScreenManager.Instance.Dimensions.X);
            graphics.PreferredBackBufferHeight = ((int)ScreenManager.Instance.Dimensions.Y);
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ScreenManager.Instance.GraphicsDevice = GraphicsDevice;
            ScreenManager.Instance.SpriteBatch = spriteBatch;
            ScreenManager.Instance.LoadContent(Content);
            alpha = 1.0f;
            Increase = false;
            FadeSpeed = 1;
            texture = Content.Load<Texture2D>("SplashScreen/cme");
        }

        protected override void UnloadContent()
        {
           ScreenManager.Instance.UnloadContent();
           Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

                //if (!Increase)
                //    alpha -= FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                //else
                //    alpha += FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                //if (alpha < 0.0f)
                //{
                //    Increase = true;
                //    alpha = 0.0f;
                //}
                //else if (alpha > 1.0f)
                //{
                //    Increase = false;
                //    alpha = 1.0f;
                //}

            ScreenManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            //spriteBatch.Draw(texture, new Rectangle(0, 0, 640, 480), Color.White * alpha);
            ScreenManager.Instance.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
