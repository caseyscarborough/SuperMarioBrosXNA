using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;

using SuperMarioBros.ScreenManagers;

namespace SuperMarioBros.Screens
{
    public class GameplayScreen : GameScreen
    {
        Song mainTheme;

        public GameplayScreen()
        {

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
            base.LoadContent();
            PlayMusic(GameContentManager.MainTheme);
        }

    }
}
