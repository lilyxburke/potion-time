using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameplayScript : MonoBehaviour
{
    public GameObject taskDisplay;
    public GameObject completed;
    public Transform transformVariable;
    public List<GameObject> availableTasks;
    public static List<GameObject> runningTasks = new List<GameObject>();
    public static List<GameObject> finishedTasks = new List<GameObject>();
    public static List<GameObject> completedTasks = new List<GameObject>();
    public static bool started = false;
    public static List<GameObject> dontDestroy = new List<GameObject>();

    void Start()
    {
        if (!started)
        {
            ChooseTasks();
            LoadTasks();
            started = true;
        }
        else
        {
            LoadTasks();
        }
    }

    void ChooseTasks()
    {
        for (int i = 0; i < ChooseDifficulty.tasks; i++)
        {
            int taskValue = Random.Range(0, availableTasks.Count);
            runningTasks.Add(availableTasks[taskValue]);
            availableTasks.Remove(availableTasks[taskValue]);
        }
    }

    void LoadTasks()
    {
        float x = -5f;
        float y = 1.25f;

        for (int i = 0; i < 3; i++)
        {
            transformVariable.position = new Vector3(x, y, 2);
            Instantiate(taskDisplay, transformVariable.position, transform.rotation);
            transformVariable.position = new Vector3(x, y, 1);
            Instantiate(runningTasks[i], transformVariable.position, transform.rotation);

            x += 5f;
        }

        
        x = -2.5f;
        y = -2.75f;
        for (int i = 0; i < ChooseDifficulty.tasks - 3; i++)
        {

            transformVariable.position = new Vector3(x, y, 2);
            Instantiate(taskDisplay, transformVariable.position, transform.rotation);

            transformVariable.position = new Vector3(x, y, 1);
            Instantiate(runningTasks[i + 3], transformVariable.position, transform.rotation);

            x += 5f;
        }
    }

    public static void CompletedTask(int taskNumber)
    {
        SceneManager.LoadScene("TaskScene");
        int index = runningTasks.FindIndex(GameObject => GameObject.name == "Task" + taskNumber);
        completedTasks.Add(runningTasks[index]);
    }

    public void UpdateCompletedTasks()
    {
        foreach (GameObject i in completedTasks)
        {
            GameObject obj = GameObject.Find(i.name + "(Clone)");
            obj.GetComponent<BoxCollider2D>().enabled = false;
            Transform transform = obj.transform;
            Vector3 newLocation = new Vector3(transform.position.x, transform.position.y, 0);
            Instantiate(completed, newLocation, transform.rotation);
        }
    }
    void Update()
    {
        UpdateCompletedTasks();
    }
}
