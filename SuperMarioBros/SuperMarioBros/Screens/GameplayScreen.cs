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
            tileManager = new TileManager();
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
            PlayMusic(GameContentManager.GetInstance().MainTheme);
        }

        private void HandleTiles(String value, int i, int j)
        {
            Tile tile = null;
            switch (value)
            {
                case "1":
                    tile = new FloorTile(new Vector2(j, i));
                    break;
                case "2":
                    tile = new LargeTreeTile(new Vector2(j * 33, i * 29));
                    break;
                case "3":
                    tile = new BrickTile(new Vector2(j, i));
                    break;
                case "4":
                    tile = new QuestionMarkTile(new Vector2(j, i));
                    break;
                case "5":
                    tile = new BushTile(new Vector2(j * 33, i * 32));
                    break;
                case "6":
                    tile = new CloudTile(new Vector2(j * 33, i * 33));
                    break;
            }

            if (tile != null) tileManager.AddTile(tile);
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
            for (int i = 0; i < LevelOne.Map().Count; i++)
            {
                for (int j = 0; j < ((String[]) LevelOne.Map()[i]).Length; j++)
                {
                    String value = ((String[]) ((ArrayList) LevelOne.Map())[i])[j];
                    HandleTiles(value, i, j);
                }
            }
            tileManager.Draw(ScreenManager.GetInstance().SpriteBatch);
            base.Draw(gameTime);
        }

    }
}
