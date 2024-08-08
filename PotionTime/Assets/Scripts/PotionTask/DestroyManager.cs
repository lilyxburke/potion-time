using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    public static bool alreadyStarted = false;
    public GameObject storageManager;
    public GameObject inventory;

    void Start()
    {
        if (!alreadyStarted)
        {
            storageManager.GetComponent<StorageManagerScript>().CreateStorage();
            alreadyStarted = true;
            DontDestroyOnLoad(storageManager);
            GameplayScript.dontDestroy.Add(storageManager);
            DontDestroyOnLoad(inventory);
            GameplayScript.dontDestroy.Add(inventory);

        }
        else
        {
            Destroy(storageManager);
            Destroy(inventory);
            ActivateDestroyObject("StorageManager");
            ActivateDestroyObject("Inventory");
        }
    }

    void ActivateDestroyObject(string tagName)
    {
        GameObject found = null;
        foreach (GameObject obj in GameplayScript.dontDestroy)
        {
            if (obj.CompareTag(tagName))
            {
                found = obj;
            }
        }
        found.SetActive(true);
    }
}
