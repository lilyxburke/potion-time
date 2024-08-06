using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;


public class PettingTaskScript : MonoBehaviour
{
    private bool submitted = false;
    private int[] correctClicks;
    private int[] chosenClicks = new int[] {0, 0, 0, 0, 0, 0};

    void Start()
    {
        correctClicks = new int[] {1, 0, 0, 0, 0, 0};
    }

    public void CheckAnswer()
    {
        if (correctClicks.SequenceEqual(chosenClicks))
        {
            submitted = true;
        }
        else
        {
            Timer.timeLeft -= 30;
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

    

}
