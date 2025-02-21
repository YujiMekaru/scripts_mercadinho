using Assets.Scripts.Game.Enums;
using Assets.Scripts.Game.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCorredorHandler : MonoBehaviour 
{
    public void EntrarCorredor(string corredorName)
    {
        switch (corredorName)
        {
            case "frutas":
                GameManagerSingleton.GetInstance().CorredorAtual = CorredorAtualEnum.Frutas;
                break;
            case "padaria":
                GameManagerSingleton.GetInstance().CorredorAtual = CorredorAtualEnum.Padaria;
                break;
            case "bebidas":
                GameManagerSingleton.GetInstance().CorredorAtual = CorredorAtualEnum.Bebidas;
                break;
        }

        SceneManager.LoadScene("CorredorScene");
    }
    
}
