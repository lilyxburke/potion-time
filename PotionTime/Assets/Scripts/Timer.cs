using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float timeLeft;
    public bool timerOn = false;
    void Start()
    {
        timerOn = true;
        timeLeft = ChooseDifficulty.time;
    }
    void Update()
    {
        if (timerOn)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                timeLeft = 0;
                timerOn = false;
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
