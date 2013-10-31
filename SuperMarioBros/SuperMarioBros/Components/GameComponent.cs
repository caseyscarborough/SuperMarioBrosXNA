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

namespace SuperMarioBros.Components
{
    public class GameComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public Texture2D Texture;
        public Vector2 Position;
        public bool Active;
        protected string contentPath;

        public GameComponent(Game game) : base(game) { }

        public GameComponent(Game game, string path)
            : base(game)
        {
            this.contentPath = path;
        }

        // Get the width of the game component
        public int Width
        {
            get { return Texture.Width; }
        }

        // Get the height of the game component
        public int Height
        {
            get { return Texture.Height; }
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            this.Active = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.Texture = Game.Content.Load<Texture2D>(contentPath);
            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
