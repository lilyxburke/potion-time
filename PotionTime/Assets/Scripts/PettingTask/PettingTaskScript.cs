using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class PettingTaskScript : MonoBehaviour
{
    private List<int> correctClicks = new List<int>();
    private List<int> chosenClicks = new List<int>();
    public Sprite[] options;
    public SpriteRenderer chosenSprite;

    void Start()
    {
        ChooseProperties();
        CreateSolution();
    }

    public void CheckAnswer()
    {
        List<int> checkClicks = new List<int>();
        for (int i = 0; i < chosenClicks.Count; i++) {
            checkClicks.Add(correctClicks[i]);
        }

        if (checkClicks.SequenceEqual(chosenClicks) )
        {
            if (chosenClicks.Count == correctClicks.Count)
            {
                GameplayScript.CompletedTask(1);
            }

        }
        else
        {
            Timer.timeLeft -= 10;
            ResetClicks();
        }
    }

    public void ResetClicks()
    {
        chosenClicks = new List<int>();
    }

    public void AddClicks(Button clickedButton)
    {
        string buttonName = clickedButton.name;

        switch (buttonName)
        {
            case "LeftEar":
                chosenClicks.Add(1);
                break;
            case "RightEar":
                chosenClicks.Add(2);
                break;
            case "Stomach":
                chosenClicks.Add(3);
                break;
            case "Back":
                chosenClicks.Add(4);
                break;
            case "LeftPaw":
                chosenClicks.Add(5);
                break;
            case "RightPaw":
                chosenClicks.Add(6);
                break;
        }

        CheckAnswer();
    }

    public void CreateSolution()
    {
        string optionName = chosenSprite.sprite.name;

        switch (optionName)
        {
            case "happy-black":
                correctClicks = new List<int>() { 4, 4, 3, 4, 4, 6 };
                break;
            case "happy-brown":
                correctClicks = new List<int>() { 3, 3, 3, 5, 2, 4, 4, 3 };
                break;
            case "happy-white":
                correctClicks = new List<int>() { 4, 4, 3, 2, 1, 2, 1 };
                break;
            case "sad-black":
                correctClicks = new List<int>() { 6, 5, 1, 4, 4, 4, 4, 6 };
                break;
            case "sad-brown":
                correctClicks = new List<int>() { 3, 3, 3, 5, 2, 6, 5, 1, 4 };
                break;
            case "sad-white":
                correctClicks = new List<int>() { 2, 1, 2, 1, 6, 5, 1, 4 };
                break;
        }
    }

    public void ChooseProperties()
    {
        chosenSprite.sprite = options[Random.Range(0,6)];

    }

    

}
