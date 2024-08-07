using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class StorageManagerScript : MonoBehaviour
{
    public Sprite[] barrelOptions;
    public GameObject[] barrelSpawner;
    public static bool alreadyStarted = false;
    public static List<GameObject> chosenBarrels = new List<GameObject>();

    public void CreateStorage()
    {
        foreach(GameObject spawner in barrelSpawner)
        {
            spawner.GetComponent<SpriteRenderer>().sprite = barrelOptions[Random.Range(0, barrelOptions.Length)];
            chosenBarrels.Add(spawner);
        }
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name != "Task3Scene")
        {
            this.gameObject.SetActive(false);
        }
    }
}
