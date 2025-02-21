using Assets.Scripts.Game.Enums;
using Assets.Scripts.Game.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonHandler : MonoBehaviour
{
    public void LoadPhase1()
    {
        var gameManager = GameManagerSingleton.GetInstance();
        gameManager.StartGame(GameDifficultyEnum.Easy);
    }

    public void LoadPhase2()
    {
        if (GameManagerSingleton.GetInstance().isPhase2Unlocked())
        {
            var gameManager = GameManagerSingleton.GetInstance();
            gameManager.StartGame(GameDifficultyEnum.Medium);
        }
    }
}
