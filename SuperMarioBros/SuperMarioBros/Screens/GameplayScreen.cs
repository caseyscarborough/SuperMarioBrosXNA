using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

using SuperMarioBros.ScreenManagers;
using SuperMarioBros.LevelManagers;
using System.Collections;

namespace SuperMarioBros.Screens
{
    public class GameplayScreen : GameScreen
    {
        TileManager tileManager;
        public GameplayScreen()
        {
            tileManager = new TileManager();
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

        public override void Draw(GameTime gameTime)
        {
            for (int i = 0; i < LevelOne.Map().Count; i++)
            {
                for (int j = 0; j < ((int[]) LevelOne.Map()[i]).Length; j++)
                {
                    int value = ((int[]) ((ArrayList) LevelOne.Map())[i])[j];
                    if (value == 0)
                    {
                        continue;   
                    }
                    else if (value == 1) 
                    {
                        tileManager.AddTile(new FloorTile(new Vector2(j, i)));
                    }
                }
            }
            tileManager.Draw(ScreenManager.GetInstance().SpriteBatch);
            base.Draw(gameTime);
        }

    }
}
