using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskClick : MonoBehaviour
{
    public GameObject chosenTask;
    public GameplayScript gameplay;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(chosenTask.name.Replace("(Clone)", "").Trim() + "Scene");
    }

}
