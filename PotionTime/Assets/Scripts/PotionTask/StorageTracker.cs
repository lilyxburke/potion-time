using UnityEngine;
using Random = UnityEngine.Random;

public class StorageTracker : MonoBehaviour
{
    public GameObject inventory;
    public GameObject exit;
    public Sprite chest;
    public Sprite book;
    public GameObject storageManager;
    public static bool opened = false;
    public GameObject[] children;

    void Update()
    {
        children = GetChildren();
    }

    void OnEnable()
    {
        exit = GameObject.Find("ExitButton");
        inventory = GameObject.Find("ChestInventory");
    }
    private void OnMouseDown()
    {
        storageManager.GetComponent<StorageManagerScript>().chosen = this.gameObject;
        ReloadInventory();
    }

    private void ChooseBackground()
    {
        if (this.gameObject.name.Contains("Barrel"))
        {
            inventory.GetComponent<SpriteRenderer>().sprite = chest;
            inventory.GetComponent<Transform>().localScale = new Vector3(2.5f, 2.5f, 1);
        }
        else
        {
            inventory.GetComponent<SpriteRenderer>().sprite = book;
        }
        inventory.SetActive(true);
        exit.SetActive(true);
    }
    public void CreateInventory()
    {
        int maximum = 7;
        StorageManagerScript script = storageManager.GetComponent<StorageManagerScript>();

        while (maximum != 0)
        {
            for (int i = 0; i < 15; i++)
            {
                if (Random.Range(0, 3) == 1)
                {
                    int j = Random.Range(0, script.itemChoices.Length-1);
                    GameObject item = Instantiate(script.itemChoices[j], this.gameObject.transform);
                    maximum--;
                    item.SetActive(false);
                    storageManager.GetComponent<StorageManagerScript>().totalIngredients++;
                }
                else
                {
                    GameObject item = Instantiate(script.itemChoices[4], this.gameObject.transform);
                    item.SetActive(false);
                }
            }
            break;
        }
    }

    private GameObject[] GetChildren()
    {
        GameObject[] children = new GameObject[this.gameObject.transform.childCount];
        for (int i = 0; i < children.Length; ++i)
        {
            children[i] = this.gameObject.transform.GetChild(i).gameObject;
        }
        return children;
    }
    private void ReloadInventory()
    {
        float x = 2.4f;
        float y = 0.25f;
        int count = 0;
        Transform transform = this.gameObject.transform;
        float change = 7.5f + transform.position.x;
        x = 2.4f - change;
        for (int i = 0; i < children.Length; i++)
        {
            children[i].transform.localPosition = new Vector3(x, y, -0.5f);
            count++;
            if (count == 5)
            {
                children[i].transform.localPosition = new Vector3(x, y, -0.5f);
                x = 2.4f - change;
                y -= 2.7f;
                count = 0;
            }
            else
            {
                x += 2.4f;
            }
            children[i].SetActive(true);

        }

        inventory.SetActive(true);
        exit.SetActive(true);
        GameObject.Find("Canvas").SetActive(false);
    }

}
