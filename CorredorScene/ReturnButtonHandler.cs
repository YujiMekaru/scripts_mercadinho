using Assets.Scripts.Game.Enums;
using Assets.Scripts.Game.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.CorredorScene
{
    public class ReturnButtonHandler : MonoBehaviour
    {
        public void Return()
        {
            GameManagerSingleton.GetInstance().CorredorAtual = CorredorAtualEnum.Nenhum;
            SceneManager.LoadScene("SessaoScene");
        }
    }
}
