using Assets.Scripts.Game.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MenuScene
{
    public class OnLoadMenuSceneHandler : MonoBehaviour
    {
        [SerializeField] private GameObject phase2Button;

        private void Start()
        {
            NarrationSystemSingleton.GetInstance().ForcePlayAudio("bem-vindo");

            var imageButton = phase2Button.GetComponent<Image>();

            if (!GameManagerSingleton.GetInstance().isPhase2Unlocked())
            {
                imageButton.color = new Color(80f / 255f, 80f / 255f, 80f / 255f, 1f);
            }
        }
    }
}
