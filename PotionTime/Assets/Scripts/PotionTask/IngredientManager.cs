using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{

    public GameObject inventory;

    void OnEnable()
    {
        inventory = GameObject.Find("Inventory");
    }
    private void OnMouseDown()
    {
        this.gameObject.transform.SetParent(GameObject.Find("Inventory").transform);
        this.gameObject.SetActive(false);
        inventory.GetComponent<InventoryTracker>().AddIngredient(this.gameObject);
    }
}
