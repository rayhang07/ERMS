using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ERMS
{
    public static class Sound
    {
        // Path to the sound stored in the resource folder
        private static string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");

        // Method to play success sound
        public static void PlaySuccess()
        {
            string fullPath = Path.Combine(basePath, "success.wav");
            try
            {
                // Creates an instance of the sound
                SoundPlayer player = new SoundPlayer(fullPath);
                player.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not play success sound: {ex.Message}");
                
            }
        }

        // Method to play error sound
        public static void PlayError()
        {
            string fullPath = Path.Combine(basePath, "error.wav");
            try
            {
                // Creates an instance of the sound
                SoundPlayer player = new SoundPlayer(fullPath);
                player.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not play error sound: {ex.Message}");
                
            }
        }


    }
}
