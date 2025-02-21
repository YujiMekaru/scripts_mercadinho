using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsButtonHandler : MonoBehaviour
{
    public void LoadInstructionsScene()
    {
        SceneManager.LoadScene("InstructionsScene");
    }
}
