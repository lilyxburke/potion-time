using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using System;

public class RuneDecipheringScript : MonoBehaviour
{
    private int solution = 0;
    public TMP_InputField inputField;
    public List<GameObject> availableRunes;
    public List<GameObject> availableSymbols;
    public static GameObject[,] createdRunes;
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
        int runes = 0;
        if(ChooseDifficulty.difficulty == "easy")
        {
            runes = Random.Range(4, 6);
            createdRunes = new GameObject[runes,2];
        }
        bool pickedCircle = false;
        for (int i = 0; i < runes; i++)
        {    
            int runestone = Random.Range(0, availableRunes.Count);
            if (availableRunes[runestone].name.Replace("(Clone)", "").Trim() == "circle-rune")
            {
                if (!pickedCircle)
                {
                    pickedCircle = true;
                }
                else
                {
                    while (availableRunes[runestone].name.Replace("(Clone)", "").Trim() == "circle-rune")
                    {
                        runestone = Random.Range(0, availableRunes.Count);
                    }
                }
            }
            createdRunes[i, 0] = availableRunes[runestone];

            int runeSymbol = Random.Range(0, availableSymbols.Count);
            if(availableSymbols[runeSymbol].name.Replace("(Clone)", "").Trim() == "symbol-h" && i == 0)
            {
                while (availableSymbols[runeSymbol].name.Replace("(Clone)", "").Trim() == "symbol-h")
                {
                    runeSymbol = Random.Range(0, availableSymbols.Count);
                }
            }
            createdRunes[i, 1] = availableSymbols[runeSymbol];
        }

        float x = -2.5f;
        float y = 0f;

        for (int i = 0; i < runes; i++)
        {
            transformVariable.position = new Vector3(x, y, 2);
            Instantiate(createdRunes[i,0], transformVariable.position, transform.rotation);
            transformVariable.position = new Vector3(x, y, 1);
            Instantiate(createdRunes[i,1], transformVariable.position, transform.rotation);
            x += 2.5f;
        }
    }
    private void ReloadRunes()
    {
        float x = -2.5f;
        float y = 0f;
        for (int i = 0; i < createdRunes.GetLength(0); i++)
        {
            transformVariable.position = new Vector3(x, y, 2);
            Instantiate(createdRunes[i, 0], transformVariable.position, transform.rotation);
            transformVariable.position = new Vector3(x, y, 1);
            Instantiate(createdRunes[i, 1], transformVariable.position, transform.rotation);
            x += 2.5f;
        }
    }
    public void CheckAnswer(string answer)
    {
        if (int.Parse(answer) == solution)
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
        string runeName;
        string symbolName;
        for (int i = 0; i < createdRunes.GetLength(0);  i++)
        {
            {
                runeName = createdRunes[i, 0].name.Replace("(Clone)", "").Trim();
                symbolName = createdRunes[i, 1].name.Replace("(Clone)", "").Trim();
                if(runeName != "circle-rune")
                {
                    if(runeName == "star-rune")
                    {
                        solution = ApplyRune(symbolName, solution, i);
                        if (solution % 2 == 0)
                        {
                            solution = solution * 3;
                        }
                        else
                        {
                            solution += 200;
                        }
                    }
                    else if(runeName == "hexagon-rune"){
                        {
                            for(int j = 0; j < 2; j++)
                            {
                                solution = ApplyRune(symbolName, solution, i);
                            }
                        }
                    }
                    else
                    {
                        solution = ApplyRune(symbolName, solution, i);
                    }
                }
            }
            
        }
    }

    private int ApplyRune(string symbolName, int solution, int order)
    {
        switch (symbolName)
        {
            case "symbol-a":
                solution += 100;
                break;
            case "symbol-b":
                solution = solution * 2;
                break;
            case "symbol-c":
                solution += (order + 1);
                break;
            case "symbol-d":
                string solutionString = solution.ToString();
                char[] charArray = solutionString.ToCharArray();
                if(charArray.Length > 1)
                {
                    Array.Reverse(charArray);

                    solution = int.Parse(new string(charArray));
                }
                break;
            case "symbol-e":
                int day = DateTime.Now.Day;
                solution -= day;
                break;
            case "symbol-f":
                solutionString = solution.ToString();
                charArray = solutionString.ToCharArray();
                int addition = 0;
                for(int i = 0; i < charArray.Length; i++)
                {
                    int multiply = charArray[i] - '0';
                    addition += (multiply*9);
                }
                solution += addition;
                break;
            case "symbol-g":
                solution = (int)Math.Round(solution * 1.3f);
                break;
            case "symbol-h":
                solution = ApplyRune(createdRunes[0, 1].name.Replace("(Clone)", "").Trim(), solution, 0);
                break;
            case "symbol-i":
                solution += 45;
                break;
            case "symbol-j":
                solution = solution * solution;
                break;
        }
        solution = int.Parse(solution.ToString().Replace("-", "").Trim());
        return solution;
    }
}
