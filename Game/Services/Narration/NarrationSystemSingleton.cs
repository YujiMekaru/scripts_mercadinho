using Assets.Scripts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Services
{
    public class NarrationSystemSingleton
    {

        private static NarrationSystemSingleton _instance;
        private AudioPlayer audioPlayer;
      
        private NarrationSystemSingleton()
        {
            audioPlayer = new GameObject("AudioPlayer").AddComponent<AudioPlayer>();
        }

        public static NarrationSystemSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NarrationSystemSingleton();

            }
            return _instance;
        }

        public void PlayAudio(string fileName)
        {
            audioPlayer.PlayAudio(fileName);
        }
        
        public void ForcePlayAudio(string fileName)
        {
            audioPlayer.StopAndClearQueue();
            audioPlayer.PlayAudio(fileName);
        }

        public void ToggleMute()
        {
            audioPlayer.ToggleMute();
        }

        public bool IsMuted()
        {
            return audioPlayer.IsMuted();
        }


        public void PlayProductListAudio()
        {
            var list = ShoppingListSingleton.GetInstance().GetShoppingList();

            foreach (var item in list)
            {
                string numberFileName = item.Value.ToAudioFileName();
                audioPlayer.PlayAudio(numberFileName);

                string productFileName = item.Key.AudioFileName;
                audioPlayer.PlayAudio(productFileName);
            }
        }

    }
}
