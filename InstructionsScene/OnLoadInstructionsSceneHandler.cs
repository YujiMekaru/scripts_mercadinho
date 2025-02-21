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
    public class OnLoadInstructionsSceneHandler : MonoBehaviour
    {
        private void Start()
        {
            NarrationSystemSingleton.GetInstance().ForcePlayAudio("instrucoes");
        }
    }
}
