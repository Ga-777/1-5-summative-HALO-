using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace _1_5_summative__HALO_
{
    enum Screen
    {
        MainMenu,
        intro,
        CutScreen1,
        Level1,
        GameOver
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private float bulletTimer = 0;
        private float bulletTime = 1;
		float centerY = 300f;
		bool bulletActive = false, peilcanRightShow = true, peilcanLeftShow = false, peilcanRightUpShow = false, peilcanRightDownShow = false, bossFight = false, cutScene1 = false, cutScene2 = false, cutScene3 = false, bansheeActive = true, cutSceneEvent = false, peilcanActive, blowMeAwayActive = false, energyShieldOff = false, weaponsOn = true;
        Rectangle window;
        MouseState mouse;
        Random generator = new Random();
        //
        Screen screen = Screen.MainMenu;
        Texture2D cityTexture, peilcanTexture, covenant_shipTexture, ringTexture, bansheeTexture, skyTexture, build1Texture,unscShipTexture, logoTexture, bulletTexture, explosionTexture,phantomTexture, buttonTexture, bossShipTexture, missileTexture;
        Rectangle cityrect, cityrect2, cityrect3, cityrect4, peilcanrect, covenantshiprect, ringrect, peilcanrect2, peilcanrect3,  bansheerect, bansheerect2, build1rect, unscshiprect, logorect, bulletrect, explosionrect, phantomrect, buttonrect, bossShiprect, deathScreenrect, missilerect;
		Texture2D peilcan_up_right, peilcan_down_right, peilcan_Left;
        Texture2D plasmaShot;
        Rectangle plasmaShotrect;
        Texture2D energyShieldTexture1, energyShieldTexture2, energyShieldTexture3, energyShieldTexture4;
        Rectangle energyShield1rect, energyShield2rect, energyShield3rect, energyShield4rect;
        Rectangle playerLife1rect, playerLife2rect, playerLife3rect;
        float timer = 0, bulletSpeed = 10f, interval = 0.2f, plasmaSpeed = -15f, missileSpeed = 10f;
        SoundEffectInstance haloTheme, haloflyingtheme, peilcanSound, radio1, bulletfire, brothersInArms,blowMeAway;
        int lifes = 3, phantomHealth = 3, bossShipHealth = 30;
        int energyShieldHealth = 8;
        List<Vector2> bulletPositions = new List<Vector2>();
        List<Vector2> bulletVelocities = new List<Vector2>();

		List<Vector2> plasmaPositions = new List<Vector2>();
		List<Vector2> plasmaVelocities = new List<Vector2>();

        List<Vector2> missilePositions = new List<Vector2>();
        List<Vector2> missileVelocities = new List<Vector2>();
        private float plasmaTimer = 0;
		private float plasmaTime = 2f;
        
        private float missileTimer = 0;
        private float missileTime = 5f;

        private float shieldTimer = 0;
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

            peilcanrect = new Rectangle(200, 600, 70, 50);

			peilcanrect2 = new Rectangle(50, 600, 70, 50);

			peilcanrect3 = new Rectangle(0, 600, 70, 50);

			covenantshiprect = new Rectangle(500, 0, 250, 200);

            ringrect = new Rectangle(0, 0, 800, 500);

            bansheerect = new Rectangle(800, 0, 60, 40);

            build1rect = new Rectangle(-250, 250, 300, 250);

            unscshiprect = new Rectangle(1010, 100, 100, 50);

            bansheerect2 = new Rectangle(900, 0, 60, 40);

            logorect = new Rectangle(200, 100, 400, 300);

            buttonrect = new Rectangle(300, 400, 200, 50);


            phantomrect = new Rectangle(1200, 300, 140, 100);

			plasmaShotrect = new Rectangle(0, 0, 2, 1);



			explosionrect = new Rectangle(0, 0, 100, 100);


            bossShiprect = new Rectangle(950, 200, 700, 250);

            deathScreenrect = new Rectangle(300, 200, 200, 250);

            playerLife1rect = new Rectangle(10, 10, 20, 20);

            playerLife2rect = new Rectangle(40, 10, 20, 20);

            playerLife3rect = new Rectangle(70, 10, 20, 20);

            energyShield1rect = new Rectangle(0, 0, 20, 20);

            energyShield2rect = new Rectangle(0, 0, 20, 20);

            energyShield3rect = new Rectangle(0, 0, 20, 20);

            energyShield4rect = new Rectangle(0, 0, 20, 20);
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

            buttonTexture = Content.Load<Texture2D>("capbutton");

            phantomTexture = Content.Load<Texture2D>("covenant2");

			bossShipTexture = Content.Load<Texture2D>("covenant_ship_boss");

			peilcan_down_right = Content.Load<Texture2D>("peil-down-right (1)");

			plasmaShot = Content.Load<Texture2D>("plasmashot (1)");

			peilcan_up_right = Content.Load<Texture2D>("peil-up-right");

			peilcan_Left = Content.Load<Texture2D>("peil-left");

            missileTexture = Content.Load<Texture2D>("missile2");

            blowMeAway = Content.Load<SoundEffect>("02 Blow Me Away").CreateInstance();

            energyShieldTexture1 = Content.Load<Texture2D>("energy_shield1");

            energyShieldTexture2 = Content.Load<Texture2D>("energy_shield2");

            energyShieldTexture3 = Content.Load<Texture2D>("energy_shield3");

            energyShieldTexture4 = Content.Load<Texture2D>("energy_shield4");
            // TODO: use this.Content to load your game content here
        }



        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouse = Mouse.GetState();
            bulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            plasmaTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            missileTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            shieldTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            KeyboardState keyboardState = Keyboard.GetState();
            
            if (buttonrect.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && screen == Screen.MainMenu)
            {
                screen = Screen.CutScreen1;


            }
            if (screen == Screen.MainMenu)
            {
                if (blowMeAwayActive == false)
                {
                    haloTheme.Play();
                }
                
                
                if (Keyboard.GetState().IsKeyDown(Keys.B))
                {
                    blowMeAway.Play();
                    haloTheme.Stop();
                    blowMeAwayActive = true;
                }
            }

            if (weaponsOn == true)
            {
                if (keyboardState.IsKeyDown(Keys.Space) && bulletTimer >= bulletTime)
                {
                    bulletPositions.Add(peilcanrect.Location.ToVector2() + new Vector2(peilcanrect.Width, peilcanrect.Height / 2 - bulletrect.Height / 2));

                    bulletVelocities.Add(new Vector2(bulletSpeed, 0));

                    bulletfire.Play();

                    bulletTimer = 0;
                }
                for (int i = 0; i < bulletPositions.Count; i++)
                {


                    bulletPositions[i] += bulletVelocities[i];
                    if (peilcanLeftShow == true)
                    {
                        bulletVelocities[i] = new Vector2(-bulletSpeed, 0);

                    }
                    if (bulletPositions[i].X > 800)
                    {
                        bulletPositions.RemoveAt(i);
                        bulletVelocities.RemoveAt(i);
                        i--;
                    }
                    else if (bulletPositions[i].X < 10)
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
                    if (bossShiprect.Contains(bulletPositions.FirstOrDefault()))
                    {
                        bossShipHealth--;
                        bulletPositions.RemoveAt(i);
                        bulletVelocities.RemoveAt(i);
                        i--;
                    }
                    if (energyShield1rect.Contains(bulletPositions.FirstOrDefault()) && energyShieldOff == false)
                    {
                        energyShieldHealth--;
                        bulletPositions.RemoveAt(i);
                        bulletVelocities.RemoveAt(i);
                        i--;
                    }
                }

                if (keyboardState.IsKeyDown(Keys.M) && missileTimer >= missileTime)
                {

                    missilePositions.Add(peilcanrect.Location.ToVector2() + new Vector2(peilcanrect.Width, peilcanrect.Height / 2 - missilerect.Height / 2));
                    missileVelocities.Add(new Vector2(missileSpeed, 0));
                    missileTimer = 0;
                }
                for (int k = 0; k < missilePositions.Count; k++)
                {
                    missilePositions[k] += missileVelocities[k];
                    if (missilePositions[k].X > 800)
                    {
                        missilePositions.RemoveAt(k);
                        missileVelocities.RemoveAt(k);
                        k--;
                    }
                    if (bansheerect.Contains(missilePositions.LastOrDefault()))
                    {
                        bansheerect.X = 800;
                        bansheerect = new Rectangle(850, new Random().Next(0, 450), 60, 40);
                        missilePositions.RemoveAt(k);
                        missileVelocities.RemoveAt(k);
                        k--;
                    }
                    if (bansheerect2.Contains(missilePositions.LastOrDefault()))
                    {
                        bansheerect2.X = 800;
                        bansheerect2 = new Rectangle(850, new Random().Next(0, 450), 60, 40);
                        missilePositions.RemoveAt(k);
                        missileVelocities.RemoveAt(k);
                        k--;
                    }
                    if (phantomrect.Contains(missilePositions.FirstOrDefault()))
                    {
                        phantomHealth -= 3;
                        missilePositions.RemoveAt(k);
                        missileVelocities.RemoveAt(k);
                        k--;
                    }
                    if (bossShiprect.Contains(missilePositions.FirstOrDefault()))
                    {
                        bossShipHealth -= 5;
                        missilePositions.RemoveAt(k);
                        missileVelocities.RemoveAt(k);
                        k--;
                    }
                    if (energyShield1rect.Contains(missilePositions.FirstOrDefault()) && energyShieldOff == false)
                    {
                        energyShieldHealth -= 2;
                        missilePositions.RemoveAt(k);
                        missileVelocities.RemoveAt(k);
                        k--;
                    }

                }
            }
                





                    if (bossFight == true)
            

                if (plasmaTimer >= plasmaTime)
                {
                    plasmaPositions.Add(bossShiprect.Location.ToVector2() + new Vector2(bossShiprect.Width, bossShiprect.Height / 2 - plasmaShot.Height / 2));

                    plasmaVelocities.Add(new Vector2(plasmaSpeed, 0));



                    plasmaTimer = 0;
                }
                for (int j = 0; j < plasmaPositions.Count; j++)
                {
                    plasmaPositions[j] += plasmaVelocities[j];
                    if (plasmaPositions[j].X < 0)
                    {
                        plasmaPositions.RemoveAt(j);
                        plasmaVelocities.RemoveAt(j);
                        j--;
                    }
                    if (peilcanrect.Contains(plasmaPositions.FirstOrDefault()))
                    {
                        lifes--;
                        peilcanrect.X = 200;
                        peilcanrect.Y = 50;
                        plasmaPositions.RemoveAt(j);
                        plasmaVelocities.RemoveAt(j);
                        j--;
                    }
                }
        

                if (screen == Screen.CutScreen1)
                {
                    cityrect.X -= 2;
                    cityrect2.X -= 2;
                    if (cityrect.X <= -1000)
                    {
                        cityrect.X = 1000;
                    }
                    if (cityrect2.X <= -1000)
                    {
                        cityrect2.X = 1000;
                    }

                    if (peilcanActive == false)
                    {
                        peilcanrect.X += 1;
                        peilcanrect2.X += 1;
                        peilcanrect3.X += 1;

                        peilcanrect.Y -= 3;
                        peilcanrect2.Y -= 1;
                        peilcanrect3.Y -= 2;
                        if (peilcanrect.Y <= 300)
                        {
                            peilcanrect.Y = 300;
                            peilcanrect.X = 290;
                        }
                        if (peilcanrect2.Y <= 250)
                        {
                            peilcanrect2.Y = 250;
                            peilcanrect2.X = 400;
                        }
                        if (peilcanrect3.Y <= 200)
                        {

                            peilcanrect3.Y = 200;
                            peilcanrect3.X = 200;
                        }
                    }

                    if (cutScene1 == true && cutScene2 == true && cutScene3 == true)
                    {
                        timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if (timer >= 2)
                        {
                            if (bansheeActive == true)
                            {

                                bansheerect.X -= 3;
                                bansheerect.Y = 250;

                                bansheerect2.X -= 6;
                                bansheerect2.Y = 200;
                            }
                        }
                    }
                    if (timer >= 4)
                    {

                        bansheeActive = false;
                        cutSceneEvent = true;
                        peilcanActive = true;

                        peilcanrect2.X -= 4;
                        peilcanrect3.X -= 4;
                        bansheerect.X -= 4;
                        bansheerect2.X -= 4;

                        peilcanrect.Y -= 2;
                        if (peilcanrect.Y <= 250)
                        {
                            peilcanrect.Y = 250;
                            peilcanrect.X += 5;
                        }
                        if (peilcanrect.X >= 800)
                        {

                            peilcanrect.X = -10;

                            if (timer >= 6)
                            {
                                screen = Screen.Level1;
                            }
                        }
                    }











                }





                if (screen == Screen.Level1)
                {

                    timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    haloflyingtheme.Play();
                    haloTheme.Stop();
                    peilcanSound.Play();

                    if (haloflyingtheme.State == SoundState.Stopped)
                    {
                        brothersInArms.Play();
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    {
                        peilcanrect.X -= 3;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    {
                        peilcanrect.X += 3;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    {
                        peilcanrect.Y -= 3;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    {
                        peilcanrect.Y += 3;
                    }

                    cityrect.X -= 2;
                    cityrect2.X -= 2;
                    build1rect.X -= 1;
                    covenantshiprect.X -= 1;
                    phantomrect.X -= 3;
                    bossShiprect.X -= 0;

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


                    if (timer >= 30)
                    {

                        bansheerect.X -= 4;
                        bansheerect2.X -= 4;



                    }
                    if (timer >= 60)
                    {
                        bansheerect.X -= 5;
                        bansheerect2.X -= 5;

                    }
                    if (timer >= 130)
                    {
                        bansheerect.X -= 6;
                        bansheerect2.X -= 6;
                        radio1.Play();
                    }
                    if (timer >= 140)
                    {
                        radio1.Stop();

                    }
                    if (timer >= 160)
                    {

                        brothersInArms.Play();
                        haloflyingtheme.Stop();
                    }
                    if (timer >= 0)
                    {
                        bansheerect.X -= 0;
                        bansheerect2.X -= 0;
                        phantomrect.X -= 0;
                        bansheerect.X = 800;
                        bansheerect2.X = 800;
                        phantomrect.X = 1200;

                    }
                    if (timer >= 0 && bossFight == false)
                    {
                      weaponsOn = false;


                      bossShiprect.X -= 1;
                        if (bossShiprect.X <= 500)
                        {
                            weaponsOn = true;
                            bossShiprect.X = 500;
                            bossShiprect.X -= 0;
                            bossShiprect.Y -= 2;
                            if (bossShiprect.Y <= 100)
                            {
                                bossShiprect.Y = 100;
                                bossShiprect.Y += 2;
                                bossFight = true;
                            }
                        }

                    }


                    if (bossFight == true)
                    {
                        energyShield1rect = new Rectangle(bossShiprect.X + -100, bossShiprect.Y , 100, 300);
                        if (shieldTimer >= 20f && energyShieldOff == true)
                        {

                          energyShieldHealth = 8;
                          energyShieldOff = false;
                          shieldTimer = 0;
                        }
                    bossShiprect.Y += (int)(float)(Math.Sin(timer) * 2);
                        plasmaTime = 2f;
                        if (bossShipHealth <= 25)
                        {
                            bossShiprect.X -= 0;
                            bossShiprect.Y += (int)(float)(Math.Sin(timer) * 3);

                        }
                        else if (bossShipHealth <= 20)
                        {
                            bossShiprect.X -= 0;
                            bossShiprect.Y += (int)(float)(Math.Sin(timer) * 3);

                            plasmaTime = 1.5f;
                        }
                        else if (bossShipHealth <= 15)
                        {
                            bossShiprect.X -= 0;
                            bossShiprect.Y += (int)(float)(Math.Sin(timer) * 3);
                            plasmaTime = 1f;
                        }
                        else if (bossShipHealth <= 10)
                        {
                            bossShiprect.X -= 0;
                            bossShiprect.Y += (int)(float)(Math.Sin(timer) * 3);

                            plasmaTime = 0.5f;
                        }
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
                if (screen == Screen.GameOver)
                {

                }
                if (bossShipHealth == 0)
                {
                    bossShiprect.X += 1;
                    bossShiprect.Y += 3;
                }





                // TODO: Add your update logic here

                base.Update(gameTime);

            
        }

                   
                


                    
                
            
        
        


		protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            _spriteBatch.Begin();
            if (screen == Screen.MainMenu)
            {
                _spriteBatch.Draw(ringTexture, ringrect, Color.White);
                _spriteBatch.Draw(logoTexture, logorect, Color.White);
                _spriteBatch.Draw(buttonTexture, buttonrect, Color.White);

            }
            if (screen == Screen.GameOver)
            {
                _spriteBatch.Draw(skyTexture, window, Color.Black);
                _spriteBatch.Draw(explosionTexture, deathScreenrect, Color.White);
            }
            if (screen == Screen.CutScreen1)
            {
                _spriteBatch.Draw(skyTexture, window, Color.White);

                _spriteBatch.Draw(cityTexture, cityrect, Color.White);

                _spriteBatch.Draw(cityTexture, cityrect2, Color.White);
                if (cutScene1 == false)
                {
                    _spriteBatch.Draw(peilcan_up_right, peilcanrect, Color.White);
                }

                if (peilcanrect.Y <= 300)
                {
                    _spriteBatch.Draw(peilcanTexture, peilcanrect, Color.White);
                    cutScene1 = true;
                }
                if (cutScene2 == false)
                {
                    _spriteBatch.Draw(peilcan_up_right, peilcanrect2, Color.White);
                }
                if (peilcanrect2.Y <= 250)
                {
                    _spriteBatch.Draw(peilcanTexture, peilcanrect2, Color.White);
                    cutScene2 = true;
                }
                if (cutScene3 == false)
                {
                    _spriteBatch.Draw(peilcan_up_right, peilcanrect3, Color.White);
                }
                if (peilcanrect3.Y <= 200)
                { 
                    _spriteBatch.Draw(peilcanTexture, peilcanrect3, Color.White);
                    cutScene3 = true;
                }



                _spriteBatch.Draw(bansheeTexture, bansheerect, Color.White);
                _spriteBatch.Draw(bansheeTexture, bansheerect2, Color.White);

                if (cutSceneEvent == true)
				{
					_spriteBatch.Draw(explosionTexture, peilcanrect3, Color.White);
					_spriteBatch.Draw(explosionTexture, bansheerect, Color.White);

					_spriteBatch.Draw(explosionTexture, peilcanrect2, Color.White);
					_spriteBatch.Draw(explosionTexture, bansheerect2, Color.White);
				}


			}
            if (screen == Screen.Level1)
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

                _spriteBatch.Draw(bossShipTexture, bossShiprect, Color.White);
                if (energyShieldOff == false)
                {

                    if (energyShieldHealth >= 8)
                    {
                        _spriteBatch.Draw(energyShieldTexture1, energyShield1rect, Color.White);
                    }
                    else if (energyShieldHealth >= 6)
                    {
                        _spriteBatch.Draw(energyShieldTexture2, energyShield1rect, Color.White);
                    }
                    else if (energyShieldHealth >= 4)
                    {
                        _spriteBatch.Draw(energyShieldTexture3, energyShield1rect, Color.White);
                    }
                    else if (energyShieldHealth >= 2)
                    {
                        _spriteBatch.Draw(energyShieldTexture4, energyShield1rect, Color.White);
                    }
                    else if (energyShieldHealth <= 0)
                    {
                        energyShieldOff = true;
                    }
                    else if (shieldTimer >= 5f)
                    {
                        
                    }
                }

				foreach (Vector2 position in plasmaPositions)
				{
					_spriteBatch.Draw(plasmaShot, position, Color.White);
				}
                _spriteBatch.Draw(bossShipTexture, bossShiprect, Color.White);
				foreach (Vector2 position in bulletPositions)
                {
                    _spriteBatch.Draw(bulletTexture, position, Color.White);
                }
                foreach (Vector2 position in missilePositions)
                {
                    _spriteBatch.Draw(missileTexture, position, Color.White);
                }


                if (peilcanRightShow == true)
				{
					_spriteBatch.Draw(peilcanTexture, peilcanrect, Color.White);
				}



				if (Keyboard.GetState().IsKeyDown(Keys.Left))
				{
					peilcanLeftShow = true;


					peilcanLeftShow = true;
					if (peilcanLeftShow == true)
					{
						_spriteBatch.Draw(peilcan_Left, peilcanrect, Color.White);
					}

					peilcanRightShow = false;
				}
				if (Keyboard.GetState().IsKeyDown(Keys.Right))
				{
					peilcanRightShow = true;
					
					peilcanRightUpShow = false;
					peilcanRightDownShow = false;
				}
				if (Keyboard.GetState().IsKeyDown(Keys.Up))
				{
					
					peilcanRightDownShow = false;
					peilcanRightShow = false;
					peilcanLeftShow = false;
					peilcanRightUpShow = true;
					if (peilcanRightUpShow == true)
					{
						_spriteBatch.Draw(peilcan_up_right, peilcanrect, Color.White);
					}
				}
				if (Keyboard.GetState().IsKeyDown(Keys.Down))
				{
					
					peilcanRightUpShow = false;
					peilcanRightShow = false;
					peilcanLeftShow = false;
					peilcanRightDownShow = true;
					if (peilcanRightDownShow == true)
					{
						_spriteBatch.Draw(peilcan_down_right, peilcanrect, Color.White);
					}
				}


				if (Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down) && Keyboard.GetState().IsKeyUp(Keys.Left))
				{
					peilcanRightShow = true;
					peilcanLeftShow = false;
					
					peilcanRightUpShow = false;
					peilcanRightDownShow = false;

				}



				

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

                if (bulletrect.Intersects(bansheerect))
                {

                    _spriteBatch.Draw(explosionTexture, bansheerect, Color.White);
                }
                if (bulletrect.Intersects(bansheerect2))
                {

                    _spriteBatch.Draw(explosionTexture, bansheerect2, Color.White);
                }

                if (lifes == 3)
                {
                    _spriteBatch.Draw(peilcanTexture, playerLife1rect, Color.White);
                    _spriteBatch.Draw(peilcanTexture, playerLife2rect, Color.White);
                    _spriteBatch.Draw(peilcanTexture, playerLife3rect, Color.White);
                }
                else if (lifes == 2)
                {
                    _spriteBatch.Draw(peilcanTexture, playerLife1rect, Color.White);
                    _spriteBatch.Draw(peilcanTexture, playerLife2rect, Color.White);
                }
                else if (lifes == 1)
                {
                    _spriteBatch.Draw(peilcanTexture, playerLife1rect, Color.White);
                }




            }
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
            
        }
    }
}

