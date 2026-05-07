using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _1_5_summative__HALO_
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Rectangle window;
        MouseState mouse;
        enum GameState
        {
            MainMenu,
            Playing,
            GameOver
        }
        Texture2D cityTexture, peilcanTexture, covenant_shipTexture;
        Rectangle cityrect, cityrect2, peilcanrect, covenantshiprect;
        Vector2 citypos;
        int lifes = 3;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();
            cityrect = new Rectangle(0, 0, 1000, 500);
            cityrect2 = new Rectangle(1000, 0, 1000, 500);
            peilcanrect = new Rectangle(200, 50, 70, 50);
            covenantshiprect = new Rectangle(500, 0, 250, 200);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
                cityTexture = Content.Load<Texture2D>("cityforeandbackground");
            peilcanTexture = Content.Load<Texture2D>("peilcan2");
            covenant_shipTexture = Content.Load<Texture2D>("covenant_ship");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                peilcanrect.X -= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                peilcanrect.X += 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                peilcanrect.Y -= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                peilcanrect.Y += 5;
            }

            cityrect.X -= 2;
            cityrect2.X -= 2;
            
            covenantshiprect.X -= 1;
            if (covenantshiprect.X <= -750)
            {
                covenantshiprect.X = 800;
            }
            if (cityrect.X <= -1000)
            {
                cityrect.X = 1000;
            }
                if (cityrect2.X <= -1000)
                {
                    cityrect2.X = 1000;
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(covenant_shipTexture, covenantshiprect, Color.White);
            _spriteBatch.Draw(cityTexture, cityrect, Color.White);
            _spriteBatch.Draw(cityTexture, cityrect2, Color.White);

                _spriteBatch.Draw(peilcanTexture, peilcanrect, Color.White);
            
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
