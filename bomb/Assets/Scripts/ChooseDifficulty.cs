using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseDifficulty : MonoBehaviour
{
    public GameObject easy;
    public static string difficulty = "";
   public void ChooseDifficuty()
    {
        SceneManager.LoadScene("DefuseScene");
    }

    public void EasyDifficulty()
    {
        difficulty = "easy";
        Debug.Log("diffuclty is " + difficulty);
    }
}
