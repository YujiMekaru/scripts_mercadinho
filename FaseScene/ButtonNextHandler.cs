using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNextHandler : MonoBehaviour
{
    public void LoadSecaoScene()
    {
        SceneManager.LoadScene("SessaoScene");
    }
}
