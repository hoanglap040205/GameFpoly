using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TimeManagement : MonoBehaviour
{
    public float timeRemaining;
    private bool isTimeRemain;
    public TextMeshProUGUI timeText;

    private void Awake()
    {
        isTimeRemain = true;
        timeRemaining = 180f;
    }
    private void Update()
    {
     DisPlayTimeRemain();
        CheckTimeRemain();
    }
    private void CheckTimeRemain()
    {
        if (isTimeRemain)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                isTimeRemain = false;
                timeRemaining = 0f;
            }
        }
        else
        {
            GameManager.gameOverEvent.Invoke();
        }
    }

    private void DisPlayTimeRemain()
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
