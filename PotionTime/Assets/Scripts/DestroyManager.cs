using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    public static bool alreadyStarted = false;
    public static List<GameObject> chosenBarrels = new List<GameObject>();
    public GameObject storageManager;

    void Start()
    {
        if (!alreadyStarted)
        {
            storageManager.GetComponent<StorageManagerScript>().CreateStorage();
            alreadyStarted = true;
            DontDestroyOnLoad(storageManager);
            GameplayScript.dontDestroy.Add(storageManager);
        }
        else
        {
            Destroy(storageManager);
            GameObject found = null;
            foreach (GameObject obj in GameplayScript.dontDestroy)
            {
                if (obj.CompareTag("StorageManager"))
                {
                    found = obj;
                }
            }
            found.SetActive(true);
        }
    }
}
