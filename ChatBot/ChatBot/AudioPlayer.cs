
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    internal class AudioPlayer
    {
        public void Play()
        {
            string filePath = "Audio/Greetings.wav"; // Ensure the file is in the correct directory
            using (SoundPlayer player = new SoundPlayer(filePath))
            {
                player.PlaySync(); // Use Play() for async playback
            }
        }
    }
}
