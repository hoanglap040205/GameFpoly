using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class EventManager : UnityEvent
{

}
public class GameManager : MonoBehaviour
{
    public static EventManager gameOverEvent = new EventManager();
    public static EventManager gameWinEvent = new EventManager();
    public static GameManager instance;
    public int keyCollected = 0;
    public float timeRemaining = 180f;
    private bool isTimeRemain;
    public TextMeshProUGUI timeText;
    private void Awake()
    {
        gameOverEvent.AddListener(GameOver);
        gameWinEvent.AddListener(GameWin);
        if (instance == null)
        {
            instance = this;
        }
        isTimeRemain = true;
    }

    private void Update()
    {
     if(keyCollected == 5)
     {
            Debug.Log("Ban da co du chia khoa");
     }
     CheckTimeRemain();
     DisPlayTimeRemain();
    }

    private void CheckTimeRemain()
    {
        if (isTimeRemain)
        {
            if(timeRemaining > 0)
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
            Debug.Log("End game");
        }
    }

    private void DisPlayTimeRemain()
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    private void GameOver()
    {
        Debug.Log("Game Over");
    }

    private void GameWin()
    {
        Debug.Log("Ban da chien thang");
    }


}
