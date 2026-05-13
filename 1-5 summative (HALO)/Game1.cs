using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using private_1_5_summative_HALO;

namespace _1_5_summative__HALO_
{
    enum Screen
    {
        MainMenu,
        PreScreen,
        Playing,
        GameOver
    }
    
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private float bulletTimer = 0;
        private float bulletTime = 1;
        bool bulletActive = false;
        Rectangle window;
        MouseState mouse;
        Random generator = new Random();  
        //
        Screen screen = Screen.MainMenu;
        Texture2D cityTexture, peilcanTexture, covenant_shipTexture, ringTexture, bansheeTexture, skyTexture, build1Texture,unscShipTexture, logoTexture, bulletTexture, explosionTexture,phantomTexture;
        Rectangle cityrect, cityrect2, cityrect3, cityrect4, peilcanrect, covenantshiprect, ringrect, bansheerect, bansheerect2, build1rect, unscshiprect, logorect, bulletrect, explosionrect, phantomrect;
        Rectangle peilcanHitbox, bansheeHitbox, build1Hitbox;
		float timer = 0, bulletSpeed = 10f, interval = 0.2f;
        SoundEffectInstance haloTheme, haloflyingtheme, peilcanSound, radio1, bulletfire, brothersInArms;
        int lifes = 3, phantomHealth = 3;
        List<Vector2> bulletPositions = new List<Vector2>();
        List<Vector2> bulletVelocities = new List<Vector2>();



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

            cityrect3 = new Rectangle(1000, 0, 1000, 500);

            cityrect3 = new Rectangle(1000, 0, 500, 250);

            cityrect4 = new Rectangle(1000, 0, 500, 250);

            peilcanrect = new Rectangle(200, 50, 70, 50);

            covenantshiprect = new Rectangle(500, 0, 250, 200);

            ringrect = new Rectangle(0, 0, 800, 500);

            bansheerect = new Rectangle(800, 0, 60, 40);

            build1rect = new Rectangle(-250, 250, 300, 250);

            unscshiprect = new Rectangle(1010, 100, 100, 50);

            bansheerect2 = new Rectangle(900, 0, 60, 40);

            logorect = new Rectangle(200, 100, 400, 300);


            

            phantomrect = new Rectangle(1200, 300, 140, 100);

            

            explosionrect = new Rectangle(0, 0, 100, 100);

            build1Hitbox = new Rectangle(build1rect.X, build1rect.Y, build1rect.Width, build1rect.Height);
         


			base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
                cityTexture = Content.Load<Texture2D>("cityforeandbackground");

            peilcanTexture = Content.Load<Texture2D>("peilcan2");

            covenant_shipTexture = Content.Load<Texture2D>("covenant_ship");

            ringTexture = Content.Load<Texture2D>("ring");

            bansheeTexture = Content.Load<Texture2D>("banshee");

            skyTexture = Content.Load<Texture2D>("sky");

                build1Texture = Content.Load<Texture2D>("building1");

            unscShipTexture = Content.Load<Texture2D>("UNSC_ship");

            logoTexture = Content.Load<Texture2D>("halo_logo");
            
            haloTheme = Content.Load<SoundEffect>("halo_theme").CreateInstance();

            SoundEffect haloThemeSoundEffect = Content.Load<SoundEffect>("halo_theme");

            haloflyingtheme = Content.Load<SoundEffect>("halo_fly").CreateInstance();

            SoundEffectInstance haloFlyingThemeSoundEffectInstance = Content.Load<SoundEffect>("halo_fly").CreateInstance();

            peilcanSound = Content.Load<SoundEffect>("peilcansound").CreateInstance(); 

            bulletTexture = Content.Load<Texture2D>("bullet117 (1)");

            explosionTexture = Content.Load<Texture2D>("explosion");

            radio1 = Content.Load<SoundEffect>("radio1").CreateInstance();

            bulletfire = Content.Load<SoundEffect>("bulletfire").CreateInstance();


            brothersInArms = Content.Load<SoundEffect>("03. Martin O'Donnell - Brothers in Arms").CreateInstance();

          
        
