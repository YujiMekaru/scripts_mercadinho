using Assets.Scripts.Game.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.ParabensScene
{
    public class OnLoadParabensSceneHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tempo;
        [SerializeField] private TMP_Text _score;

        private void Start()
        {
            NarrationSystemSingleton.GetInstance().ForcePlayAudio("parabensScene");

            var time = GameManagerSingleton.GetInstance().GetFinalTime();
            _tempo.text = "Tempo: " + time.ToString("##") + " segundos";

            _score.text = "Taxa de Acerto: " + GameManagerSingleton.GetInstance().CalculateAssertivity() + "%";
        }
    }
}
