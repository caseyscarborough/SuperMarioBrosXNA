using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

using SuperMarioBros.ScreenManagers;
using SuperMarioBros.LevelManagers;
using SuperMarioBros.TileManagers;
using SuperMarioBros.TileManagers.Tiles;
using System.Collections;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.Components;

namespace SuperMarioBros.Screens
{
    public class GameplayScreen : GameScreen
    {
        TileManager tileManager;
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        Mario mario;

        public GameplayScreen()
        {
            tileManager = TileManager.GetInstance();
            mario = new Mario(ScreenManager.GetInstance().Game);
            ScreenManager.GetInstance().Game.Components.Add(mario);
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
            PlayMusic(GameContentManager.GetInstance().GetSong("main_theme"));
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            currentKeyboardState = Keyboard.GetState();

            mario.Update(gameTime, currentKeyboardState, previousKeyboardState);

            previousKeyboardState = currentKeyboardState;
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void Draw(GameTime gameTime)
        {
            tileManager.BuildMap(typeof(LevelOne));
            tileManager.Draw(ScreenManager.GetInstance().SpriteBatch);
            base.Draw(gameTime);
        }

    }
}
