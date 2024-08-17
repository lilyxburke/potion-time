using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InventoryTracker : MonoBehaviour
{
    public int[] ingredientNumbers = new int[5];

    public List<GameObject> numbers = new List<GameObject>();
    public List<GameObject> ingredientOrder = new List<GameObject>();
    public GameObject[] children;
    public GameObject numbersObject;
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "PotionTask3")
        {
            this.gameObject.SetActive(false);
            numbers = new List<GameObject>();
        }
        children = GetChildren();

    }

    void OnEnable()
    {
        if (ingredientOrder.Count != 0)
        {
            for (int i = 0; i < ingredientOrder.Count; i++)
            {
                GameObject number = Instantiate(numbersObject, new Vector3(-2 + i, 1f, -0.5f), transform.rotation);
                number.transform.SetParent(GameObject.Find("Number").transform);
                number.transform.localPosition = new Vector3(-180 + (i * 160), -325, 1);
                number.GetComponent<TextMeshProUGUI>().text = ingredientNumbers[i].ToString();
                numbers.Add(number);
            }
        }
    }
    public void AddIngredient(GameObject ingredient)
    {
        bool exists = false;
        GameObject childIndex = null;
        foreach (GameObject child in children)
        {
            if (child.name == ingredient.name)
            {
                exists = true;
                childIndex = child;
                break;
            }
        }
        if (!exists)
        {
            ingredientOrder.Add(ingredient);
            ingredientNumbers[ingredientOrder.IndexOf(ingredient)] += 1;

            ingredient.transform.localPosition = new Vector3 (-2 + ingredientOrder.IndexOf(ingredient), -0.01f, -0.5f);
            ingredient.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            ingredient.SetActive(true);
            GameObject number = Instantiate(numbersObject, new Vector3(-2 + ingredientOrder.IndexOf(ingredient), 1f, -0.5f), transform.rotation);
            number.transform.SetParent(GameObject.Find("Number").transform);
            number.transform.localPosition = new Vector3(-180 + (ingredientOrder.IndexOf(ingredient) * 160), -325, 1);
            number.GetComponent<TextMeshProUGUI>().text = "1";
            numbers.Add(number);

        }
        else
        {
            ingredientNumbers[ingredientOrder.IndexOf(childIndex)] += 1;
            numbers[ingredientOrder.IndexOf(childIndex)].GetComponent<TextMeshProUGUI>().text =
                ingredientNumbers[ingredientOrder.IndexOf(childIndex)].ToString();
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
}
