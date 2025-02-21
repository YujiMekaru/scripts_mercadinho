using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Services
{
    public class AudioPlayer : MonoBehaviour
    {
        private AudioSource audioSource;
        private Queue<string> audioQueue = new Queue<string>();
        private bool isPlaying = false;
        private bool isMuted;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);  // Prevent this GameObject from being destroyed when loading new scenes
            audioSource = gameObject.AddComponent<AudioSource>();
            isMuted = false;
        }

        public void PlayAudio(string audioFileName)
        {
            // Add the audio file name to the queue
            audioQueue.Enqueue(audioFileName);

            // Start playing if not already playing
            if (!isPlaying)
            {
                StartCoroutine(PlayAudioSequentially());
            }
        }

        private IEnumerator PlayAudioSequentially()
        {
            isPlaying = true;

            while (audioQueue.Count > 0)
            {
                string audioFileName = audioQueue.Dequeue();

                // Load the audio clip from the Resources folder
                AudioClip audioClip = GetAudioClip(audioFileName);

                if (audioClip != null)
                {
                    // Assign the loaded clip to the AudioSource
                    audioSource.clip = audioClip;

                    // Play the audio
                    audioSource.Play();

                    // Wait for the audio to finish playing
                    yield return new WaitWhile(() => audioSource.isPlaying);
                }
                else
                {
                    Debug.LogError("Audio file not found: " + audioFileName);
                }
            }

            isPlaying = false;
        }

        public void StopAndClearQueue()
        {
            // Stop the currently playing audio
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            // Clear the queue
            audioQueue.Clear();

            // Stop the coroutine if it's running
            StopAllCoroutines();
            isPlaying = false;
        }


        public AudioClip GetAudioClip(string audioFileName)
        {
            AudioClip audioClip = Resources.Load<AudioClip>("Audio/" + audioFileName);
            return audioClip;
        }

        public bool IsMuted()
        {
            return isMuted;
        }

        public void ToggleMute()
        {
            isMuted = !isMuted;

            if (isMuted)
                audioSource.volume = 0;
            else
                audioSource.volume = 1;
        }

    }
}
