using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class StorageManagerScript : MonoBehaviour
{
    public Sprite[] barrelOptions;
    public Sprite[] bookOptions;
    public GameObject[] barrelSpawner;
    public GameObject[] bookSpawner;
    public static bool alreadyStarted = false;
    public GameObject[] itemChoices;
    public GameObject chosen;
    public int totalIngredients = 0;
    public void CreateStorage()
    {
        foreach(GameObject barrel in barrelSpawner)
        {
            barrel.GetComponent<SpriteRenderer>().sprite = barrelOptions[Random.Range(0, barrelOptions.Length)];
            barrel.GetComponent<StorageTracker>().CreateInventory();
        }
        foreach (GameObject book in bookSpawner)
        {
            book.GetComponent<SpriteRenderer>().sprite = bookOptions[Random.Range(0, bookOptions.Length)];
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
