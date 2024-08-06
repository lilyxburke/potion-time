using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SelectDifficulty");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReadInstructions()
    {
        SceneManager.LoadScene("InstructionScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("TitleMenu");
    }
}

