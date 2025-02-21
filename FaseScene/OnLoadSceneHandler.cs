using Assets.Scripts.Game.Enums;
using Assets.Scripts.Game.Interfaces;
using Assets.Scripts.Game.Models;
using Assets.Scripts.Game.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.FaseScene
{
    public class OnLoadSceneHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private GameObject _listGameObject;

        private GameDifficultyEnum _gameDifficulty;

        private void Start()
        {


            _gameDifficulty = GameManagerSingleton.GetInstance().Difficulty;

            string sceneName = SceneManager.GetActiveScene().name;

            ShoppingListSingleton.GetInstance().LoadShoppingList(_listGameObject);

            if (sceneName == "FaseScene")
            {
                NarrationSystemSingleton.GetInstance().ForcePlayAudio("faseScene1");
                NarrationSystemSingleton.GetInstance().PlayAudio("faseScene2");
                NarrationSystemSingleton.GetInstance().PlayProductListAudio();
                _title.text = "Fase " + (int)_gameDifficulty;
            }
            else if (sceneName == "SessaoScene")
            {
                NarrationSystemSingleton.GetInstance().ForcePlayAudio("sessaoScene");
            }
            else
            {
                NarrationSystemSingleton.GetInstance().ForcePlayAudio("finishScene");
            }

        }
    }
}
