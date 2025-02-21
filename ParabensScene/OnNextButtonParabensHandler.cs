using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.ParabensScene
{
    public class OnNextButtonParabensHandler : MonoBehaviour
    {
        public void LoadScene()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
