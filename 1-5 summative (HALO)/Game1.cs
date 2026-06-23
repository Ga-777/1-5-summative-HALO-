using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        HowToPlayScreen,
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
        Texture2D HTPButtonTexture, HTPButton2Texture, HTPScreenTexture;
        Rectangle HTPButtonrect, HTPButton2rect;
        SoundEffectInstance buttonUI;
		
        bool playerLife = false;

        private float playerLifeTimer = 0, playerLifeTime = 0.70f;


        // Explosion

		// Explosion State
		bool isExploding = false;
		bool isExploding2 = false;
        bool isExploding3 = false;
		bool isExploding4 = false;
        bool isExploding5 = false;
        bool isExploding6 = false;
		bool isExploding7 = false;
        bool isExploding8 = false;
		bool isExploding9 = false;
        // flood
        bool isExploding10 = false;
        bool isExploding11 = false;
        bool isExploding12 = false;
		float explosionTimer = 0f;
		float explosionTime = 0.70f; 

		
		Vector2 explosionPosition;


		//
		Screen screen = Screen.MainMenu;
        // level 1 textures and rectangles
        Texture2D new_mombasaIntroTexture;
        Rectangle newMombasaIntroRect;
        Random Random = new Random();
        int randomText = 1;
        private float textTimer = 0;
        private float textTime = 2;
        Texture2D cityTexture, peilcanTexture, covenant_shipTexture, ringTexture, bansheeTexture, skyTexture, build1Texture,unscShipTexture, logoTexture, bulletTexture, explosionTexture, plasmaExplosionTexture, phantomTexture, buttonTexture, bossShipTexture, missileTexture;
        Rectangle cityrect, cityrect2, cityrect3, cityrect4, peilcanrect, covenantshiprect, ringrect, peilcanrect2, peilcanrect3,  bansheerect, bansheerect2, build1rect, unscshiprect, logorect, bulletrect, explosionrect, phantomrect, buttonrect, bossShiprect, deathScreenrect, missilerect;
		Texture2D peilcan_up_right, peilcan_down_right, peilcan_Left;
        Texture2D plasmaShot;
        Rectangle plasmaShotrect;
        SpriteFont font;
        SoundEffectInstance phantomDestroyed;
        Texture2D ringSkyTexture, gameOverScreenTexture;
        Rectangle ringTreesrect, ringSkyrect, ring2rect, ringTreesrect2;
		Texture2D energyShieldTexture1, energyShieldTexture2, energyShieldTexture3, energyShieldTexture4;
        Rectangle energyShield1rect, energyShield2rect, energyShield3rect, energyShield4rect;
        Rectangle core1rect, core2rect, core3rect;
        Texture2D coreTexture, core2Texture, core3Texture;
        Rectangle playerLife1rect, playerLife2rect, playerLife3rect;
        SoundEffectInstance banshee_death, banshee_death2, banshee_death3, banshee_death4, banshee_death5, phantomDamage;
		// level 2 textures and rectangles
		Texture2D mountinTexture,ring2Texture, ringTreesTexture, sentinelTexture, enforcerTexture, controllerTexture, laserTexture;
        Rectangle mountinrect1, mountinrect2, sentinelrect1, sentinelrect2,sentinelrect3, enforcerrect1, controllerrect, laserrect;
        int enforcerHealth = 5;
        Texture2D Installation_05Texture;
        Rectangle Installation_05rect;
        Rectangle controllerPositions;
		// 2 boss
		bool boss2Fight = false, guardianActive = true, bossmovement = false, bossmovement2 = false, bossmovement3 = false, plasma1 = false, plasma2 = false, plasma3 = false, plasma4 = false;
		Texture2D guardianTexture;
		Rectangle guardianrect, guardianbackgroundrect, guardianbackgroundrect2, guardianbackgroundrect3;
		int guardianHealth = 100;
		SoundEffectInstance guardianTheme, cinematicRumble;
        Texture2D plasmaballTexture, EMPballTexture;
        bool boss2Phase2 = false, boss2Phase3 = false, boss2Phase4 = false, boss2Phase5 = false, boss2Phase6 = false, boss2Phase7 = false;
        Rectangle plasmaballrect, EMPballrect, EMPballrect2;
        float phase2Timer = 0, phase2Time = 20f, phase3Timer = 0, phase3Time = 20f, phase4Timer = 0, phase4Time = 20f;
        List<Vector2> bigplasmaPositions = new List<Vector2>();
        List<Vector2> bigplasmaVelocities = new List<Vector2>();

		List<Vector2> bigplasmaPositions2 = new List<Vector2>();
		List<Vector2> bigplasmaVelocities2 = new List<Vector2>();
		
        List<Vector2> bigplasmaPositions3 = new List<Vector2>();
		List<Vector2> bigplasmaVelocities3 = new List<Vector2>();

		List<Vector2> bigplasmaPositions4 = new List<Vector2>();
		List<Vector2> bigplasmaVelocities4 = new List<Vector2>();

		Rectangle bigplasmarect;
		Rectangle bigplasmarect2;
		Rectangle bigplasmarect3;

		private float bigplasmaTimer = 0;
        private float bigplasmaTime = 0.2f;

		private float bigplasmaTimer2 = 0;
		private float bigplasmaTime2 = 0.2f;

		private float bigplasmaTimer3 = 0;
		private float bigplasmaTime3 = 0.2f;

		private float bigplasmaTimer4 = 0;
		private float bigplasmaTime4 = 0.2f;

		Texture2D laserbeamTexture;
        Rectangle laserbeamrect;
        private float beamTimer2 = 0;
        private float beamTime2 = 5f;

        private float plasmaDirectionsTimer = 0;
        private float plasmaDirectionsTime = 3f;

		private float plasmaDirectionsTimer2 = 0;
		private float plasmaDirectionsTime2 = 3f;
		bool plasmaDirectionsSwitches = false;

        SoundEffectInstance missileFire, missileHit;
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
        Texture2D floodbomberTexture, floodedphantomTexture, floodsporeTexture, floodCloudTexture;
        Rectangle floodedphantomrect, floodbomberrect, floodsporerect, floodCloudrect;
        List<Rectangle> floodSpore;
        Vector2 floodFallSpeed;
		float timer = 0,levelTwoTimer = 0, bulletSpeed = 10f, interval = 0.2f, plasmaSpeed = -15f, missileSpeed = 10f, levelThreeTimer = 0;
        SoundEffectInstance haloTheme, haloflyingtheme, peilcanSound, radio1, bulletfire, brothersInArms,blowMeAway, moonOverMombasa, floodDeath;
        SoundEffectInstance beholdAPaleHorseTheme;
        int lifes = 3, phantomHealth = 3, bossShipHealth = 30, floodedphantomHealth = 3;

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

            HTPButtonrect = new Rectangle(0,0, 70, 70);

            HTPButton2rect = new Rectangle(0, 0, 70, 70);

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

			sentinelrect2 = new Rectangle(1200, 400, 50, 50);

            sentinelrect3 = new Rectangle(1300, 350, 50, 50);

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

            guardianbackgroundrect = new Rectangle(350, -100, 80, 100);

			guardianbackgroundrect2 = new Rectangle(350, -100, 80, 100);

			guardianbackgroundrect3 = new Rectangle(350, -100, 80, 100);

			laserbeamrect = new Rectangle(-1000, -1111, 100, 1000);

            EMPballrect = new Rectangle(100, -300, 200, 200);

            EMPballrect2 = new Rectangle(100, -300, 200, 200);

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

            gameOverScreenTexture = Content.Load<Texture2D>("GAME OVER");

			covenant_shipTexture = Content.Load<Texture2D>("covenant_ship");

            HTPButtonTexture = Content.Load<Texture2D>("newHTP");

            HTPButton2Texture = Content.Load<Texture2D>("newHTP2 - Copy");

            HTPScreenTexture = Content.Load<Texture2D>("infor");

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

            laserbeamTexture = Content.Load<Texture2D>("laserbeam");

            banshee_death = Content.Load<SoundEffect>("banshee_explo1").CreateInstance();

            banshee_death2 = Content.Load<SoundEffect>("banshee_explo1").CreateInstance();

            banshee_death3 = Content.Load<SoundEffect>("banshee_explo1").CreateInstance();

            banshee_death4 = Content.Load<SoundEffect>("banshee_explo1").CreateInstance();

            banshee_death5 = Content.Load<SoundEffect>("banshee_explo1").CreateInstance();

            plasmaExplosionTexture = Content.Load<Texture2D>("plasmaExplosion");

            cinematicRumble = Content.Load<SoundEffect>("earth-rumble").CreateInstance();
            
            missileFire = Content.Load<SoundEffect>("missile-blast").CreateInstance();

            missileHit = Content.Load<SoundEffect>("missile-explosion").CreateInstance();

            phantomDamage = Content.Load<SoundEffect>("impact").CreateInstance();

            phantomDestroyed = Content.Load<SoundEffect>("phantom_destroyed").CreateInstance();

            buttonUI = Content.Load<SoundEffect>("buttonUI").CreateInstance();

			floodDeath = Content.Load<SoundEffect>("flood_bodyfall_combatform1").CreateInstance();

            floodCloudTexture = Content.Load<Texture2D>("floodCloud");

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
			bigplasmaTimer2 += (float)gameTime.ElapsedGameTime.TotalSeconds;
			bigplasmaTimer3 += (float)gameTime.ElapsedGameTime.TotalSeconds;
			missileTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            beamTimer2 += (float)gameTime.ElapsedGameTime.TotalSeconds;


            KeyboardState keyboardState = Keyboard.GetState();

            
            if (playerLife == true)
            {
              playerLifeTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
              if (playerLifeTimer >= playerLifeTime)
              {
               playerLifeTimer = 0;
               playerLife = false;
                    peilcanrect.X = 0; 
                    peilcanrect.Y = 300;
              }
			}

            if (buttonrect.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && screen == Screen.MainMenu)
            {
                buttonUI.Play();
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
                if (HTPButtonrect.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && screen == Screen.MainMenu)
                {
                    buttonUI.Play();
                    screen = Screen.HowToPlayScreen;

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
            if (screen == Screen.HowToPlayScreen)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                {
                    screen = Screen.MainMenu;
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
                    isExploding = true;
                    
                    bulletPositions.RemoveAt(i);
                    bulletVelocities.RemoveAt(i);
                    banshee_death.Play();
                    continue;
                    
                }

                if (bansheerect2.Contains(pos))
                {
					isExploding2 = true;
                    
					bulletPositions.RemoveAt(i);
                    bulletVelocities.RemoveAt(i);
                    banshee_death2.Play();
                    continue;
                }

                if (phantomrect.Contains(pos))
                {
                    phantomHealth--;
                    phantomDamage.Play();
                    
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
                    isExploding7 = true;
                    bulletPositions.RemoveAt(i);
                    bulletVelocities.RemoveAt(i);
                    continue;
                }
                if (sentinelrect2.Contains(pos) && (screen == Screen.Level2))
                {
                    isExploding8 = true;
                    bulletPositions.RemoveAt(i);
                    bulletVelocities.RemoveAt(i);
                    continue;
                }
				if (sentinelrect3.Contains(pos) && (screen == Screen.Level2))
				{
					isExploding9 = true;
					bulletPositions.RemoveAt(i);
					bulletVelocities.RemoveAt(i);
					continue;
				}
				if (bansheerect3.Contains(pos))
				{
                    isExploding3 = true;
					
					bulletPositions.RemoveAt(i);
					bulletVelocities.RemoveAt(i);
                    banshee_death3.Play();
                    continue;
				}
				if (bansheerect4.Contains(pos))
				{
                    isExploding4 = true;
					
					bulletPositions.RemoveAt(i);
					bulletVelocities.RemoveAt(i);
                    banshee_death4.Play();
                    continue;
				}
				if (bansheerect5.Contains(pos))
				{
                    isExploding5 = true;
					
					bulletPositions.RemoveAt(i);
					bulletVelocities.RemoveAt(i);
                    banshee_death5.Play();
                    continue;
				}
				if (floodbomberrect.Contains(pos))
				{
					isExploding10 = true;
					bulletPositions.RemoveAt(i);
					bulletVelocities.RemoveAt(i);
                    floodDeath.Play();
					continue;
				}
				if (floodedphantomrect.Contains(pos))
				{
					isExploding11 = true;
					bulletPositions.RemoveAt(i);
					bulletVelocities.RemoveAt(i);
					floodDeath.Play();
					continue;
				}
			}

            if (keyboardState.IsKeyDown(Keys.M) && missileTimer >= missileTime)
            {

                missilePositions.Add(peilcanrect.Location.ToVector2() + new Vector2(peilcanrect.Width, peilcanrect.Height / 2 - missilerect.Height / 2));
                missileVelocities.Add(new Vector2(missileSpeed, 0));
                missileFire.Play();
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
                    isExploding = true;
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    banshee_death.Play();
                    missileHit.Play();
                    continue;
                }
                if (bansheerect2.Contains(pos))
                {
                    isExploding2 = true;
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    banshee_death2.Play();
                    missileHit.Play();
                    continue;
                }
                if (phantomrect.Contains(pos))
                {
                    phantomHealth -= 2;
                    missileHit.Play();
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    missileHit.Play();
                    continue;
                }

                if (!energyShieldOff && energyShield1rect.Contains(pos))
                {
                    energyShieldHealth -= 2;
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    missileHit.Play();
                    continue;
                }
                if (core1rect.Contains(pos))
                {
                    coreHealth--;
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    missileHit.Play();
                    continue;
                }
                if (core2rect.Contains(pos))
                {
                    coreHealth--;
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    missileHit.Play();
                    continue;
                }
                if (core3rect.Contains(pos))
                {
                    coreHealth--;
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    missileHit.Play();
                    continue;
                }
                if (sentinelrect1.Contains(pos) && screen == Screen.Level2)
                {
                    isExploding7 = true;
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    missileHit.Play();
                    continue;
                }
                if (sentinelrect2.Contains(pos) && screen == Screen.Level2)
                {
                    isExploding8 = true;
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    missileHit.Play();
                    continue;
                }
				if (sentinelrect3.Contains(pos) && screen == Screen.Level2)
				{
					isExploding9 = true;
					missilePositions.RemoveAt(k);
					missileVelocities.RemoveAt(k);
					missileHit.Play();
					continue;
				}
				if (enforcerrect1.Contains(pos) && screen == Screen.Level2)
                {
                    enforcerHealth -= 2;
                    missilePositions.RemoveAt(k);
                    missileVelocities.RemoveAt(k);
                    missileHit.Play();
                    continue;
                }
                if (bansheerect3.Contains(pos))
				{
					isExploding3 = true;
					missilePositions.RemoveAt(k);
					missileVelocities.RemoveAt(k);
                    missileHit.Play();
                    banshee_death3.Play();
					continue;
				}
				if (bansheerect4.Contains(pos))
				{
					isExploding4 = true;
					missilePositions.RemoveAt(k);
					missileVelocities.RemoveAt(k);
                    missileHit.Play();
                    banshee_death4.Play();
                    continue;
				}
				if (bansheerect5.Contains(pos))
				{
					isExploding5 = true;
					missilePositions.RemoveAt(k);
					missileVelocities.RemoveAt(k);
                    missileHit.Play();
                    banshee_death5.Play();
					continue;
				}
                if (floodbomberrect.Contains(pos))
                {
                    isExploding10 = true;
					missilePositions.RemoveAt(k);
					missileVelocities.RemoveAt(k);
                    missileHit.Play();
					floodDeath.Play();
					continue;
				}
				if (floodedphantomrect.Contains(pos))
				{
					isExploding11 = true;
                    
					missilePositions.RemoveAt(k);
					missileVelocities.RemoveAt(k);
                    missileHit.Play();
					floodDeath.Play();
					continue;
				}
			}
            if (isExploding == true)
            {

                explosionTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
               
                if (explosionTimer >= explosionTime)
                {
                    explosionTimer = 0;
                    bansheerect = new Rectangle(850, new Random().Next(0, 450), 60, 40);
                    isExploding = false;
                    banshee_death.Stop();
				}
            }
            if (isExploding2 == true) 
            {
				
				explosionTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
				if (explosionTimer >= explosionTime)
				{
					explosionTimer = 0;
					bansheerect2 = new Rectangle(850, new Random().Next(0, 450), 60, 40);
					isExploding2 = false;
                    banshee_death2.Stop();
				}


			}
			if (isExploding3 == true)
			{
				
				explosionTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
				if (explosionTimer >= explosionTime)
				{
					explosionTimer = 0;
					bansheerect3 = new Rectangle(850, new Random().Next(0, 450), 60, 40);
					isExploding3 = false;
                    banshee_death3.Stop();
				}


			}
			if (isExploding4 == true)
			{

				explosionTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
				if (explosionTimer >= explosionTime)
				{
					explosionTimer = 0;
					bansheerect4 = new Rectangle(850, new Random().Next(0, 450), 60, 40);
					isExploding4 = false;
                    banshee_death4.Stop();
				}


			}
			if (isExploding5 == true)
			{

				explosionTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
				if (explosionTimer >= explosionTime)
				{
					explosionTimer = 0;
					bansheerect5 = new Rectangle(850, new Random().Next(0, 450), 60, 40);
					isExploding5 = false;
                    banshee_death5.Stop();
				}


			}
            if (phantomHealth == 0)
            {
                isExploding6 = true;
                phantomDestroyed.Play();
            }
            if (isExploding6 == true)
            {
                
                explosionTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (explosionTimer >= explosionTime)
                {
                    explosionTimer = 0;
                    phantomrect.X = new Random().Next(1000, 1500);
                    phantomrect.Y = new Random().Next(0, 450);
                    isExploding6 = false;
                    phantomDestroyed.Stop();
                    phantomHealth = 3;
                }
            }
			if (isExploding7 == true)
			{

				explosionTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
				if (explosionTimer >= explosionTime)
				{
					explosionTimer = 0;
                    sentinelrect1.X = 850;
					sentinelrect1.Y = new Random().Next(0, 450);
					isExploding7 = false;
					banshee_death5.Stop();
				}


			}
			if (isExploding8 == true)
			{

				explosionTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
				if (explosionTimer >= explosionTime)
				{
					explosionTimer = 0;
					sentinelrect2.X = 850;
					sentinelrect2.Y = new Random().Next(0, 450);
					isExploding8 = false;
					banshee_death5.Stop();
				}


			}
			if (isExploding9 == true)
			{

				explosionTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
				if (explosionTimer >= explosionTime)
				{
					explosionTimer = 0;
					sentinelrect3.X = 850;
					sentinelrect3.Y = new Random().Next(0, 450);
					isExploding9 = false;
					banshee_death5.Stop();
				}


			}
            if (isExploding10 == true)
            {
				explosionTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
				if (explosionTimer >= explosionTime)
				{
					explosionTimer = 0;
					floodbomberrect.X = 850;
					floodbomberrect.Y = new Random().Next(0, 450);
					isExploding10 = false;
					floodDeath.Stop();
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
                    
                    if (playerLife == false)
                    {
						if (peilcanrect.Contains(pos))
						{
							lifes--;
							playerLife = true;
							plasmaPositions.RemoveAt(j);
							plasmaVelocities.RemoveAt(j);
							continue;
						}
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
                    if (playerLife == false)
                    {
						if (peilcanrect.Contains(pos))
						{
							lifes--;

							playerLife = true;
							plasmaPositions2.RemoveAt(j);
							plasmaVelocities2.RemoveAt(j);
							continue;
						}
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
                    missileHit.Play();

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

                        if (timer >= 7)
                        {
                            moonOverMombasa.Stop();
                            screen = Screen.Level1;
                            lifes = 3;
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
                if (playerLife == false)
                {
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
				}
                

                cityrect.X -= 2;
                cityrect2.X -= 2;
                build1rect.X -= 1;
                covenantshiprect.X -= 1;
                if (isExploding6 == false)
                {
                    phantomrect.X -= 3;
                }
                
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
                if (playerLife == false)
                {
					if (peilcanrect.Intersects(bansheerect))
					{
						lifes--;
						playerLife = true;
						
                        isExploding = true;
					}
					if (peilcanrect.Intersects(phantomrect))
					{
						lifes--;
						playerLife = true;
                        isExploding6 = true;
						
                        

					}
					if (peilcanrect.Intersects(bansheerect2))
					{
						lifes--;
                        playerLife = true;
						
                        isExploding2 = true;
					}
				}
                
                if (unscshiprect.X <= -250)
                {
                    unscshiprect.X = new Random().Next(1000, 3000);
                    unscshiprect.Y = new Random().Next(0, 200);
                }
                if (peilcanrect.X <= 0)
                {
                    peilcanrect.X = 0;
                }
                else if (peilcanrect.X >= 700)
                {
                    peilcanrect.X = 700;
                }
                if (peilcanrect.Y <= 0)
                {
                    peilcanrect.Y = 0;
                }
                else if (peilcanrect.Y >= 450)
                {
                    peilcanrect.Y = 450;
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
                
                if (timer >= 0)
                {
                    weaponsOn = true;
                    if (isExploding == false)
                    {
                        bansheerect.X -= 3;
                    }
                    


                }


                if (timer >= 30)
                {
                    if (isExploding == false)
                    {
                        bansheerect.X -= 4;
                    }
                    if (isExploding2 == false)
                    {
                        bansheerect2.X -= 4;
                    }
                    



                }
                if (timer >= 60)
                {

                    if (isExploding == false)
                    {
                        bansheerect.X -= 5;
                    }
                    if (isExploding2 == false)
                    {
                        bansheerect2.X -= 5;
                    }
                    

                }
                if (timer >= 110)
                {
                    if (isExploding == false)
                    {
                        bansheerect.X -= 6;
                    }
                    if (isExploding2 == false)
                    {
                        bansheerect2.X -= 6;
                    }

                    
                }
                if (timer >= 120)
                {

					if (isExploding == false)
					{
						bansheerect.X -= 7;
					}
				}
                if (timer >= 125)
                {

					if (isExploding2 == false)
					{
						bansheerect2.X -= 7;
					}

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
                

                if (shakeTime > 0)
                {
                    shakeTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                }


				if (playerLife == false)
				{
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
				}
				if (mountinrect1.X <= -1000)
                {
                    mountinrect1.X = 1000;
                }
                if (mountinrect2.X <= -1000)
                {
                    mountinrect2.X = 1000;
                }
				if (peilcanrect.X <= 0)
				{
					peilcanrect.X = 0;
				}
				else if (peilcanrect.X >= 700)
				{
					peilcanrect.X = 700;
				}
				if (peilcanrect.Y <= 0)
				{
					peilcanrect.Y = 0;
				}
				else if (peilcanrect.Y >= 450)
				{
					peilcanrect.Y = 450;
				}
				if (lifes <= 0)
				{
					screen = Screen.GameOver;
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
                if (playerLife == false)
                {
					if (peilcanrect.Intersects(sentinelrect1))
					{
						lifes--;
						playerLife = true;
						isExploding7 = true;
					}
					if (peilcanrect.Intersects(sentinelrect2))
					{
						lifes--;
						playerLife = true;
						isExploding8 = true;
					}
                    if (peilcanrect.Intersects(sentinelrect3))
                    {
						lifes--;
						playerLife = true;
						isExploding9 = true;
					}
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


				if (isExploding7 == false)
				{
					sentinelrect1.X -= 3;
				}
				if (levelTwoTimer >= 2)
                {
                    weaponsOn = true;
					if (isExploding7 == false)
					{
						sentinelrect1.X -= 4;
					}
					if (isExploding8 == false)
                    { 
                      sentinelrect2.X -= 3; 
                    }
				     
                }
                if (levelTwoTimer >= 8)
                {
					if (isExploding7 == false)
					{
						sentinelrect1.X -= 5;
						sentinelrect1.Y += (int)(float)(Math.Sin(levelTwoTimer) * 2);
					}
					if (isExploding8 == false)
					{
						sentinelrect2.X -= 4;
						sentinelrect2.Y += (int)(float)(Math.Sin(levelTwoTimer) * 3);
					}
					
                    
                    
                }
                if (levelTwoTimer >= 20)
                {
                    enforcerrect1.X -= 2;
                    plasmaTimer2 += (float)gameTime.ElapsedGameTime.TotalSeconds;

                }
                if (levelTwoTimer >= 30)
                {

					if (isExploding9 == false)
					{
						sentinelrect3.X -= 5;
						sentinelrect3.Y += (int)(float)(Math.Sin(levelTwoTimer) * 4);
					}
					
                }
                if (levelTwoTimer >= 40)
                {
                    controllerrect.X -= 2;

                }
                if (levelTwoTimer >= 75)
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
                    cinematicRumble.Play();
                    shakeTime = 0.5f; // Shakes for half a second




                }
          
                if (levelTwoTimer >= 80)
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
                    cinematicRumble.Stop();


                    if (guardianHealth == 100)
                    {
                        plasma1 = true;

                        if (plasma1 == true)
                        {
							EMPballrect.Y = -200;
							if (bigplasmaTimer >= bigplasmaTime)
							{
								//(guardianrect.Location.ToVector2() + new Vector2(guardianrect.Width - 360, guardianrect.Height - 1050)

								bigplasmaPositions.Add((guardianrect.Location.ToVector2() + new Vector2(guardianrect.Width - 360, guardianrect.Height - 1050)));

								bigplasmaVelocities.Add(new Vector2(0, -3));

								bigplasmaVelocities.Add(new Vector2(0, 3));

								bigplasmaVelocities.Add(new Vector2(3, 0));

								bigplasmaVelocities.Add(new Vector2(-3, 0));

								bigplasmaVelocities.Add(new Vector2(3, -3));

								bigplasmaVelocities.Add(new Vector2(-3, -3));

								bigplasmaVelocities.Add(new Vector2(-3, 3));

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
								
                                if (playerLife == false)
                                {
									if (peilcanrect.Contains(pos))
									{
										lifes--;

										playerLife = true;
										bigplasmaPositions.RemoveAt(j);
										bigplasmaVelocities.RemoveAt(j);
										continue;
									}
								}
                                

							}
						}
                        
                        guardianrect.X += (int)(float)(Math.Sin(levelTwoTimer) * 1.5);
                    }
                    else if (guardianHealth == 75)
                    {
                        plasma1 = false;

                        if (phase2Timer <= phase2Time)
                        {
                            bossmovement = true;
                        }

                        if (phase2Timer >= phase2Time)
                        {
                            bossmovement = false;
                        }
                        if (bossmovement == false)
                        {
                            if (boss2Phase3 == true)
                            {
                                cinematicRumble.Stop();
                                guardianrect.Y += 2;
                                shakeMagnitude = 5;
                                shakeTime = 0.5f;
                                plasma2 = true;
								EMPballrect.Y = -200;
								if (guardianrect.Y >= 50)
                                {
                                    guardianrect.Y = 50;
                                    guardianrect.Y -= 0;
                                    bigplasmaTime2 = 0.1f;
                                    if (plasma2 == true)
                                    {
										if (bigplasmaTimer2 >= bigplasmaTime2)
										{
											//(guardianrect.Location.ToVector2() + new Vector2(guardianrect.Width - 360, guardianrect.Height - 1050)

											bigplasmaPositions2.Add((guardianrect.Location.ToVector2() + new Vector2(guardianrect.Width - 360, guardianrect.Height - 1050)));

											bigplasmaVelocities2.Add(new Vector2(0, -4));

											bigplasmaVelocities2.Add(new Vector2(0, 4));

											bigplasmaVelocities2.Add(new Vector2(4, 0));

											bigplasmaVelocities2.Add(new Vector2(-4, 0));

											bigplasmaVelocities2.Add(new Vector2(4, -4));

											bigplasmaVelocities2.Add(new Vector2(-4, -4));

											bigplasmaVelocities2.Add(new Vector2(-4, 4));

											bigplasmaTimer2 = 0;
										}
										for (int j = bigplasmaPositions2.Count - 1; j >= 0; j--)
										{
											bigplasmaPositions2[j] += bigplasmaVelocities2[j];
											var pos = bigplasmaPositions2[j];
											if (bigplasmaPositions2[j].X < -330)
											{
												bigplasmaPositions2.RemoveAt(j);
												bigplasmaVelocities2.RemoveAt(j);
												continue;
											}
											if (playerLife == false)
											{
												if (peilcanrect.Contains(pos))
												{
													lifes--;

													playerLife = true;
													bigplasmaPositions.RemoveAt(j);
													bigplasmaVelocities.RemoveAt(j);
													continue;
												}
											}

										}
									}
                                    
                                    guardianrect.X += (int)(float)(Math.Sin(levelTwoTimer) * 2);
                                }

                            }

                        }

                    }
                    else if (guardianHealth == 50)
                    {
                        plasma2 = false;

                        if (phase3Timer <= phase3Time)
                        {
                            bossmovement2 = true;
                        }
                        if (phase3Timer >= phase3Time)
                        {
                            bossmovement2 = false;


                        }
                        if (bossmovement2 == false)
                        {
                            if (boss2Phase5 == true)
                            {
                                plasmaDirectionsTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                                guardianrect.Y += 2;
                                shakeMagnitude = 5;
                                shakeTime = 0.5f;
                                cinematicRumble.Play();
                                plasma3 = true;
								EMPballrect.Y = -200;
								if (guardianrect.Y >= 50)
                                {
                                    guardianrect.Y = 50;
                                    cinematicRumble.Stop();
                                    guardianrect.Y -= 0;
                                    bigplasmaTime3 = 0f;
                                    if (plasma3 == true)
                                    {
										if (bigplasmaTimer3 >= bigplasmaTime3)
										{
											//(guardianrect.Location.ToVector2() + new Vector2(guardianrect.Width - 360, guardianrect.Height - 1050)
											bigplasmaPositions3.Add((guardianrect.Location.ToVector2() + new Vector2(guardianrect.Width - 360, guardianrect.Height - 1050)));
											if (plasmaDirectionsTime >= plasmaDirectionsTimer)
											{

												if (plasmaDirectionsSwitches == false)
												{
													bigplasmaVelocities3.Add(new Vector2(0, -5));
													bigplasmaVelocities3.Add(new Vector2(0, 5));
													bigplasmaVelocities3.Add(new Vector2(5, 0));
													bigplasmaVelocities3.Add(new Vector2(-5, 0));

												}

											}
											if (plasmaDirectionsTimer >= plasmaDirectionsTime2)
											{
												plasmaDirectionsSwitches = true;
												if (plasmaDirectionsSwitches == true)
												{
													bigplasmaVelocities3.Add(new Vector2(-5, -5));
													bigplasmaVelocities3.Add(new Vector2(5, 5));
													bigplasmaVelocities3.Add(new Vector2(5, -5));
													bigplasmaVelocities3.Add(new Vector2(-5, 5));
												}


											}
											if (plasmaDirectionsTimer >= 6)
											{
												plasmaDirectionsTimer = 0;
												plasmaDirectionsSwitches = false;
											}


											bigplasmaTimer3 = 0;
										}
										for (int j = bigplasmaPositions3.Count - 1; j >= 0; j--)
										{
											bigplasmaPositions3[j] += bigplasmaVelocities3[j];
											var pos = bigplasmaPositions3[j];
											if (bigplasmaPositions3[j].X < -330)
											{
												bigplasmaPositions3.RemoveAt(j);
												bigplasmaVelocities3.RemoveAt(j);
												continue;
											}
											if (playerLife == false)
											{
												if (peilcanrect.Contains(pos))
												{
													lifes--;

													playerLife = true;
													bigplasmaPositions.RemoveAt(j);
													bigplasmaVelocities.RemoveAt(j);
													continue;
												}
											}
										}
									}
                                    
                                }
                                guardianrect.X += (int)(float)(Math.Sin(levelTwoTimer) * 3);
                            }
                        }
                    }
                    else if (guardianHealth == 25)
                    {
                        plasma3 = false;
                        if (phase4Timer <= phase4Time)
                        {
                            bossmovement3 = true;
                        }
                        if (phase4Timer >= phase4Time)
                        {
                            bossmovement3 = false;


                        }
                        if (bossmovement3 == false)
                        {
                            if (boss2Phase7 == true)
                            {
                                plasmaDirectionsTimer2 += (float)gameTime.ElapsedGameTime.TotalSeconds;
                                guardianrect.Y += 2;
                                shakeMagnitude = 5;
                                shakeTime = 0.5f;
                                cinematicRumble.Play();
                                boss2Phase5 = false;
                                plasma4 = true;
								EMPballrect.Y = -200;
								if (guardianrect.Y >= 50)
                                {
                                    guardianrect.Y = 50;
                                    cinematicRumble.Stop();
                                    guardianrect.Y -= 0;
                                    bigplasmaTime4 = 0f;
                                    if (plasma4 == true)
                                    {
										if (bigplasmaTimer4 >= bigplasmaTime4)
										{

											bigplasmaPositions4.Add(guardianrect.Location.ToVector2() + new Vector2(guardianrect.Width - 360, guardianrect.Height - 1050));

											bigplasmaVelocities4.Add(new Vector2(5, 0));
											if (plasmaDirectionsTimer2 >= 1)
											{
												bigplasmaVelocities4.Add(new Vector2(-5, 0));
											}
											if (plasmaDirectionsTimer2 >= 2)
											{
												bigplasmaVelocities4.Add(new Vector2(-5, 5));
											}
											if (plasmaDirectionsTimer2 >= 3)
											{
												bigplasmaVelocities4.Add(new Vector2(-5, -5));
											}
											if (plasmaDirectionsTimer2 >= 4)
											{
												bigplasmaVelocities4.Add(new Vector2(0, -5));
											}
											if (plasmaDirectionsTimer2 >= 5)
											{
												bigplasmaVelocities4.Add(new Vector2(5, 5));
											}
											if (plasmaDirectionsTimer2 >= 6)
											{
												bigplasmaVelocities4.Add(new Vector2(5, -5));
											}
                                            if (plasmaDirectionsTime2 >= 7)
                                            {
												bigplasmaVelocities4.Add(new Vector2(0, 5));
											}
                                            if (plasmaDirectionsTime2 >= 8)
                                            {
												bigplasmaVelocities4.Add(new Vector2(0, -5));
											}
											if (plasmaDirectionsTimer2 >= 9)
											{
												plasmaDirectionsTimer2 = 0;

											}


											bigplasmaTimer4 = 0;
										}
										for (int j = bigplasmaPositions4.Count - 1; j >= 0; j--)
										{
											bigplasmaPositions4[j] += bigplasmaVelocities4[j];
											var pos = bigplasmaPositions4[j];
											if (bigplasmaPositions4[j].X < -330)
											{
												bigplasmaPositions4.RemoveAt(j);
												bigplasmaVelocities4.RemoveAt(j);
												continue;
											}
											if (playerLife == false)
											{
												if (peilcanrect.Contains(pos))
												{
													lifes--;

													playerLife = true;
													bigplasmaPositions.RemoveAt(j);
													bigplasmaVelocities.RemoveAt(j);
													continue;
												}
											}
										}
										guardianrect.X += (int)(float)(Math.Sin(levelTwoTimer) * 3);
									}
                                    
                                }
                            }
                        }
                    }

                    else if (guardianHealth == 0)
                    {
                        guardianrect.Y += 1;

                        if (guardianrect.Y >= 600)
                        {
                            guardianrect.X = 1200;

                            levelTwoTimer = 0;
                            screen = Screen.level3Intro;
                            shakeMagnitude = 0;
                            shakeTime = 0;
                        }
                    }




                            guardianActive = false;
                            if (boss2Phase2 == true)
                            {

                                phase2Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;



                                guardianbackgroundrect.Y += 1;
                                if (guardianbackgroundrect.Y >= 100)
                                {

                                    guardianbackgroundrect.Y = 100;
                                    guardianbackgroundrect.Y += 0;
                                    cinematicRumble.Stop();

                                }
                                if (guardianbackgroundrect.Y >= 100)
                                {
                                    EMPballrect.Y += 5;
                                    if (EMPballrect.Y >= 600)
                                    {
                                        EMPballrect.X = generator.Next(0, 600);
                                        EMPballrect.Y = -200;

                                    }
                                }


                            }
                            if (bossmovement == true)
                            {
                                guardianrect.Y -= 2;
                                shakeMagnitude = 5;
                                shakeTime = 0.5f;
                                cinematicRumble.Play();
                                if (guardianrect.Y <= -1300)
                                {
                                    guardianrect.Y = -1300;
                                    guardianrect.X = 0;
                                    guardianrect.Y -= 0;
                                    boss2Phase2 = true;


                                }
                            }


                            if (bossmovement2 == true)
                            {
                                guardianrect.Y -= 2;
                                shakeMagnitude = 5;
                                shakeTime = 0.5f;
                                cinematicRumble.Play();
                                if (guardianrect.Y <= -1300)
                                {
                                    guardianrect.Y = -1300;
                                    guardianrect.X = 0;
                                    guardianrect.Y -= 0;
                                    

                                    boss2Phase4 = true;


                                }
                            }
						if (bossmovement3 == true)
						{
							guardianrect.Y -= 2;
							shakeMagnitude = 20;
							shakeTime = 0.5f;
							cinematicRumble.Play();
							if (guardianrect.Y <= -1300)
							{
								guardianrect.Y = -1300;
								guardianrect.X = 0;
								guardianrect.Y -= 0;

								boss2Phase6 = true;


							}
						}
						if (boss2Phase4 == true)
                        {
                                guardianbackgroundrect2.Y += 1;
                                phase3Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                                if (guardianbackgroundrect2.Y >= 100)
                                {

                                    guardianbackgroundrect2.Y = 100;
                                    guardianbackgroundrect2.Y += 0;

                                }
                                if (guardianbackgroundrect2.Y >= 100)
                                {
                                    cinematicRumble.Stop();
                                    EMPballrect.Y += 10;
                                    if (EMPballrect.Y >= 600)
                                    {
                                        EMPballrect.X = generator.Next(0, 600);
                                        EMPballrect.Y = -200;

                                    }
                                }
                        }
						if (boss2Phase6 == true)
						{
							guardianbackgroundrect3.Y += 1;
							phase4Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

							if (guardianbackgroundrect3.Y >= 100)
							{

								guardianbackgroundrect3.Y = 100;
								guardianbackgroundrect3.Y += 0;

							}
							if (guardianbackgroundrect3.Y >= 100)
							{
								cinematicRumble.Stop();
								EMPballrect.Y += 10;
								if (EMPballrect.Y >= 600)
								{
									EMPballrect.X = generator.Next(0, 600);
									EMPballrect.Y = -200;

								}
							}
						}







                        if (playerLife == false)
                        {
						  if (EMPballrect.Intersects(peilcanrect))
						  {
							lifes--;
							playerLife = true;
							EMPballrect.X = generator.Next(0, 600);
							EMPballrect.Y = -200;
						  }
					    }
						
                            if (phase2Timer >= phase2Time)
                            {
                                boss2Phase2 = false;
                                guardianbackgroundrect.Y -= 2;
                            }
                            if (guardianbackgroundrect.Y <= -500)
                            {
                                guardianbackgroundrect.Y = -500;

                                boss2Phase3 = true;
                                boss2Phase2 = false;

                            }
                            if (phase3Timer >= phase3Time)
                            {
                                boss2Phase4 = false;
                                guardianbackgroundrect2.Y -= 2;



                            }
                            if (guardianbackgroundrect2.Y <= -500)
                            {
                                guardianbackgroundrect2.Y = -500;

                                boss2Phase5 = true;


                            }
						if (phase4Timer >= phase4Time)
						{
							  boss2Phase6 = false;
							  guardianbackgroundrect3.Y -= 3;

							if (guardianbackgroundrect3.Y <= -500)
							{
								guardianbackgroundrect3.Y = -500;

								
                                boss2Phase7 = true;

							}

						}


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

				  if (playerLife == false)
				  {
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
				  }
				  if (peilcanrect.X <= 0)
				  {
					peilcanrect.X = 0;
				  }
				  else if (peilcanrect.X >= 700)
				  {
					peilcanrect.X = 700;
				  }
				  if (peilcanrect.Y <= 0)
				  {
					peilcanrect.Y = 0;
				  }
				  else if (peilcanrect.Y >= 450)
				  {
					peilcanrect.Y = 450;
				  }
				  if (lifes <= 0)
				  {
					screen = Screen.GameOver;
				  }
				    if (bansheerect3.X <= -50)
                    {
                        bansheerect3.X = 850;
                        bansheerect3.Y = new Random().Next(0, 450);
                        banshee_death3.Stop();
                    }
                    if (bansheerect4.X <= -50)
                    {
                        bansheerect4.X = 850;
                        bansheerect4.Y = new Random().Next(0, 450);
                        banshee_death4.Stop();
                    }
                    if (bansheerect5.X <= -50)
                    {
                        bansheerect5.X = 850;
                        bansheerect5.Y = new Random().Next(0, 450);
                        banshee_death5.Stop();
                    }
                    if (playerLife == false)
                    {
					  if (peilcanrect.Intersects(bansheerect5))
					  {
						lifes--;

						isExploding5 = true;
					  }
					  if (peilcanrect.Intersects(bansheerect4))
					  {
						lifes--;

						isExploding4 = true;
					  }
					  if (peilcanrect.Intersects(bansheerect3))
					  {
						lifes--;

						isExploding3 = true;
					  }
					  if (peilcanrect.Intersects(floodbomberrect))
					  {
                        lifes--;
                        isExploding11 = true;
					  }
				    }
                    
                    if (levelThreeTimer >= 0)
                    {
                        weaponsOn = true;
                        if (isExploding3 ==  false)
                        {
						  bansheerect3.X -= 3;
					    }
                        
                    }
                    if (levelThreeTimer >= 10)
                    {
                      if (isExploding3 == false)
                      {
                        bansheerect3.X -= 4;
                      }
                       if (isExploding4 == false)
                       { 
                         bansheerect4.X -= 4;
                       }
                    }
                    if (levelThreeTimer >= 20)
                    {
					  if (isExploding3 == false)
					  {
						bansheerect3.X -= 5;
					  }
					  if (isExploding4 == false)
					  {
						bansheerect4.X -= 5;
					  }
					  if (isExploding5 == false) 
                      {
						bansheerect5.X -= 5;
					  }
                        
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
                        if (isExploding10 == false)
                        {
						  floodbomberrect.X -= 3;
						  floodbomberrect.Y += (int)(float)(Math.Sin(levelThreeTimer) * 2);
					    }
                        
                        floodSporeActive = true;
                    }
                    if (levelThreeTimer >= 145)
                    {

					  if (isExploding10 == false)
					  {
						floodbomberrect.X -= 5;
						floodbomberrect.Y += (int)(float)(Math.Sin(levelThreeTimer) * 2);
					  }
					
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
                        bossFight = false;

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

                        bossShipHealth = 30;
                        bossShiprect.X = 950;
                        bossShiprect.Y = 200;
                        energyShield1rect.Y = -400;
					    timer = 0;
                        levelTwoTimer = 0;
                        levelThreeTimer = 0;
                        moonOverMombasa.Stop();
                        peilcanSound.Stop();
                        haloflyingtheme.Stop();
                        haloTheme.Stop();
                        Charitys_IronyTheme.Stop();
                        beholdAPaleHorseTheme.Stop();
                        guardianTheme.Stop();

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
                _spriteBatch.Draw(HTPButtonTexture,HTPButtonrect, Color.White);
                if (HTPButtonrect.Contains(mouse.X, mouse.Y))
                {
                    _spriteBatch.Draw(HTPButton2Texture, HTPButton2rect, Color.White);
                }

            }
            if (screen == Screen.HowToPlayScreen)
            {
                _spriteBatch.Draw(HTPScreenTexture, window, Color.White);
                _spriteBatch.DrawString(font, "Press E to exit", new Vector2(310, 470), Color.White);
            }
            if (screen == Screen.intro)
            {
                _spriteBatch.DrawString(font, "In the year 2552, humanity is at war with an alien alliance known as the Covenant. The Covenant is a theocratic military alliance of multiple alien species that have united under a common religious belief in the Great Journey, which they believe will lead them to salvation. The Covenant has been waging a genocidal campaign against humanity for decades, and the United Earth Government (UEG) has been struggling to defend itself against the superior technology and firepower of the Covenant.", new Vector2(10, 10) , Color.White);
            }
            if (screen == Screen.GameOver)
            {
                _spriteBatch.Draw(gameOverScreenTexture, window, Color.White);
                
                _spriteBatch.DrawString(font, "Press Enter to Return to Main Menu", new Vector2(220, 350), Color.White);
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
					_spriteBatch.Draw(plasmaExplosionTexture, bansheerect, Color.White);

					_spriteBatch.Draw(explosionTexture, peilcanrect2, Color.White);
					_spriteBatch.Draw(plasmaExplosionTexture, bansheerect2, Color.White);
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
                    _spriteBatch.DrawString(font, "After narrowly escaping with your life, you have been rerouted to the ", new Vector2(30, 400), Color.White);
                    _spriteBatch.DrawString(font, "Amber clad to hunt the Prophet of Regret on the ring.", new Vector2(30, 450), Color.White);
                }
                else if (randomText == 2)
                {
                    _spriteBatch.DrawString(font, "Civilians successfully evacuated, now board the Amber clad And follow ", new Vector2(20, 400), Color.White);
					_spriteBatch.DrawString(font, "the Prophet of Regret.", new Vector2(20, 450), Color.White);
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

				if (isExploding == true)
				{
					_spriteBatch.Draw(plasmaExplosionTexture, bansheerect, Color.White);

				}
				if (isExploding2 == true)
				{
					_spriteBatch.Draw(plasmaExplosionTexture, bansheerect2, Color.White);

				}
				if (isExploding3 == true)
				{
					_spriteBatch.Draw(plasmaExplosionTexture, bansheerect3, Color.White);

				}
                if (isExploding6 == true)
                {
                    _spriteBatch.Draw(plasmaExplosionTexture, phantomrect, Color.White);
                }
				
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
                if (playerLife == true)
                {
                  _spriteBatch.Draw(explosionTexture, peilcanrect, Color.White);
				}



            }
            if (screen == Screen.Level2)
			{
			  
			  _spriteBatch.Draw(ringSkyTexture, ringSkyrect, Color.White);
              _spriteBatch.Draw(ring2Texture, ring2rect, Color.White);
			  _spriteBatch.Draw(guardianTexture, guardianbackgroundrect, Color.White);
              _spriteBatch.Draw(guardianTexture, guardianbackgroundrect2, Color.White);
			  _spriteBatch.Draw(guardianTexture, guardianbackgroundrect3, Color.White);






				_spriteBatch.Draw(mountinTexture, mountinrect1, Color.White);
              _spriteBatch.Draw(mountinTexture, mountinrect2, Color.White);
				
				
			  _spriteBatch.Draw(sentinelTexture, sentinelrect1, Color.White);
              _spriteBatch.Draw(sentinelTexture, sentinelrect2, Color.White);
				_spriteBatch.Draw(sentinelTexture, sentinelrect3, Color.White);
				_spriteBatch.Draw(enforcerTexture, enforcerrect1, Color.White);
              _spriteBatch.Draw(controllerTexture, controllerrect, Color.White);
              _spriteBatch.Draw(guardianTexture, guardianrect, Color.White);
				if (isExploding7 == true)
				{
					_spriteBatch.Draw(plasmaExplosionTexture, sentinelrect1, Color.White);

				}
				if (isExploding8 == true)
				{
					_spriteBatch.Draw(plasmaExplosionTexture, sentinelrect2, Color.White);
				}
				if (isExploding9 == true)
				{
					_spriteBatch.Draw(plasmaExplosionTexture, sentinelrect3, Color.White);
				}


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
                if (guardianHealth == 100)
                {
                    foreach (Vector2 position in bigplasmaPositions)
                    {
                        _spriteBatch.Draw(plasmaballTexture, position, Color.White);
                    }

                }
                else if (guardianHealth == 75)
                {
					
                    if (boss2Phase2 == false && bossmovement == false && guardianrect.Y >= 50)
					{
						foreach (Vector2 position in bigplasmaPositions2)
						{
							_spriteBatch.Draw(plasmaballTexture, position, Color.White);
						}
					}
				}
                else if (guardianHealth == 50)
				{
					if (boss2Phase4 == false && bossmovement2 == false && guardianrect.Y >= 50)
					{
						foreach (Vector2 position in bigplasmaPositions3)
						{
							_spriteBatch.Draw(plasmaballTexture, position, Color.White);
						}
					}
				}
				else if (guardianHealth == 25)
				{
					if (boss2Phase6 == false && bossmovement3 == false && guardianrect.Y >= 50)
					{
						foreach (Vector2 position in bigplasmaPositions4)
						{
							_spriteBatch.Draw(plasmaballTexture, position, Color.White);
						}
					}
				}
				if (boss2Phase2 == true)
                {
                    _spriteBatch.Draw(EMPballTexture, EMPballrect, Color.White);
                }
				if (boss2Phase4 == true)
				{
					_spriteBatch.Draw(EMPballTexture, EMPballrect, Color.White);
				}
				if (boss2Phase6 == true)
				{
					_spriteBatch.Draw(EMPballTexture, EMPballrect, Color.White);
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
                if (beamTimer2 >= 1)
                {
                    _spriteBatch.Draw(laserbeamTexture, laserbeamrect, Color.White);
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
				if (playerLife == true)
				{
					_spriteBatch.Draw(explosionTexture, peilcanrect, Color.White);
				}
			}
            if (screen == Screen.level3Intro)
            {   _spriteBatch.Draw(highCharityloadingTexture, window, Color.White);
                if (randomText == 1)
                {
                    _spriteBatch.DrawString(font, "After mysteriously being teleported into high charity you must make it out alive.", new Vector2(100, 400), Color.White);
                }
                else if (randomText == 2)
                {
                    _spriteBatch.DrawString(font, "You must regroup with the Amber clad and the Chief, But there is no signal.", new Vector2(100, 400), Color.White);
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
              if (isExploding10 == true)
              {
                _spriteBatch.Draw(floodCloudTexture, floodbomberrect, Color.White);
			  }
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

				if (isExploding3 == true)
				{
					_spriteBatch.Draw(plasmaExplosionTexture, bansheerect3, Color.White);

				}
				if (isExploding4 == true)
				{
					_spriteBatch.Draw(plasmaExplosionTexture, bansheerect4, Color.White);

				}
				if (isExploding5 == true)
				{
					_spriteBatch.Draw(plasmaExplosionTexture, bansheerect5, Color.White);

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

				if (playerLife == true)
				{
					_spriteBatch.Draw(explosionTexture, peilcanrect, Color.White);
				}
			}
           
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
            
        }
    }
}

