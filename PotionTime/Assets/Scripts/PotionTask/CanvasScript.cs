using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "PotionTask3")
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
