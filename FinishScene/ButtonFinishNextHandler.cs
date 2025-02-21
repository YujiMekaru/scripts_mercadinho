using Assets.Scripts.Game.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.FinishScene
{
    public class ButtonFinishNextHandler : MonoBehaviour
    {
        public void LoadParabensScene()
        {
            SceneManager.LoadScene("ParabensScene");
        }
    }
}
