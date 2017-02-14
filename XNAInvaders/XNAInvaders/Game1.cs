
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;

namespace XNAInvaders
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background, scanlines;

        Player thePlayer;
        Bullet theBullet;
        invaderShip newShip;

        
        int hit = 3;
        int shieldHit = 3; 
        //TODO: Add multiple invaders here

        List<Invader> invaders = new List<Invader>();
       List<shield> shields = new List<shield>();
        //List<invaderShip> ships = new List<invaderShip>();

        Boolean overlaps(float x0, float y0, Texture2D texture0, float x1, float y1, Texture2D texture1)
        {
            int w0 = texture0.Width,
            h0 = texture0.Height,
            w1 = texture1.Width,
            h1 = texture1.Height;

            if (x0 > x1 + w1 || x0 + w0 < x1 ||
              y0 > y1 + h1 || y0 + h0 < y1)
                return false;
            else
                return true;
        }


        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);            
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
 
            Content.RootDirectory = "Content";
        }

        


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
             
            // Pass often referenced variables to Global
            Global.GraphicsDevice = GraphicsDevice;            
            Global.content = Content;

            // Create and Initialize game objects
            thePlayer = new Player();
            theBullet = new Bullet();
            newShip = new invaderShip();


            for (int iInvader = 0; iInvader <20 ; iInvader++)
            {
                Invader newInvader = new Invader();
                newInvader.Init();
                invaders.Add(newInvader);
               
            }
            for (int iShield = 0; iShield < 4; iShield++)
            {
                shield newShield = new shield();
                newShield.Init();
                shields.Add(newShield);
                

            }
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.spriteBatch = spriteBatch;
            background = Content.Load<Texture2D>("background");
            scanlines = Content.Load<Texture2D>("scanlines");
            base.Initialize();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

           


            // Pass keyboard state to Global so we can use it everywhere
            Global.keys = Keyboard.GetState();
            if (Global.keys.IsKeyDown(Keys.Space)) theBullet.Fire(thePlayer.position);
            // Update the game objects
            thePlayer.Update();
            theBullet.Update();
            newShip.Update();
                for (int iInvader = 0; iInvader < invaders.Count; iInvader++)
            {
                Invader newInvader = invaders[iInvader];
                newInvader.Update();

                if (overlaps(theBullet.position.X, theBullet.position.Y, theBullet.texture, newInvader.position.X, newInvader.position.Y, newInvader.texture))
                {
                    theBullet.Init();
                    invaders.RemoveAt(iInvader);
                }


            }

           //ship
            if (overlaps(theBullet.position.X, theBullet.position.Y, theBullet.texture, newShip.position.X, newShip.position.Y, newShip.texture))
                {
                    theBullet.Init();

               hit -= 1;       
                    
            }

            if (hit <= 0)
            {
                newShip.Death();
            }

            //shield
            for (int iShield = 0; iShield < shields.Count; iShield++)
            {
                shield newShield = shields[iShield];


             
                if (overlaps(theBullet.position.X, theBullet.position.Y, theBullet.texture, newShield.position.X, newShield.position.Y, newShield.texture))
                {
                    theBullet.Init();

                    shieldHit -= 1;
                    if (shieldHit <= 0)
                    {

                        shields.RemoveAt(iShield);

                        shieldHit = 3;

                    }
                }
                for (int iInvader = 0; iInvader < invaders.Count; iInvader++)
                {
                    Invader newInvader = invaders[iInvader];
                    if (overlaps(newInvader.position.X, newInvader.position.Y, newInvader.texture, newShield.position.X, newShield.position.Y, newShield.texture))
                {
                    

                        shieldHit -= 1;

                        invaders.RemoveAt(iInvader);
                        if (shieldHit <= 0)
                        {

                            shields.RemoveAt(iShield);

                            shieldHit = 3;

                        }
                    }

                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {            
            spriteBatch.Begin();
            // Draw the background (and clear the screen)
            spriteBatch.Draw(background, Global.screenRect, Color.White);

            // Draw the game objects
            thePlayer.Draw();
            theBullet.Draw();
            newShip.Draw();
            for (int iInvader = 0; iInvader < invaders.Count; iInvader++)
            {
                
                invaders[iInvader].Draw();
                
            }
            for (int iShield = 0; iShield < shields.Count; iShield++)
            {
                shields[iShield].Draw();

            }
            spriteBatch.Draw(scanlines, Global.screenRect, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
