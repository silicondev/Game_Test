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
using SiliconGameEngine.Objects;
using SiliconGameEngine.PhysicsLogic;
using Xna_Test.Artifacts.Physical;
using Xna_Test.Artifacts.Physical.Entities;
using Xna_Test.Artifacts.Physical.Tiles;

namespace Xna_Test.Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameInstance : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics; // KEEP THIS
        TextureHolder textureHolder;
        Keys[] KeysDown;

        Player player;

        public GameInstance()
        {
            graphics = new GraphicsDeviceManager(this);
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
            ProgramStore.GameGraphicsDevice = GraphicsDevice; // Keep this line
            textureHolder = new TextureHolder();
            Graphics.Initialize();
            //Physics.Initialize();

            player = new Player();
            player.Create("main:player", new Vector2(100, 0), textureHolder["HUMAN_MALE"]);
            //player.Fall();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Graphics.LoadObject(player);
            //Physics.LoadObject(player);

            var obj = new GrassTile();
            obj.Create("world:tile", new Vector2(100, 100), textureHolder["ENV_TILE"]);

            Graphics.LoadObject(obj);
            //Physics.LoadObject(obj);
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
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeysDown = Keyboard.GetState(PlayerIndex.One).GetPressedKeys();

            int x = 0;
            int y = 0;

            if (KeysDown.Contains(Keys.Left) && !KeysDown.Contains(Keys.Right))
                x = -2;
            else if (!KeysDown.Contains(Keys.Left) && KeysDown.Contains(Keys.Right))
                x = 2;

            if (KeysDown.Contains(Keys.Up) && !KeysDown.Contains(Keys.Down))
                y = -2;
            else if (!KeysDown.Contains(Keys.Up) && KeysDown.Contains(Keys.Down))
                y = 2;

            Graphics.Get("main:player").Physics.DisableExertion("exertion:gravity");

            Graphics.Get("main:player").Physics.AddExertion(
                new Exertion()
                {
                    Name = "exertion:playermove",
                    Value = new Vector2(x, y)
                }
                );

            Graphics.Get("main:player").Iterate();

            //foreach (var obj in Graphics.LoadedObjects.Where(a => a.Physics.Exertions.Any(b => b.Name == "exertion:gravity")))
            //{
            //    bool gravity = true;
            //    foreach (var obj2 in new List<GameObject>(Graphics.LoadedObjects.Where(c => c.Name != obj.Name)))
            //    {
            //        if (obj.NextBounds.Intersect(obj2.Bounds))
            //        {
            //            obj.Physics.DisableExertion("exertion:gravity");
            //            gravity = false;
            //            break;
            //        }
            //    }
            //    if (gravity)
            //        obj.Physics.EnableExertion("exertion:gravity");
            //}

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Graphics.Draw();
            base.Draw(gameTime);
        }
    }
}
