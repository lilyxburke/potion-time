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
        if (correctClicks.SequenceEqual(chosenClicks))
        {
            GameplayScript.CompletedTask(1);

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
                correctClicks = new List<int>() { 1 };
                break;
            case "happy-brown":
                correctClicks = new List<int>() { 2 };
                break;
            case "happy-white":
                correctClicks = new List<int>() { 3 };
                break;
            case "sad-black":
                correctClicks = new List<int>() { 4 };
                break;
            case "sad-brown":
                correctClicks = new List<int>() { 5 };
                break;
            case "sad-white":
                correctClicks = new List<int>() { 6 };
                break;
        }
    }

    public void ChooseProperties()
    {
        chosenSprite.sprite = options[Random.Range(0,6)];

    }

    

}
