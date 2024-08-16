using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorChecker : MonoBehaviour
{
    public GameObject storageM;
    public GameObject inventory;
    public bool opened = false;
    void OnMouseDown()
    {
        if(storageM.GetComponent<StorageManagerScript>().totalIngredients == inventory.GetComponent<InventoryTracker>().children.Length)
        {
            opened = true;
        }
    }

    void Update()
    {
        if (opened)
        {
            SceneManager.LoadScene("Task3Scene2");
        }
        if (SceneManager.GetActiveScene().name != "Task3Scene")
        {
            this.gameObject.SetActive(false);
        }
        storageM = GameObject.Find("StorageManager");
        inventory = GameObject.Find("Inventory");
    }
}
