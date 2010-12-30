using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FPX
{
	public class Engine : Microsoft.Xna.Framework.Game
	{
		SpriteBatch spriteBatch;
		GraphicsDeviceManager graphics;


		public Engine(int width, int height)
		{
            //set the width/height
			FP.width = width;
			FP.height = height;

			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = FP.width;
			graphics.PreferredBackBufferHeight = FP.height;

			System.Console.WriteLine("FPX Initialized");

            //set some static FP variables
            FP.engine = this;
            FP.screen = new Screen();

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
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
        /// 
        /// (Essentially the same as FP.engine.onEnterFrame, from FP AS3)
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				this.Exit();

            //World update here ...
            if (FP._world.active)
            {
                //Need to add this functionality
                //if (FP._world._tween) FP._world.updateTweens();
                FP._world.update();
            }
            FP._world.updateLists();

            if (FP._goto != null) checkWorld();

            //Add INPUT UPDATE here
            // ...

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
            
			
			// render loop
            FP.screen.refresh();
			if (FP._world.visible) FP._world.render();
			
            //FP.screen.redraw();

			base.Draw(gameTime);
		}

        /// <summary>
        /// This checks if a new world has been set, and if it has, go to it
        /// </summary>
        public void checkWorld()
        {
            //end if the world to go to is null
            if (FP._goto == null) { return; }

            //end the current world
            FP.world.end();
            FP.world.updateLists();

            //go to the new world
            FP._world = FP._goto;

            //begin new world
            FP.world.begin();

            //set the world to goto as null
            FP._goto = null;
        }
	}
}
