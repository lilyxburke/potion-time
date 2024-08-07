using UnityEngine;

public class IngredientManagerScript : MonoBehaviour
{
    public GameObject[] ingredients;
    private static bool alreadyStarted = false;
    void Start()
    {
        if (!alreadyStarted)
        {
            SpawnIngredients();
        }
        else
        {
            LoadIngredients();
        }
    }

    private void SpawnIngredients()
    {

    }

    private void LoadIngredients()
    {

    }
}
