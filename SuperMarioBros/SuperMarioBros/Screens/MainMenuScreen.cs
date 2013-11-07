using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.LevelManagers;
using SuperMarioBros.ScreenManagers;

namespace SuperMarioBros.Screens
{
    /// <summary>
    /// The main menu screen is the first thing displayed when the game starts up.
    /// </summary>
    class MainMenuScreen : MenuScreen
    {
        ContentManager content;
        SpriteBatch spriteBatch;
        Tile floorTile;

        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public MainMenuScreen()
            : base("")
        {
            // Create our menu entries.s
            MenuEntry onePlayerGameEntry = new MenuEntry("1 Player Game");
            MenuEntry twoPlayerGameEntry = new MenuEntry("2 Player Game");
            MenuEntry exitMenuEntry = new MenuEntry("Exit");

            // Hook up menu event handlers.
            onePlayerGameEntry.Selected += PlayGameMenuEntrySelected;
            twoPlayerGameEntry.Selected += PlayGameMenuEntrySelected;
            exitMenuEntry.Selected += ExitGameSelected;

            // Add entries to the menu.
            MenuEntries.Add(onePlayerGameEntry);
            MenuEntries.Add(twoPlayerGameEntry);
            MenuEntries.Add(exitMenuEntry);
        }

        /// <summary>
        /// Event handler for when the Play Game menu entry is selected.
        /// </summary>
        void PlayGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
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
            floorTile = new FloorTile();

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 logoPosition = new Vector2(
                (ScreenManager.Game.GraphicsDevice.Viewport.Width / 2) - (GameContentManager.MainMenuLogo.Width / 2),
                                           ScreenManager.Game.GraphicsDevice.Viewport.Height / 6);
            spriteBatch = ScreenManager.SpriteBatch;
            spriteBatch.Begin();
            spriteBatch.Draw(GameContentManager.MainMenuLogo, logoPosition, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
