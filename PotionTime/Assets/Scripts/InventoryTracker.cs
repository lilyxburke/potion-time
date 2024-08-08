using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryTracker : MonoBehaviour
{
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Task3Scene")
        {
            this.gameObject.SetActive(false);
        }
    }
}
