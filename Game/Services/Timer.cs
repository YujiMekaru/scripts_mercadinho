using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Services
{
    public class Timer : MonoBehaviour
    {
        private float timer = 0f;
        private float finalTime;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);  // Prevent this GameObject from being destroyed when loading new scenes
        }

        public float GetFinalTime()
        {
            return finalTime;
        }

        public void StartTimer()
        {
            timer = 0f;
        }

        public void StopTimer()
        {
            finalTime = timer;
        }

        void Update()
        {
            timer += Time.deltaTime; // Time.deltaTime is the time in seconds since the last frame
        }
    }
}
