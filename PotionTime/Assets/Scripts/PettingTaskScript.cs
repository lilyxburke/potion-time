using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using Random = UnityEngine.Random;

public class PettingTaskScript : MonoBehaviour
{
    private static bool submitted = false;
    private int[] correctClicks;
    private int[] chosenClicks = new int[] {0, 0, 0, 0, 0, 0};
    public Sprite[] faces;
    public Sprite[] bodies;
    public SpriteRenderer faceSprite;
    public SpriteRenderer bodySprite;

    void Start()
    {
        ChooseProperties();
        CreateSolution();
    }

    public void CheckAnswer()
    {
        if (correctClicks.SequenceEqual(chosenClicks))
        {
            submitted = true;
            GameplayScript.CompletedTask(1);

        }
        else
        {
            Timer.timeLeft -= 30;
            ResetClicks();
        }
    }

    public void ResetClicks()
    {
        chosenClicks = new int[] { 0, 0, 0, 0, 0, 0 };
    }

    public void AddClicks(Button clickedButton)
    {
        string buttonName = clickedButton.name;

        switch (buttonName)
        {
            case "LeftEar":
                chosenClicks[0]++;
                break;
            case "RightEar":
                chosenClicks[1]++; 
                break;
            case "Stomach":
                chosenClicks[2]++;
                break;
            case "Back":
                chosenClicks[3]++;
                break;
            case "LeftPaw":
                chosenClicks[4]++;
                break;
            case "RightPaw":
                chosenClicks[5]++;
                break;
        }
    }

    public void CreateSolution()
    {
        string faceName = faceSprite.sprite.name;
        string bodyName = bodySprite.sprite.name;

        if(faceName == "happy")
        {
            if (bodyName == "blackcat")
            {
                correctClicks = new int[] { 1, 0, 0, 0, 0, 0 };
            }
            else if(bodyName == "browncat")
            {
                correctClicks = new int[] { 0, 1, 0, 0, 0, 0 };
            }
            else
            {
                correctClicks = new int[] { 0, 0, 1, 0, 0, 0 };
            }
        }
        else
        {
            if (bodyName == "blackcat")
            {
                correctClicks = new int[] { 0, 0, 0, 1, 0, 0 };
            }
            else if (bodyName == "browncat")
            {
                correctClicks = new int[] { 0, 0, 0, 0, 1, 0 };
            }
            else
            {
                correctClicks = new int[] { 0, 0, 0, 0, 0, 1 };
            }
        }
    }

    public void ChooseProperties()
    {
        faceSprite.sprite = faces[Random.Range(0, 2)];
        bodySprite.sprite = bodies[Random.Range(0, 3)];

    }

    

}
