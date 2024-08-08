using UnityEngine;

public class ExitChest : MonoBehaviour
{
    public GameObject inventory;
    public GameObject storageManager;
    public GameObject canvas;
    void Start()
    {
        this.gameObject.SetActive(false);
    }
    
    void OnEnable()
    {
        storageManager = GameObject.Find("StorageManager");
    }

    private void OnMouseDown()
    {
        inventory.SetActive(false);
        this.gameObject.SetActive(false);
        GameObject[] children = storageManager.GetComponent<StorageManagerScript>().chosen.GetComponent<StorageTracker>().children;
        foreach (GameObject child in children)
        {
            child.SetActive(false);
        }
        canvas.SetActive(true);
    }

}
