using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackScript : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("TaskScene");
    }

}