            phantomTexture = Content.Load<Texture2D>("covenant2");

			// TODO: use this.Content to load your game content here
		}

		

		protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            mouse = Mouse.GetState();
            bulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Space) && bulletTimer >= bulletTime)
            {
                bulletPositions.Add(peilcanrect.Location.ToVector2() + new Vector2(peilcanrect.Width, peilcanrect.Height / 2 - bulletrect.Height / 2));

                bulletVelocities.Add(new Vector2(bulletSpeed, 0));

                bulletTimer = 0;
			}
            for (int i = 0; i < bulletPositions.Count; i++)
            {
                bulletPositions[i] += bulletVelocities[i];
                if (bulletPositions[i].X > 800)
                {
                    bulletPositions.RemoveAt(i);
                    bulletVelocities.RemoveAt(i);
                    i--;
                }
				if (bansheerect.Contains(bulletPositions.LastOrDefault()))
				{
					bansheerect.X = 800;
					bansheerect = new Rectangle(850, new Random().Next(0, 450), 60, 40);
					bulletPositions.RemoveAt(i);
					bulletVelocities.RemoveAt(i);
					i--;
				}
				if (bansheerect2.Contains(bulletPositions.LastOrDefault()))
				{
					bansheerect2.X = 800;
					bansheerect2 = new Rectangle(850, new Random().Next(0, 450), 60, 40);
					bulletPositions.RemoveAt(i);
					bulletVelocities.RemoveAt(i);
					i--;
				}
				if (phantomrect.Contains(bulletPositions.FirstOrDefault()))
				{
                    phantomHealth--;
                    bulletPositions.RemoveAt(i);
                    bulletVelocities.RemoveAt(i);
                    i--;

				}
			}


			if (screen == Screen.MainMenu)
            {
                haloTheme.Play();
                if (haloTheme.State == SoundState.Stopped) 
                {
                    haloTheme.Play();
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    screen = Screen.Playing;
                    haloTheme.Stop();
                    
                }

            }
            if (screen == Screen.Playing)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                haloflyingtheme.Play();
                peilcanSound.Play();
                if (haloflyingtheme.State == SoundState.Stopped) 
                {
                    haloflyingtheme.Play();
				}
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
                build1rect.X -= 1;
                covenantshiprect.X -= 1;
                phantomrect.X -= 3;
               
                
                unscshiprect.X -= 1;
                if (build1rect.X <= -300)
                {
                    build1rect.X = generator.Next(1100, 3000);
                }
                if (covenantshiprect.X <= -750)
                {
                    covenantshiprect.X = 800;
                }
                if (phantomrect.X <= -250)
                {
					phantomrect.X = new Random().Next(1000, 1500);
					phantomrect.Y = new Random().Next(0, 200);
				}
                if (phantomrect.Y >= 800)
                {
					phantomrect.X = new Random().Next(1000, 1500);
					phantomrect.Y = new Random().Next(0, 200);
				}
                if (phantomrect.Y <= -800)
                {
					phantomrect.X = new Random().Next(1000, 1500);
					phantomrect.Y = new Random().Next(0, 200);
				}
				if (cityrect.X <= -1000)
                {
                    cityrect.X = 1000;
                }
                if (cityrect2.X <= -1000)
                {
                    cityrect2.X = 1000;
                }
                if (bansheerect.X <= -150)
                {
                    bansheerect.X = 850;
                    bansheerect.Y = new Random().Next(0, 450); 
				}
                
                if (peilcanrect.Intersects(bansheerect))
                {
                    lifes--;
                    peilcanrect.X = 200;
                    peilcanrect.Y = 50;
                    bansheerect.X = 850;
                    bansheerect.Y = new Random().Next(0, 450);
                }
                if (peilcanrect.Intersects(phantomrect))
                {
                    lifes--;
                    peilcanrect.X = 200;
                    peilcanrect.Y = 50;
                    phantomrect.X = new Random().Next(1000, 1500);
                    phantomrect.Y = new Random().Next(0, 450);
                    
                }
                if (unscshiprect.X <= -250)
                {
                    unscshiprect.X = new Random().Next(1000, 3000);
                    unscshiprect.Y = new Random().Next(0, 200);
                }
                if (peilcanrect.X <= -100)
                {
                    peilcanrect.X = 900;
                }
                else if (peilcanrect.X >= 900)
                {
                    peilcanrect.X = -100;
                }
                if (peilcanrect.Y <= -100)
                {
                    peilcanrect.Y = 600;
                }
                else if (peilcanrect.Y >= 600)
                {
                    peilcanrect.Y = -100;
                }
                if (lifes <= 0)
                {
                    screen = Screen.GameOver;
                }
                if (bansheerect2.X <= -150)
                {
                    bansheerect2.X = 850;
                    bansheerect2.Y = new Random().Next(0, 450);
                }
                if (peilcanrect.Intersects(bansheerect2))
                {
                    lifes--;
                    peilcanrect.X = 200;
                    peilcanrect.Y = 50;
                    bansheerect2.X = 850;
                    bansheerect2.Y = new Random().Next(0, 450);
                }
                if (timer >= 0)
                {
                    bansheerect.X -= 3;
                    

                }
                if (timer >= 15)
                {
                    
                    bansheerect.X -= 4;
                    bansheerect2.X -= 4;
                    


                }
                if (timer >= 30)
                {
                    bansheerect.X -= 5;
                    bansheerect2.X -= 5;
                    
                }
                if (timer >= 45)
                {
                    bansheerect.X -= 6;
                    bansheerect2.X -= 6;
                    radio1.Play();
                }
                
				
				if (phantomHealth == 0)
                {                     
                    phantomrect.X = new Random().Next(1000, 1500);
                    phantomrect.Y = new Random().Next(0, 450);
                    phantomHealth = 3;
				}
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    bulletActive = true;
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Space))
                {
                    bulletActive = false;
                }
				
				

			}

            // TODO: Add your update logic here

            base.Update(gameTime);

			// TODO: Add your update logic here


		}

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            if (screen == Screen.MainMenu)
            {
                _spriteBatch.Draw(ringTexture, ringrect, Color.White);
                _spriteBatch.Draw(logoTexture, logorect, Color.White);

            }
            if (screen == Screen.Playing)
            {
                _spriteBatch.Draw(skyTexture, window, Color.White);

                _spriteBatch.Draw(unscShipTexture, unscshiprect, Color.White);

                _spriteBatch.Draw(covenant_shipTexture, covenantshiprect, Color.White);

                _spriteBatch.Draw(cityTexture, cityrect, Color.White);

                _spriteBatch.Draw(cityTexture, cityrect2, Color.White);

                _spriteBatch.Draw(build1Texture, build1rect, Color.White);

                _spriteBatch.Draw(bansheeTexture, bansheerect, Color.White);

                _spriteBatch.Draw(bansheeTexture, bansheerect2, Color.White);

                _spriteBatch.Draw(phantomTexture, phantomrect, Color.White);


                foreach (Vector2 position in bulletPositions)
                {
                    _spriteBatch.Draw(bulletTexture, position, Color.White);
                }





				_spriteBatch.Draw(peilcanTexture, peilcanrect, Color.White);

                if (peilcanrect.Intersects(bansheerect))
                {
                    
					_spriteBatch.Draw(explosionTexture, peilcanrect, Color.White);
                    _spriteBatch.Draw(explosionTexture, bansheerect, Color.White);
					
				}
				if (peilcanrect.Intersects(bansheerect2))
				{

					_spriteBatch.Draw(explosionTexture, peilcanrect, Color.White);
					_spriteBatch.Draw(explosionTexture, bansheerect2, Color.White); 

				}
				if (peilcanrect.Intersects(build1rect))
				{

					_spriteBatch.Draw(explosionTexture, peilcanrect, Color.White);
					
				}
                if (bulletrect.Intersects(bansheerect))
                {
                    
                    _spriteBatch.Draw(explosionTexture, bansheerect, Color.White);
                }
                if (bulletrect.Intersects(bansheerect2))
                {
                    
                    _spriteBatch.Draw(explosionTexture, bansheerect2, Color.White);
                }
            }
            
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
