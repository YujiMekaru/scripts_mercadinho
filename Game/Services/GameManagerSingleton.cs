using Assets.Scripts.Game.Enums;
using Assets.Scripts.Game.Interfaces;
using Assets.Scripts.Game.Models;
using Assets.Scripts.Game.Services.CorredorFactory;
using Assets.Scripts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game.Services
{
    public class GameManagerSingleton : ICustomObserver
    {
        private static GameManagerSingleton _instance;

        private GameDifficultyEnum _difficulty;

        private CorredorAtualEnum _corredorAtual;

        private Timer timer;

        private bool phase2Unlocked = false;
        private int _correctInteractions;
        private int _wrongInteractions;

        public GameDifficultyEnum Difficulty
        {
            get { return _difficulty; }
        }

        public CorredorAtualEnum CorredorAtual
        {
            get { return _corredorAtual; }
            set { _corredorAtual = value; }
        }

        private GameManagerSingleton()
        {
            timer = new GameObject("Timer").AddComponent<Timer>();

        }

        public static GameManagerSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GameManagerSingleton();
                InventorySingleton.GetInstance().AddObserver(_instance);
                
            }
            return _instance;
        }

        public void StartGame(GameDifficultyEnum difficulty)
        {
            timer.StartTimer();
            SceneManager.LoadScene("FaseScene");

            _correctInteractions = 0;
            _wrongInteractions = 0;
            _difficulty = difficulty;
            _corredorAtual = CorredorAtualEnum.Nenhum;

            var inventory = InventorySingleton.GetInstance();
            inventory.ResetInventory();

            var shoppingList = ShoppingListSingleton.GetInstance();
            if (difficulty == GameDifficultyEnum.Easy)
            {
                shoppingList.SetupList(3, 3);
            }
            else
            {
                shoppingList.SetupList(3, 4);
            }
        }

        private void FinishGame()
        {
            timer.StopTimer();
            phase2Unlocked = true;
            SceneManager.LoadScene("FinishScene");
        }
        public void OnNotify()
        {
            if (!PendingProductsHelper.HasPendingProducts())
            {
                this.FinishGame();
            }
        }

        public float GetFinalTime()
        {
            return timer.GetFinalTime();
        }

        public bool isPhase2Unlocked()
        {
            return phase2Unlocked;
        }

        public void AddCorrectInteraction()
        {
            _correctInteractions++;
        }

        public void AddWrongInteraction()
        {
            _wrongInteractions++;
        }

        public double CalculateAssertivity()
        {
            Debug.Log("correct interactions: " + _correctInteractions);
            Debug.Log("wrong interactions: " + _wrongInteractions); 
            var percentage = ((double)_correctInteractions / (_correctInteractions + _wrongInteractions));
            percentage = Math.Round((double)(percentage*100), 2);
            return percentage;
        }
    }
}
