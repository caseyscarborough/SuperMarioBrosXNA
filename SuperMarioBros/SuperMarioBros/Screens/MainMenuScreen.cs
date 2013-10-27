using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.ScreenManagers;

namespace SuperMarioBros.Screens
{
    /// <summary>
    /// The main menu screen is the first thing displayed when the game starts up.
    /// </summary>
    class MainMenuScreen : MenuScreen
    {
        ContentManager content;
        Song mainMenuSong;
        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public MainMenuScreen()
            : base("")
        {
            // Create our menu entries.s
            MenuEntry playGameMenuEntry = new MenuEntry("Play Game");
            MenuEntry optionsMenuEntry = new MenuEntry("Options");
            MenuEntry helpMenuEntry = new MenuEntry("Help");
            MenuEntry exitMenuEntry = new MenuEntry("Exit");

            // Hook up menu event handlers.
            //playGameMenuEntry.Selected += PlayGameMenuEntrySelected;      commented until Giang adds his part
            optionsMenuEntry.Selected += OptionsMenuEntrySelected;
            helpMenuEntry.Selected += HelpMenuEntrySelected;
            exitMenuEntry.Selected += OnCancel;

            // Add entries to the menu.
            MenuEntries.Add(playGameMenuEntry);
            MenuEntries.Add(optionsMenuEntry);
            MenuEntries.Add(helpMenuEntry);
            MenuEntries.Add(exitMenuEntry);
        }

        /// <summary>
        /// Event handler for when the Play Game menu entry is selected.
        /// </summary>
       /* Commented until Giang adds his part so I can add the screens
        * void PlayGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex,
                               new GameplayScreen());
        }
        */

        /// <summary>
        /// Event handler for when the Options menu entry is selected.
        /// </summary>
        void OptionsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new OptionsMenuScreen(), e.PlayerIndex);
        }

        void HelpMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            const string message = "Move using the arrow keys and kill as\n" +
                                   "many opponents as possible without dying.\n" +
                                   "Pause the game using the ESC key.\n\n" +
                                   "Press enter to dismiss this menu.";
            MessageBoxScreen showHelpMessageBox = new MessageBoxScreen(message, false);

            ScreenManager.AddScreen(showHelpMessageBox, ControllingPlayer);
        }


        /// <summary>
        /// When the user cancels the main menu, ask if they want to exit the sample.
        /// </summary>
        protected override void OnCancel(PlayerIndex playerIndex)
        {
            const string message = "Are you sure you want to exit the game?";

            MessageBoxScreen confirmExitMessageBox = new MessageBoxScreen(message);

            confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;

            ScreenManager.AddScreen(confirmExitMessageBox, playerIndex);
        }


        /// <summary>
        /// Event handler for when the user selects ok on the "are you sure
        /// you want to exit" message box.
        /// </summary>
        void ConfirmExitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.Game.Exit();
        }


        private void PlayMusic(Song song)
        {
            try
            {
                // Play the music and loop the song
                MediaPlayer.Play(song);
                MediaPlayer.Volume = 20;
                MediaPlayer.IsRepeating = true;
            }
            catch { }
        }

        private void FadeOutMusic()
        {
            while (MediaPlayer.Volume > 0)
                MediaPlayer.Volume--;
            MediaPlayer.Stop();
        }

        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");
            mainMenuSong = content.Load<Song>("sounds/menumusic");
            PlayMusic(mainMenuSong);
            base.LoadContent();
        }

    }
}
