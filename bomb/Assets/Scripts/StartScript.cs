using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SelectDifficulty");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

