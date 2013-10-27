using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace SuperMarioBros.Screens
{
    /// <summary>
    /// The options screen is brought up over the top of the main menu
    /// screen, and gives the user a chance to configure the game
    /// in various hopefully useful ways.
    /// </summary>
    class OptionsMenuScreen : MenuScreen
    {
        MenuEntry shipSpeedEntry;
        MenuEntry difficultyEntry;
        MenuEntry soundEntry;
        MenuEntry fullscreenEntry;

        static string[] difficulties = { "Easy", "Medium", "Hard" };
        static int currentDifficulty = 0;

        static bool sound = true;
        static bool fullscreen = false;
        static int shipSpeed = 10;

        /// <summary>
        /// Constructor.
        /// </summary>
        public OptionsMenuScreen()
            : base("Options")
        {
            // Create our menu entries.
            shipSpeedEntry = new MenuEntry(string.Empty);
            difficultyEntry = new MenuEntry(string.Empty);
            soundEntry = new MenuEntry(string.Empty);
            fullscreenEntry = new MenuEntry(string.Empty);

            SetMenuEntryText();

            MenuEntry back = new MenuEntry("Back");

            // Hook up menu event handlers.
            shipSpeedEntry.Selected += ShipSpeedMenuEntrySelected;
            difficultyEntry.Selected += DifficultyMenuEntrySelected;
            soundEntry.Selected += SoundMenuEntrySelected;
            fullscreenEntry.Selected += FullScreenMenuEntrySelected;
            back.Selected += OnCancel;


            // Add entries to the menu.
            MenuEntries.Add(shipSpeedEntry);
            MenuEntries.Add(difficultyEntry);
            MenuEntries.Add(fullscreenEntry);
            MenuEntries.Add(soundEntry);

            MenuEntries.Add(back);
        }


        /// <summary>
        /// Fills in the latest values for the options screen menu text.
        /// </summary>
        void SetMenuEntryText()
        {
            shipSpeedEntry.Text = "Ship Speed: " + shipSpeed;
            difficultyEntry.Text = "Difficulty: " + difficulties[currentDifficulty];
            soundEntry.Text = "Sound: " + (sound ? "On" : "Off");
            fullscreenEntry.Text = "Fullscreen: " + (fullscreen ? "Yes" : "No"); 
        }


        /// <summary>
        /// Event handler for when the Elf menu entry is selected.
        /// </summary>
        void ShipSpeedMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            shipSpeed++;

            SetMenuEntryText();
        }


        /// <summary>
        /// Event handler for when the Language menu entry is selected.
        /// </summary>
        void DifficultyMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            currentDifficulty = (currentDifficulty + 1) % difficulties.Length;

            SetMenuEntryText();
        }


        /// <summary>
        /// Event handler for when the Frobnicate menu entry is selected.
        /// </summary>
        void SoundMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            if (sound) MediaPlayer.Stop(); else MediaPlayer.Resume();
            sound = !sound;
            SetMenuEntryText();
        }

        void FullScreenMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            //ScreenManager.Game.graphics.ToggleFullScreen();           commented until Giang adds his part
            fullscreen = !fullscreen;
            SetMenuEntryText();
        }

    }
}
