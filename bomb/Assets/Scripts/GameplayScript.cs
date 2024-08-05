using UnityEngine;
using TMPro;
public class GameplayScript : MonoBehaviour
{
    public TMP_Text ShowText;

    void Start()
    {
        Debug.Log(ChooseDifficulty.difficulty);
        ShowText.text = ChooseDifficulty.difficulty;

    }
}
