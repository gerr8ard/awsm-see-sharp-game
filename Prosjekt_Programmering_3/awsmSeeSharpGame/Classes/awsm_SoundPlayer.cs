using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace awsmSeeSharpGame.Classes
{
    public class awsm_SoundPlayer
    {  
        
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader;
        private string resourceUrl = System.Windows.Forms.Application.StartupPath + "\\Resources\\";

        public awsm_SoundPlayer(string _soundName)
        {
             waveOutDevice = new WaveOut();

             audioFileReader = new AudioFileReader(resourceUrl + _soundName);

            waveOutDevice.Init(audioFileReader);

            waveOutDevice.Play();
        }

        public void Stop()
        {
            waveOutDevice.Stop();
        }
        
    }
}
