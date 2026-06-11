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
        Level1Intro,
        Level1,
        Level2Intro,
        Level2,
        level3Intro,
        Level3,
		GameOver
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private float bulletTimer = 0;
        private float bulletTime = 1;
		float centerY = 300f;
		bool bulletActive = false, peilcanRightShow = true, peilcanLeftShow = false, peilcanRightUpShow = false, peilcanRightDownShow = false, bossFight = false, cutScene1 = false, cutScene2 = false, cutScene3 = false, bansheeActive = true, cutSceneEvent = false, peilcanActive, blowMeAwayActive = false, energyShieldOff = false, weaponsOn = true, coreExposed = false, floodSporeActive = false;
        Rectangle window;
        MouseState mouse;
        Random generator = new Random();
        //
        Screen screen = Screen.MainMenu;
        // level 1 textures and rectangles
        Texture2D new_mombasaIntroTexture;
        Rectangle newMombasaIntroRect;
        Random Random = new Random();
        int randomText = 1;
        private float textTimer = 0;
        private float textTime = 2;
        Texture2D cityTexture, peilcanTexture, covenant_shipTexture, ringTexture, bansheeTexture, skyTexture, build1Texture,unscShipTexture, logoTexture, bulletTexture, explosionTexture,phantomTexture, buttonTexture, bossShipTexture, missileTexture;
        Rectangle cityrect, cityrect2, cityrect3, cityrect4, peilcanrect, covenantshiprect, ringrect, peilcanrect2, peilcanrect3,  bansheerect, bansheerect2, build1rect, unscshiprect, logorect, bulletrect, explosionrect, phantomrect, buttonrect, bossShiprect, deathScreenrect, missilerect;
		Texture2D peilcan_up_right, peilcan_down_right, peilcan_Left;
        Texture2D plasmaShot;
        Rectangle plasmaShotrect;
        SpriteFont font;
        Texture2D ringSkyTexture;
        Rectangle ringTreesrect, ringSkyrect, ring2rect, ringTreesrect2;
		Texture2D energyShieldTexture1, energyShieldTexture2, energyShieldTexture3, energyShieldTexture4;
        Rectangle energyShield1rect, energyShield2rect, energyShield3rect, energyShield4rect;
        Rectangle core1rect, core2rect, core3rect;
        Texture2D coreTexture, core2Texture, core3Texture;
        Rectangle playerLife1rect, playerLife2rect, playerLife3rect;
		// level 2 textures and rectangles
		Texture2D mountinTexture,ring2Texture, ringTreesTexture, sentinelTexture, enforcerTexture, controllerTexture, laserTexture;
        Rectangle mountinrect1, mountinrect2, sentinelrect1, sentinelrect2,sentinelrect3, enforcerrect1, controllerrect, laserrect;
        int enforcerHealth = 5;
        Texture2D Installation_05Texture;
        Rectangle Installation_05rect;
        Rectangle controllerPositions;
		// 2 boss
		bool boss2Fight = false, guardianActive = true;
		Texture2D guardianTexture;
		Rectangle guardianrect;
		int guardianHealth = 100;
		SoundEffectInstance guardianTheme;
        Texture2D plasmaballTexture, EMPballTexture;

        List<Vector2> bigplasmaPositions = new List<Vector2>();
        List<Vector2> bigplasmaVelocities = new List<Vector2>();
        Rectangle bigplasmarect;
        private float bigplasmaTimer = 0;
        private float bigplasmaTime = 3f;
        // shake event
        // Screen shake variables
        float shakeTime = 0f;
		float shakeMagnitude = 10f; // Pixels of max shake
		Random random = new Random();


		// level 3 textures and rectangles
		Texture2D highCharityloadingTexture, covenantCityleftTexture, covenantCityrightTexture;
        Texture2D highCharityTexture, highCharity2Texture, highCharity3Texture, highCharity4Texture;
        Rectangle highCharityRect, covenantcityleftrect, covenantcityrightrect, bansheerect3, bansheerect4, bansheerect5;
        SoundEffectInstance Charitys_IronyTheme,floodTheme;
        Texture2D floodbomberTexture, floodedphantomTexture, floodsporeTexture;
        Rectangle floodedphantomrect, floodbomberrect, floodsporerect;
        List<Rectangle> floodSpore;
        Vector2 floodFallSpeed;
		float timer = 0,levelTwoTimer = 0, bulletSpeed = 10f, interval = 0.2f, plasmaSpeed = -15f, missileSpeed = 10f, levelThreeTimer = 0;
        SoundEffectInstance haloTheme, haloflyingtheme, peilcanSound, radio1, bulletfire, brothersInArms,blowMeAway, moonOverMombasa;
        SoundEffectInstance beholdAPaleHorseTheme;
        int lifes = 3, phantomHealth = 3, bossShipHealth = 30;
        int energyShieldHealth = 8, coreHealth = 3;
        List<Vector2> bulletPositions = new List<Vector2>();
        List<Vector2> bulletVelocities = new List<Vector2>();

		List<Vector2> plasmaPositions = new List<Vector2>();
		List<Vector2> plasmaVelocities = new List<Vector2>();

		List<Vector2> plasmaPositions2 = new List<Vector2>();
		List<Vector2> plasmaVelocities2 = new List<Vector2>();

		List<Vector2> missilePositions = new List<Vector2>();
        List<Vector2> missileVelocities = new List<Vector2>();
		private float plasmaTimer = 0;
		private float plasmaTime = 3f;

		private float plasmaTimer2 = 0;
		private float plasmaTime2 = 3f;

		private float missileTimer = 0;
        private float missileTime = 5f;

        private float shieldTimer = 0;
		private float offsetY;

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

			bansheerect5 = new Rectangle(900, 0, 60, 40);

			bansheerect4 = new Rectangle(900, 0, 60, 40);

            bansheerect3 = new Rectangle(900, 0, 60, 40);

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

            energyShield1rect = new Rectangle(-10, -10, 20, 20);

            energyShield2rect = new Rectangle(-10, -10, 20, 20);

            energyShield3rect = new Rectangle(-10, -10, 20, 20);

            energyShield4rect = new Rectangle(-10, -10, 20, 20);

            core1rect = new Rectangle(0, 0, 20, 20);

            core2rect = new Rectangle(0, 0, 20, 20);

            core3rect = new Rectangle(0, 0, 20, 20);

            ring2rect = new Rectangle(-200, -100, 1200, 600);

            ringTreesrect = new Rectangle(0, 0, 800, 500);

            ringTreesrect2 = new Rectangle(0, 0, 800, 500);

			ringSkyrect = new Rectangle(0, 0, 800, 500);

            mountinrect1 = new Rectangle(0, 100, 1000, 400);

            mountinrect2 = new Rectangle(1000, 100, 1000, 400);

			sentinelrect1 = new Rectangle(900, 300, 50, 50);

			sentinelrect2 = new Rectangle(1200, 300, 50, 50);

            sentinelrect3 = new Rectangle(1300, 300, 50, 50);

            enforcerrect1 = new Rectangle(1500, 300, 80, 80);

            highCharityRect = new Rectangle(0, 0, 800, 500);

            controllerrect = new Rectangle(900, 300, 50, 50);

            newMombasaIntroRect = new Rectangle(0, 0, 800, 500);

            Installation_05rect = new Rectangle(0, 0, 800, 500);

            covenantcityleftrect = new Rectangle(0, 300, 1000, 300);

            covenantcityrightrect = new Rectangle(1000, 300, 1000, 300);

			floodbomberrect = new Rectangle(900, 300, 40, 50);

			floodedphantomrect = new Rectangle(1200, 300, 150, 100);

			guardianrect = new Rectangle(50, 800, 700, 1300);

			floodSpore = new List<Rectangle>();

            

			floodFallSpeed = new Vector2(0, 1);
			for (int i = 0; i < 100; i++)
			{
				int x = generator.Next(0, 800);
                int y = generator.Next(0, 600);
				
				floodSpore.Add(new Rectangle(x, y, 5, 5));
			}

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

            font = Content.Load<SpriteFont>("maintext");

            coreTexture = Content.Load<Texture2D>("core1");

            core2Texture = Content.Load<Texture2D>("core2");

            core3Texture = Content.Load<Texture2D>("core3");

            moonOverMombasa = Content.Load<SoundEffect>("2-06 Moon Over Mombasa").CreateInstance();

            ring2Texture = Content.Load<Texture2D>("download (22) (1)");

            ringSkyTexture = Content.Load<Texture2D>("ring_sky");

			ringTreesTexture = Content.Load<Texture2D>("trees");

            mountinTexture = Content.Load<Texture2D>("halobackground");

			beholdAPaleHorseTheme = Content.Load<SoundEffect>("1-14 Behold a Pale Horse").CreateInstance();

			sentinelTexture = Content.Load<Texture2D>("sentinel");

			enforcerTexture = Content.Load<Texture2D>("Enforcer");

			highCharityTexture = Content.Load<Texture2D>("high");

			Charitys_IronyTheme = Content.Load<SoundEffect>("2-05 Charity's Irony").CreateInstance();

            controllerTexture = Content.Load<Texture2D>("controller");

			covenantCityleftTexture = Content.Load<Texture2D>("covenant_cityleft");

			covenantCityrightTexture = Content.Load<Texture2D>("covenant_cityRight");

			highCharity2Texture = Content.Load<Texture2D>("high2");

			highCharity3Texture = Content.Load<Texture2D>("high3");

			highCharity4Texture = Content.Load<Texture2D>("high4");

			floodTheme = Content.Load<SoundEffect>("13. Martin O'Donnell - Devils... Monsters..").CreateInstance();

			floodbomberTexture = Content.Load<Texture2D>("floodbomber");

			floodedphantomTexture = Content.Load<Texture2D>("floodedPhantom");

			floodsporeTexture = Content.Load<Texture2D>("flood spore(1)");

            guardianTheme = Content.Load<SoundEffect>("21. Adjutant Resolution (1)").CreateInstance();

			guardianTexture = Content.Load<Texture2D>("guardian");

			plasmaballTexture = Content.Load<Texture2D>("plasmaball2 (1)");

			EMPballTexture = Content.Load<Texture2D>("plasmaball");

			// intros
			new_mombasaIntroTexture = Content.Load<Texture2D>("New Mombasa");

            Installation_05Texture = Content.Load<Texture2D>("Installation 05");

            highCharityloadingTexture = Content.Load<Texture2D>("High Charity");

            // TODO: use this.Content to load your game content here
        }



        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouse = Mouse.GetState();
            bulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            plasmaTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            bigplasmaTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            missileTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;


            KeyboardState keyboardState = Keyboard.GetState();

            if (buttonrect.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && screen == Screen.MainMenu)
            {

                haloTheme.Stop();
                blowMeAway.Stop();


                screen = Screen.Level1Intro;


            }
            if (screen == Screen.MainMenu)
            {
                weaponsOn = false;
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
                if (Keyboard.GetState().IsKeyDown(Keys.D2))
                {
                    screen = Screen.Level2Intro;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D3))
                {
                    screen = Screen.level3Intro;
                }
            }

            if (screen == Screen.intro)
            {


            }
            if (screen == Screen.Level1Intro)
            {


                textTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (textTimer >= textTime)
                {
                    textTimer = 0;
                    randomText = Random.Next(1, 3);
                }







                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    screen = Screen.CutScreen1;
                }
            }
            if (screen == Screen.Level2Intro)
            {
                textTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (textTimer >= textTime)
                {
                    textTimer = 0;
                    randomText = Random.Next(1, 3);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    screen = Screen.Level2;
                }
            }
            if (screen == Screen.level3Intro)
            {
                textTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                guardianTheme.Stop();
                if (textTimer >= textTime)
                {
                    textTimer = 0;
                    randomText = Random.Next(1, 3);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    screen = Screen.Level3;
                }
            }




            if (keyboardState.IsKeyDown(Keys.Space) && bulletTimer >= bulletTime)
            {
                bulletPositions.Add(peilcanrect.Location.ToVector2() + new Vector2(peilcanrect.Width, peilcanrect.Height / 2 - bulletrect.Height / 2));

                bulletVelocities.Add(new Vector2(bulletSpeed, 0));

                bulletfire.Play();

                bulletTimer = 0;
            }
            for (int i = bulletPositions.Count - 1; i >= 0; i--)
            {
                // update position first
                bulletPositions[i] += bulletVelocities[i];
                var pos = bulletPositions[i];

                if (peilcanLeftShow)
                    bulletVelocities[i] = new Vector2(-bulletSpeed, 0);

                if (pos.X > 800 || pos.X < 10)
                {
                    bulletPositions.RemoveAt(i);
                    bulletVelocities.RemoveAt(i);
                    continue;
                }

                if (bansheerect.Contains(pos))
                {
                    bansheerect = new Rectangle(850, new Random().Next(0, 450), 60, 40);
                    bulletPositions.RemoveAt(i);
                    bulletVelocities.RemoveAt(i);
                    continue;
                }

                if (bansheerect2.Contains(pos))
                {
                    bansheerect2 = new Rectangle(850, new Random().Next(0, 450), 60, 40);
                    bulletPositions.RemoveAt(i);
                    bulletVelocities.RemoveAt(i);
                    continue;
                }

                if (phantomrect.Contains(pos))
                {
                    phantomHealth--;
                    bulletPositions.RemoveAt(i);
                    bulletVelocities.RemoveAt(i);
                    continue;
                }
                if (enforcerrect1.Contains(pos) && screen == Screen.Level2)
                {
                    enforcerHealth--;
                    bulletPositions.RemoveAt(i);
                    bulletVelocities.RemoveAt(i);
                    continue;
                }



                if (!energyShieldOff && energyShield1rect.Contains(pos))
                {
                    energyShieldHealth--;
                    bulletPositions.RemoveAt(i);
                    bulletVelocities.RemoveAt(i);
                    continue;
                }
                if (core1rect.Contains(pos))
                {
                    coreHealth--;
                    bulletPositions.RemoveAt(i);
                    bulletVelocities.RemoveAt(i);
                    continue;
                }
                if (core2rect.Contains(pos))
                {
                    coreHealth--;
                    bulletPositions.RemoveAt(i);
                    bulletVelocities.RemoveAt(i);
                    continue;
                }
                if (core3rect.Contains(pos))
                {
                    coreHealth--;
                    bulletPositions.RemoveAt(i);
                    bulletVelocities.RemoveAt(i);
                    continue;
                }
                if (sentinelrect1.Contains(pos) && screen == Screen.Level2)
                {
                    sentinelrect1 = new Rectangle(900, new Random().Next(0, 450), 50, 50);
                    bulletPositions.RemoveAt(i);
                    bulletVelocities.RemoveAt(i);
                    continue;
                }
                if (sentinelrect2.Contains(pos) && (screen == Screen.Level2))
                {
                    sentinelrect2 = new Rectangle(1200, new Random().Next(0, 450), 50, 50);
                    bulletPositions.RemoveAt(i);
                    bulletVelocities.RemoveAt(i);
                    continue;
                }
				if (bansheerect3.Contains(pos))
				{
					bansheerect3 = new Rectangle(850, new Random().Next(0, 450), 60, 40);
					bulletPositions.RemoveAt(i);
					bulletVelocities.RemoveAt(i);
					continue;
				}
				if (bansheerect4.Contains(pos))
				{
					bansheerect4 = new Rectangle(850, new Random().Next(0, 450), 60, 40);
					bulletPositions.RemoveAt(i);
					bulletVelocities.RemoveAt(i);
					continue;
				}
				if (bansheerect5.Contains(pos))
				{
					bansheerect5 = new Rectangle(850, new Random().Next(0, 450), 60, 40);
					bulletPositions.RemoveAt(i);
					bulletVelocities.RemoveAt(i);
					continue;
				}


			}

            if (keyboardState.IsKeyDown(Keys.M) && missileTimer >= missileTime)
            {

                missilePositions.Add(peilcanrect.Location.ToVector2() + new Vector2(peilcanrect.Width, peilcanrect.Height / 2 - missilerect.Height / 2));
                missileVelocities.Add(new Vector2(missileSpeed, 0));
                missileTimer = 0;
            }
            for (int k = missilePositions.Count - 1; k >= 0; k--)
            {
                missilePositions[k] += missileVelocities[k];
                var pos = missilePositions[k];
                if (missilePositions[k].X > 800)
                {
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    continue;
                }
                if (bansheerect.Contains(pos))
                {
                    bansheerect = new Rectangle(850, new Random().Next(0, 450), 60, 40);
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    continue;
                }
                if (bansheerect2.Contains(pos))
                {
                    bansheerect2 = new Rectangle(850, new Random().Next(0, 450), 60, 40);
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    continue;
                }
                if (phantomrect.Contains(pos))
                {
                    phantomHealth -= 2;
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    continue;
                }

                if (!energyShieldOff && energyShield1rect.Contains(pos))
                {
                    energyShieldHealth -= 2;
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    continue;
                }
                if (core1rect.Contains(pos))
                {
                    coreHealth--;
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    continue;
                }
                if (core2rect.Contains(pos))
                {
                    coreHealth--;
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    continue;
                }
                if (core3rect.Contains(pos))
                {
                    coreHealth--;
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    continue;
                }
                if (sentinelrect1.Contains(pos) && screen == Screen.Level2)
                {
                    sentinelrect1 = new Rectangle(900, new Random().Next(0, 450), 50, 50);
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    continue;
                }
                if (sentinelrect2.Contains(pos) && screen == Screen.Level2)
                {
                    sentinelrect1 = new Rectangle(900, new Random().Next(0, 450), 50, 50);
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    continue;
                }
                if (enforcerrect1.Contains(pos) && screen == Screen.Level2)
                {
                    enforcerHealth -= 2;
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    continue;
                }
                if (bansheerect3.Contains(pos))
				{
					bansheerect3 = new Rectangle(850, new Random().Next(0, 450), 60, 40);
					missilePositions.RemoveAt(k);
					missileVelocities.RemoveAt(k);
					continue;
				}
				if (bansheerect4.Contains(pos))
				{
					bansheerect4 = new Rectangle(850, new Random().Next(0, 450), 60, 40);
					missilePositions.RemoveAt(k);
					missileVelocities.RemoveAt(k);
					continue;
				}
				if (bansheerect5.Contains(pos))
				{
					bansheerect5 = new Rectangle(850, new Random().Next(0, 450), 60, 40);
					missilePositions.RemoveAt(k);
					missileVelocities.RemoveAt(k);
					continue;
				}
			}







            if (bossFight == true)
            {


                if (plasmaTimer >= plasmaTime)
                {
                    plasmaPositions.Add(bossShiprect.Location.ToVector2() + new Vector2(bossShiprect.Width, bossShiprect.Height / 2 - plasmaShot.Height / 2));

                    plasmaVelocities.Add(new Vector2(plasmaSpeed, 0));



                    plasmaTimer = 0;
                }
                for (int j = plasmaPositions.Count - 1; j >= 0; j--)
                {
                    plasmaPositions[j] += plasmaVelocities[j];
                    var pos = plasmaPositions[j];
                    if (plasmaPositions[j].X < 0)
                    {
                        plasmaPositions.RemoveAt(j);
                        plasmaVelocities.RemoveAt(j);
                        continue;
                    }
                    if (peilcanrect.Contains(pos))
                    {
                        lifes--;
                        peilcanrect.X = 200;
                        peilcanrect.Y = 50;
                        plasmaPositions.RemoveAt(j);
                        plasmaVelocities.RemoveAt(j);
                        continue;
                    }

                }
            }
            if (screen == Screen.Level2)
            {

                if (plasmaTimer2 >= plasmaTime2)
                {
                    plasmaPositions2.Add(enforcerrect1.Location.ToVector2() + new Vector2(enforcerrect1.Width, enforcerrect1.Height / 2 - plasmaShot.Height / 2));

                    plasmaVelocities2.Add(new Vector2(plasmaSpeed, 0));

                    plasmaTimer2 = 0;
                }
                for (int j = plasmaPositions2.Count - 1; j >= 0; j--)
                {
                    plasmaPositions2[j] += plasmaVelocities2[j];
                    var pos = plasmaPositions2[j];
                    if (plasmaPositions2[j].X < 0)
                    {
                        plasmaPositions2.RemoveAt(j);
                        plasmaVelocities2.RemoveAt(j);
                        continue;
                    }
                    if (peilcanrect.Contains(pos))
                    {
                        lifes--;
                        peilcanrect.X = 200;
                        peilcanrect.Y = 50;
                        plasmaPositions2.RemoveAt(j);
                        plasmaVelocities2.RemoveAt(j);
                        continue;
                    }
                }

            }


            if (screen == Screen.CutScreen1)
            {

                weaponsOn = false;
                moonOverMombasa.Play();
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
                            moonOverMombasa.Stop();
                            screen = Screen.Level1;
                        }
                    }
                }











            }





            if (screen == Screen.Level1)
            {

                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                moonOverMombasa.Play();
                haloTheme.Stop();
                peilcanSound.Play();

                if (moonOverMombasa.State == SoundState.Stopped)
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
                    weaponsOn = true;
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
                if (timer >= 110)
                {
                    bansheerect.X -= 6;
                    bansheerect2.X -= 6;
                    radio1.Play();
                }
                if (timer >= 120)
                {
                    radio1.Stop();

                }
                if (timer >= 125)
                {

                    brothersInArms.Play();

                }
                if (timer >= 145)
                {
                    bansheerect.X -= 0;
                    bansheerect2.X -= 0;
                    phantomrect.X -= 0;
                    bansheerect.X = 800;
                    bansheerect2.X = 800;
                    phantomrect.X = 1200;
                    weaponsOn = false;

                    brothersInArms.Stop();
                    moonOverMombasa.Stop();

                }
                if (timer >= 150 && bossFight == false)
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
                    haloflyingtheme.Play();
                    energyShield1rect = new Rectangle(bossShiprect.X + -100, bossShiprect.Y, 100, 300);
                    if (energyShieldOff == true)
                    {
                        shieldTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }

                    if (shieldTimer >= 10f && energyShieldOff == true)
                    {

                        energyShieldHealth = 8;
                        energyShieldOff = false;
                        shieldTimer = 0;
                    }
                    bossShiprect.Y += (int)(float)(Math.Sin(timer) * 2);
                    plasmaTime = 2f;

                    if (bossShipHealth <= 20)
                    {
                        bossShiprect.X -= 0;
                        bossShiprect.Y += (int)(float)(Math.Sin(timer) * 3);

                        plasmaTime = 1.5f;
                    }

                    else if (bossShipHealth <= 10)
                    {
                        bossShiprect.X -= 0;
                        bossShiprect.Y += (int)(float)(Math.Sin(timer) * 3);

                        plasmaTime = 0.5f;
                    }

                    if (energyShieldOff == true)
                    {
                        if (coreHealth == 3)
                        {
                            core1rect = new Rectangle(bossShiprect.X + 50, bossShiprect.Y + 150, 50, 50);
                        }
                        else if (coreHealth == 2)
                        {
                            core2rect = new Rectangle(bossShiprect.X + 50, bossShiprect.Y + 150, 50, 50);
                        }
                        else if (coreHealth == 1)
                        {
                            core3rect = new Rectangle(bossShiprect.X + 50, bossShiprect.Y + 150, 50, 50);
                        }
                        else if (coreHealth == 0)
                        {
                            coreHealth = 3;
                            energyShieldOff = false;
                            bossShipHealth -= 10;
                        }



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

                
                if (bossShipHealth == 0)
                {
                    bossShiprect.X += 1;
                    bossShiprect.Y += 3;
                    if (bossShiprect.Y >= 600)
                    {
                        bossShiprect.X = 1200;
                        bossShiprect.Y = 300;
                        levelTwoTimer = 0;
                        haloflyingtheme.Stop();

                        screen = Screen.Level2Intro;
                    }




                }
            }

            if (screen == Screen.Level2)
            {
                levelTwoTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                haloTheme.Stop();
                haloflyingtheme.Stop();
                blowMeAway.Stop();
                beholdAPaleHorseTheme.Play();

                mountinrect1.X -= 1;
                mountinrect2.X -= 1;
                sentinelrect1.X -= 3;
                sentinelrect2.X -= 3;
				
                if (shakeTime > 0)
				{
					shakeTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
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
                if (mountinrect1.X <= -1000)
                {
                    mountinrect1.X = 1000;
                }
                if (mountinrect2.X <= -1000)
                {
                    mountinrect2.X = 1000;
                }
                if (sentinelrect1.X <= -50)
                {
                    sentinelrect1.X = 850;
                    sentinelrect1.Y = new Random().Next(0, 450);
                }
                if (sentinelrect2.X <= -50)
                {
                    sentinelrect2.X = 850;
                    sentinelrect2.Y = new Random().Next(0, 450);
                }
                if (sentinelrect3.X <= -50)
                {
                    sentinelrect3.X = 850;
                    sentinelrect3.Y = new Random().Next(0, 450);
                }
                if (peilcanrect.Intersects(sentinelrect1))
                {
                    lifes--;
                    peilcanrect.X = 200;
                    peilcanrect.Y = 50;
                    sentinelrect1.X = 850;
                    sentinelrect1.Y = new Random().Next(0, 450);
                }
                if (peilcanrect.Intersects(sentinelrect2))
                {
                    lifes--;
                    peilcanrect.X = 200;
                    peilcanrect.Y = 50;
                    sentinelrect2.X = 850;
                    sentinelrect2.Y = new Random().Next(0, 450);
                }
                if (peilcanrect.X <= -100)
                {
                    peilcanrect.X = 900;
                }
                else if (peilcanrect.X >= 900)
                {
                    peilcanrect.X = -100;
                }
                if (enforcerrect1.X <= -100)
                {
                    enforcerrect1.X = 900;
                    enforcerrect1.Y = new Random().Next(0, 450);
                }



                if (levelTwoTimer >= 0)
                {
                    weaponsOn = true;
                    sentinelrect1.X -= 3;
                    sentinelrect2.X -= 3;
                }
                if (levelTwoTimer >= 8)
                {
                    sentinelrect1.X -= 4;
                    sentinelrect2.X -= 3;
                    sentinelrect1.Y += (int)(float)(Math.Sin(levelTwoTimer) * 2);
                    sentinelrect2.Y += (int)(float)(Math.Sin(levelTwoTimer) * 3);
                }
                if (levelTwoTimer >= 20)
                {
                    enforcerrect1.X -= 2;
                    plasmaTimer2 += (float)gameTime.ElapsedGameTime.TotalSeconds;

                }
                if (levelTwoTimer >= 30)
                {
                    sentinelrect3.X -= 5;
                    sentinelrect3.Y += (int)(float)(Math.Sin(levelTwoTimer) * 4);
                }
                if (levelTwoTimer >= 40)
                {
                    controllerrect.X -= 2;

                }
                if (levelTwoTimer >= 3)
                {
                    
					
					sentinelrect1.X -= 0;
                    sentinelrect2.X -= 0;
                    sentinelrect3.X -= 0;
                    enforcerrect1.X -= 0;
                    controllerrect.X -= 0;
                    sentinelrect1.X = 800;
                    sentinelrect2.X = 800;
                    sentinelrect3.X = 800;
                    enforcerrect1.X = -80;
                    controllerrect.X = 800;
                    beholdAPaleHorseTheme.Stop();
					
                    shakeTime = 0.5f; // Shakes for half a second




				}
				if (levelTwoTimer >= 5)
                {
                    
					if (guardianActive == true)
                    {
						guardianrect.Y -= 1;
					}
						
                    guardianTheme.Play();

                }
                if (boss2Fight == false)
                {
                    
                    if (guardianrect.Y <= 80)
                    {
                        guardianrect.Y = 80;
                        guardianrect.Y -= 0;
						boss2Fight = true;
						
					}
                }
                if (boss2Fight == true)
                {
					shakeTime = 0;
					guardianrect.Y -= 0;
                    if (guardianHealth == 100)
                    {
                        if (bigplasmaTimer >= bigplasmaTime)
                        {
							//(guardianrect.Location.ToVector2() + new Vector2(guardianrect.Width - 360, guardianrect.Height - 1050)

							bigplasmaPositions.Add((guardianrect.Location.ToVector2() + new Vector2(guardianrect.Width - 360, guardianrect.Height - 1050)));

                            bigplasmaVelocities.Add(new Vector2(0, -2));

                            bigplasmaVelocities.Add(new Vector2(0, 2));

                            bigplasmaVelocities.Add(new Vector2(2, 0));

                            bigplasmaVelocities.Add(new Vector2(-2, 0));

                            bigplasmaTimer = 0;
                        }
                        for (int j = bigplasmaPositions.Count - 1; j >= 0; j--)
                        {
                            bigplasmaPositions[j] += bigplasmaVelocities[j];
                            var pos = bigplasmaPositions[j];
                            if (bigplasmaPositions[j].X < -330)
                            {
                                bigplasmaPositions.RemoveAt(j);
                                bigplasmaVelocities.RemoveAt(j);
                                continue;
                            }
                            if (peilcanrect.Contains(pos))
                            {
                                lifes--;
                                peilcanrect.X = 200;
                                peilcanrect.Y = 50;
                                bigplasmaPositions.RemoveAt(j);
                                bigplasmaVelocities.RemoveAt(j);
                                continue;
                            }

                        }
                    }
                    if (guardianHealth > 75)
                    {

                    }
                    if (guardianHealth == 0)
					{
						guardianrect.Y += 1;
						if (guardianrect.Y >= 600)
						{
							guardianrect.X = 1200;
							guardianrect.Y = 300;
							levelTwoTimer = 0;
							screen = Screen.level3Intro;
						}
					}
                    guardianActive = false;
					guardianrect.X += (int)(float)(Math.Sin(levelTwoTimer) * 1.5);
					if (coreHealth == 3)
					{
						core1rect = new Rectangle(guardianrect.X + 325, guardianrect.Y + 230, 50, 30);
					}
					else if (coreHealth == 2)
					{
						core2rect = new Rectangle(guardianrect.X + 325, guardianrect.Y + 230, 50, 30);
					}
					else if (coreHealth == 1)
					{
						core3rect = new Rectangle(guardianrect.X + 325, guardianrect.Y + 230, 50, 30);
					}
					else if (coreHealth == 0)
					{
						coreHealth = 3;
						
						guardianHealth -= 25;
					}




				}
            }
                if (screen == Screen.Level3)
                {
                    levelThreeTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Charitys_IronyTheme.Play();
                    haloTheme.Stop();
                    haloflyingtheme.Stop();
                    blowMeAway.Stop();

                    bansheerect3.X -= 3;
                    covenantcityleftrect.X -= 1;
                    covenantcityrightrect.X -= 1;
                    if (covenantcityleftrect.X <= -1000)
                    {
                        covenantcityleftrect.X = 1000;
                    }
                    if (covenantcityrightrect.X <= -1000)
                    {
                        covenantcityrightrect.X = 1000;
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
                    if (bansheerect3.X <= -50)
                    {
                        bansheerect3.X = 850;
                        bansheerect3.Y = new Random().Next(0, 450);
                    }
                    if (bansheerect4.X <= -50)
                    {
                        bansheerect4.X = 850;
                        bansheerect4.Y = new Random().Next(0, 450);
                    }
                    if (bansheerect5.X <= -50)
                    {
                        bansheerect5.X = 850;
                        bansheerect5.Y = new Random().Next(0, 450);
                    }
                    if (peilcanrect.Intersects(bansheerect5))
                    {
                        lifes--;
                        peilcanrect.X = 200;
                        peilcanrect.Y = 50;
                        bansheerect5.X = 850;
                        bansheerect5.Y = new Random().Next(0, 450);
                    }
                    if (peilcanrect.Intersects(bansheerect4))
                    {
                        lifes--;
                        peilcanrect.X = 200;
                        peilcanrect.Y = 50;
                        bansheerect4.X = 850;
                        bansheerect4.Y = new Random().Next(0, 450);
                    }
                    if (peilcanrect.Intersects(bansheerect3))
                    {
                        lifes--;
                        peilcanrect.X = 200;
                        peilcanrect.Y = 50;
                        bansheerect3.X = 850;
                        bansheerect3.Y = new Random().Next(0, 450);
                    }
                    if (levelThreeTimer >= 0)
                    {
                        weaponsOn = true;
                        bansheerect3.X -= 3;
                    }
                    if (levelThreeTimer >= 10)
                    {
                        bansheerect3.X -= 4;
                        bansheerect4.X -= 4;
                    }
                    if (levelThreeTimer >= 20)
                    {
                        bansheerect3.X -= 5;
                        bansheerect4.X -= 5;
                        bansheerect5.X -= 5;
                    }
                    if (levelThreeTimer >= 125)
                    {
                        bansheerect3.X -= 0;
                        bansheerect4.X -= 0;
                        bansheerect5.X -= 0;
                        bansheerect3.X = 800;
                        bansheerect4.X = 800;
                        bansheerect5.X = 800;
                        Charitys_IronyTheme.Stop();
                    }
                    if (levelThreeTimer >= 130)
                    {
                        floodTheme.Play();
                        floodbomberrect.X -= 3;
                        floodbomberrect.Y += (int)(float)(Math.Sin(levelThreeTimer) * 2);
                        floodSporeActive = true;
                    }
                    if (levelThreeTimer >= 145)
                    {
                        floodbomberrect.X -= 5;
                        floodedphantomrect.X -= 2;
                    }
                    if (floodbomberrect.X < -10)
                    {
                        floodbomberrect.X = 900;
                        floodbomberrect.Y = new Random().Next(0, 450);
                    }
                    if (floodedphantomrect.X < -10)
                    {
                        floodedphantomrect.X = 900;
                        floodedphantomrect.Y = new Random().Next(0, 450);
                    }

                    if (floodSporeActive == true)
                    {
                        for (int i = 0; i < floodSpore.Count; i++)
                        {
                            floodSpore[i] = new Rectangle(floodSpore[i].X, floodSpore[i].Y + (int)floodFallSpeed.Y, floodSpore[i].Width, floodSpore[i].Height);
                            if (floodSpore[i].Y > 600)
                            {
                                floodSpore[i] = new Rectangle(generator.Next(0, 800), generator.Next(0, 600), 5, 5);

                            }
                        }
                    }




                }
                if (screen == Screen.GameOver)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        screen = Screen.MainMenu;
                        lifes = 3;
                        cutScene1 = false;
                        cutScene2 = false;
                        cutScene3 = false;
                        bansheeActive = true;
                        peilcanActive = false;
                        cutSceneEvent = false;

                        bossShipHealth = 50;
                        energyShieldHealth = 8;
                        phantomHealth = 3;
                        peilcanrect.X = 200;
                        peilcanrect.Y = 600;

                        peilcanrect2.X = 50;
                        peilcanrect2.Y = 600;

                        peilcanrect3.X = 0;
                        peilcanrect3.Y = 600;

                        bansheerect.X = 850;
                        bansheerect.Y = new Random().Next(0, 450);
                        bansheerect2.X = 850;
                        bansheerect2.Y = new Random().Next(0, 450);
                        phantomrect.X = new Random().Next(1000, 1500);
                        phantomrect.Y = new Random().Next(0, 450);
                        timer = 0;
                        levelTwoTimer = 0;
                        moonOverMombasa.Stop();
                        peilcanSound.Stop();
                        haloflyingtheme.Stop();
                        haloTheme.Stop();

                    }
                }
            








                // TODO: Add your update logic here

                base.Update(gameTime);
            
        }
        





            




                   
                


                    
                
            
        
        


		protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
			float offsetX = (float)(random.NextDouble() - 0.5) * shakeMagnitude * shakeTime;
			float offsetY = (float)(random.NextDouble() - 0.5) * shakeMagnitude * shakeTime;
			Matrix shakeMatrix = Matrix.CreateTranslation(offsetX, offsetY, 0f);
			_spriteBatch.Begin(transformMatrix: shakeMatrix);
            if (screen == Screen.MainMenu)
            {
                _spriteBatch.Draw(ringTexture, ringrect, Color.White);
                _spriteBatch.Draw(logoTexture, logorect, Color.White);
                _spriteBatch.Draw(buttonTexture, buttonrect, Color.White);

            }
            if (screen == Screen.intro)
            {
                _spriteBatch.DrawString(font, "In the year 2552, humanity is at war with an alien alliance known as the Covenant. The Covenant is a theocratic military alliance of multiple alien species that have united under a common religious belief in the Great Journey, which they believe will lead them to salvation. The Covenant has been waging a genocidal campaign against humanity for decades, and the United Earth Government (UEG) has been struggling to defend itself against the superior technology and firepower of the Covenant.", new Vector2(10, 10) , Color.White);
            }
            if (screen == Screen.GameOver)
            {
                _spriteBatch.Draw(skyTexture, window, Color.Black);
                _spriteBatch.Draw(explosionTexture, deathScreenrect, Color.White);
                _spriteBatch.DrawString(font, "Game Over", new Vector2(350, 200), Color.White);
                _spriteBatch.DrawString(font, "Press Enter to Return to Main Menu", new Vector2(250, 300), Color.White);
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
            if (screen == Screen.Level1Intro)
            {
                _spriteBatch.Draw(new_mombasaIntroTexture, window, Color.White);
                if (randomText == 1)
                {
                    _spriteBatch.DrawString(font, "The city of Mombasa is under attack by the Covenant.", new Vector2(100, 400), Color.White);
                }
                else if (randomText == 2)
                {
                    _spriteBatch.DrawString(font, "The UNSC has sent in the Pelicans to evacuate civilians.", new Vector2(100, 400), Color.White);
                }
                else if (randomText == 3)
                {
                    _spriteBatch.DrawString(font, "You are the pilot of the Pelican, and your mission is to evacuate as many civilians as possible while fighting off the Covenant forces.", new Vector2(20, 400), Color.White);
                }
               

            }
            if (screen == Screen.Level2Intro)
            {
                _spriteBatch.Draw(Installation_05Texture, window, Color.White);
                if (randomText == 1)
                {
                    _spriteBatch.DrawString(font, "1", new Vector2(100, 400), Color.White);
                }
                else if (randomText == 2)
                {
                    _spriteBatch.DrawString(font, "2", new Vector2(100, 400), Color.White);
                }
                else if (randomText == 3)
                {
                    _spriteBatch.DrawString(font, "3", new Vector2(20, 400), Color.White);
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
            
                
                if (energyShieldOff == true)
                {
                    if (coreHealth == 3)
                    {
                        _spriteBatch.Draw(coreTexture, core1rect, Color.White);
                    }
                    else if (coreHealth == 2)
                    {
                        _spriteBatch.Draw(core2Texture, core2rect, Color.White);
                    }
                    else if (coreHealth == 1)
                    {
                        _spriteBatch.Draw(core3Texture, core3rect, Color.White);
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
            if (screen == Screen.Level2)
			{
			  
			  _spriteBatch.Draw(ringSkyTexture, ringSkyrect, Color.White);
              _spriteBatch.Draw(ring2Texture, ring2rect, Color.White);
              _spriteBatch.Draw(mountinTexture, mountinrect1, Color.White);
              _spriteBatch.Draw(mountinTexture, mountinrect2, Color.White);
				
				
			  _spriteBatch.Draw(sentinelTexture, sentinelrect1, Color.White);
              _spriteBatch.Draw(sentinelTexture, sentinelrect2, Color.White);
              _spriteBatch.Draw(enforcerTexture, enforcerrect1, Color.White);
              _spriteBatch.Draw(controllerTexture, controllerrect, Color.White);
              _spriteBatch.Draw(guardianTexture, guardianrect, Color.White);
                foreach (Vector2 position in bulletPositions)
                {
                    _spriteBatch.Draw(bulletTexture, position, Color.White);
                }
                foreach (Vector2 position in missilePositions)
                {
                    _spriteBatch.Draw(missileTexture, position, Color.White);
                }
                foreach (Vector2 position in plasmaPositions2)
                {
                    _spriteBatch.Draw(plasmaShot, position, Color.White);
                }
                foreach (Vector2 position in bigplasmaPositions)
                {
                    _spriteBatch.Draw(plasmaballTexture, position, Color.White);
                }


                if (coreHealth == 3)
				{
					_spriteBatch.Draw(coreTexture, core1rect, Color.White);
				}
				else if (coreHealth == 2)
				{
					_spriteBatch.Draw(core2Texture, core2rect, Color.White);
				}
				else if (coreHealth == 1)
				{
					_spriteBatch.Draw(core3Texture, core3rect, Color.White);
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
                if (levelTwoTimer >= 50)
				{
					
					


					

				}
			}
            if (screen == Screen.level3Intro)
            {   _spriteBatch.Draw(highCharityloadingTexture, window, Color.White);
                if (randomText == 1)
                {
                    _spriteBatch.DrawString(font, "1", new Vector2(100, 400), Color.White);
                }
                else if (randomText == 2)
                {
                    _spriteBatch.DrawString(font, "2", new Vector2(100, 400), Color.White);
                }
                else if (randomText == 3)
                {
                    _spriteBatch.DrawString(font, "3", new Vector2(20, 400), Color.White);
                }

            }




            if (screen == Screen.Level3)
			{
                if (levelThreeTimer >= 0)
                {
                    _spriteBatch.Draw(highCharityTexture, highCharityRect, Color.White);
                }
                if (levelThreeTimer >= 125)
                {
                    _spriteBatch.Draw(highCharity2Texture, highCharityRect, Color.White);
                }
                if (levelThreeTimer >= 130)
                { 
                   _spriteBatch.Draw(highCharity3Texture, highCharityRect, Color.White);
				}
				if (levelThreeTimer >= 135)
				{
					_spriteBatch.Draw(highCharity4Texture, highCharityRect, Color.White);
				}


			  _spriteBatch.Draw(covenantCityleftTexture, covenantcityleftrect, Color.White);
              _spriteBatch.Draw(covenantCityrightTexture, covenantcityrightrect, Color.White);
              _spriteBatch.Draw(bansheeTexture, bansheerect3, Color.White);
              _spriteBatch.Draw(bansheeTexture, bansheerect4, Color.White);
			  _spriteBatch.Draw(bansheeTexture, bansheerect5, Color.White);
              _spriteBatch.Draw(floodbomberTexture, floodbomberrect, Color.White);
			  _spriteBatch.Draw(floodedphantomTexture, floodedphantomrect, Color.White);
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
                if (floodSporeActive == true)
                {
					foreach (Rectangle floodSpore in floodSpore)
					{
						_spriteBatch.Draw(floodsporeTexture, floodSpore, Color.White);
					}
				}
			    
				
			}
           
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
            
        }
    }
}

