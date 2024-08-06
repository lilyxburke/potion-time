using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class ChooseDifficulty : MonoBehaviour
{
    public GameObject easy;
    public static string difficulty = "";
    public static float time = 0;
    public static float tasks;
   public void ChooseDifficuty()
    {
        SceneManager.LoadScene("TaskScene");
    }

    public void EasyDifficulty()
    {
        difficulty = "easy";
        time = 660;
        tasks = Random.Range(4, 6);
        Debug.Log("tasks are: " + tasks);
        Debug.Log("diffuclty is " + difficulty);
    }
}
