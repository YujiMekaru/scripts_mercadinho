using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHomeHandler : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
