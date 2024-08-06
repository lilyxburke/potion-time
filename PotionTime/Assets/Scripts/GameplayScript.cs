using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class GameplayScript : MonoBehaviour
{
    public GameObject taskDisplay;
    public Transform transformVariable;
    public List<GameObject> availableTasks;
    public List<GameObject> runningTasks;

    void Start()
    {
        float x = -5f;
        float y = 1.25f;

        for (int i = 0; i < 3; i++)
        {
            transformVariable.position = new Vector3(x, y, 2);
            Instantiate(taskDisplay, transformVariable.position, transform.rotation);

            int taskValue = Random.Range(0,availableTasks.Count);
            runningTasks.Add(availableTasks[taskValue]);
            transformVariable.position = new Vector3(x, y, 1);
            Instantiate(availableTasks[taskValue], transformVariable.position, transform.rotation);
            availableTasks.Remove(availableTasks[taskValue]);

            x += 5f;
        }

        for (int i = 0; i < ChooseDifficulty.tasks - 3; i++)
        {
            x = -2.5f;
            y = -2.75f;

            transformVariable.position = new Vector3(x, y, 2);
            Instantiate(taskDisplay, transformVariable.position, transform.rotation);

            int taskValue = Random.Range(0, availableTasks.Count);
            runningTasks.Add(availableTasks[taskValue]);
            transformVariable.position = new Vector3(x, y, 1);
            Instantiate(availableTasks[taskValue], transformVariable.position, transform.rotation);
            availableTasks.Remove(availableTasks[taskValue]);

            x += 5f;
        }



    }
}
