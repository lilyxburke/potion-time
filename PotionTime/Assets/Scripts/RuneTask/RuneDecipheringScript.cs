using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class RuneDecipheringScript : MonoBehaviour
{
    private string solution;
    public TMP_InputField inputField;
    public List<GameObject> availableRunes;
    public static List<GameObject> usedRunes = new List<GameObject>();
    public Transform transformVariable;
    public static bool alreadyOpened = false;

    void Start()
    {
        if (!alreadyOpened)
        {
            SpawnRunes();
            CreateSolution();
            alreadyOpened = true;
        }else
        {
            ReloadRunes();
        }
    }
    private void SpawnRunes()
    {
        for (int i = 0; i < 4; i++)
        {
            int runeValue = Random.Range(0, availableRunes.Count);
            usedRunes.Add(availableRunes[runeValue]);
            availableRunes.Remove(availableRunes[runeValue]);
        }

        float x = -2.5f;
        float y = 0f;

        for (int i = 0; i < 4; i++)
        {
            transformVariable.position = new Vector3(x, y, 2);
            Instantiate(usedRunes[i], transformVariable.position, transform.rotation);

            x += 2.5f;
        }
    }
    private void ReloadRunes()
    {
        float x = -2.5f;
        float y = 0f;
        foreach (GameObject i in usedRunes)
        {
            transformVariable.position = new Vector3(x, y, 2);
            Instantiate(i, transformVariable.position, transform.rotation);

            x += 2.5f;
        }
    }
    public void CheckAnswer(string answer)
    {
        if (answer == solution)
        {
            GameplayScript.CompletedTask(2);

        }
        else
        {
            Timer.timeLeft -= 20;
            inputField.text = "";
        }
    }

    private void CreateSolution()
    {

        if (usedRunes[0].name == "RuneType1")
        {
            solution = "1";
        }
        else
        {
            solution = "4";
        }

            //solution code can be written here when it is written
    }
}
