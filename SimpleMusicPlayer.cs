using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace GADE_6122_POE_Adishesha_and_Ayden
{
    public static class SimpleMusicPlayer
    {
        private static SoundPlayer musicPlayer;
        private static bool isPlaying = false;

        public static void PlayMusic(string filePath)
        {
            try
            {
                if (musicPlayer != null)
                {
                    musicPlayer.Stop();
                    musicPlayer.Dispose();
                }

                musicPlayer = new SoundPlayer(filePath);
                musicPlayer.Load(); // Load synchronously
                musicPlayer.PlayLooping(); // Loop continuously
                isPlaying = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Music error: {ex.Message}");
            }
        }

        public static void StopMusic()
        {
            if (musicPlayer != null)
            {
                musicPlayer.Stop();
                isPlaying = false;
            }
        }

        public static void Dispose()
        {
            StopMusic();
            musicPlayer?.Dispose();
        }
    }
}