using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.LevelManagers;
using SuperMarioBros.TileManagers;
using SuperMarioBros.TileManagers.Tiles;
using SuperMarioBros.ScreenManagers;
using System.Collections.Generic;
using SuperMarioBros.Components;

namespace SuperMarioBros.Screens
{
    /// <summary>
    /// The main menu screen is the first thing displayed when the game starts up.
    /// </summary>
    class MainMenuScreen : MenuScreen
    {
        SpriteBatch spriteBatch;
        TileManager tileManager;

        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public MainMenuScreen()
            : base("")
        {
            // Create our menu entries.s
            MenuEntry onePlayerGameEntry = new MenuEntry("1 PLAYER GAME");
            MenuEntry twoPlayerGameEntry = new MenuEntry("2 PLAYER GAME");
            MenuEntry exitMenuEntry = new MenuEntry("QUIT");

            // Hook up menu event handlers.
            onePlayerGameEntry.Selected += PlayGameSelected;
            twoPlayerGameEntry.Selected += PlayGameSelected;
            exitMenuEntry.Selected += ExitGameSelected;

            // Add entries to the menu.
            MenuEntries.Add(onePlayerGameEntry);
            MenuEntries.Add(twoPlayerGameEntry);
            MenuEntries.Add(exitMenuEntry);

            // Instantiate our tile manager
            tileManager = TileManager.GetInstance();
        }

        /// <summary>
        /// Event handler for when the Play Game menu entry is selected.
        /// </summary>
        void PlayGameSelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.GetInstance().Game.Components.RemoveAt(1);
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex, new GameplayScreen());
        }

        /// <summary>
        /// Event handler for when the Exit Game menu entry is selected.
        /// </summary>
        void ExitGameSelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.Game.Exit();
        }

        public override void LoadContent()
        {
            spriteBatch = ScreenManager.SpriteBatch;

            tileManager.AddTile(new LargeTreeTile(new Vector2(150, ScreenManager.ScreenSize.Y - 135)));
            tileManager.AddTile(new BushTile(new Vector2(ScreenManager.ScreenSize.X - 300, ScreenManager.ScreenSize.Y - 99)));

            int screenHeight = (int) ScreenManager.ScreenSize.Y / 33;

            for (int i = 0; i < ScreenManager.ScreenSize.X / 33; i++)
            {
                tileManager.AddTile(new FloorTile(new Vector2(i, (screenHeight))));
                tileManager.AddTile(new FloorTile(new Vector2(i, (screenHeight - 1))));
            }

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 logoPosition = new Vector2(
                (ScreenManager.Game.GraphicsDevice.Viewport.Width / 2) - (GameContentManager.GetInstance().GetTexture("main_menu_logo").Width / 2),
                                           ScreenManager.Game.GraphicsDevice.Viewport.Height / 6);
            spriteBatch = ScreenManager.GetInstance().SpriteBatch;
            spriteBatch.Begin();
            spriteBatch.Draw(GameContentManager.GetInstance().GetTexture("main_menu_logo"), logoPosition, Color.White);
            spriteBatch.End();
            tileManager.Draw(spriteBatch);
            base.Draw(gameTime);
        }

    }
}
