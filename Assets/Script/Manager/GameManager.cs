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
    public TextMeshProUGUI timeText;

    public int keyCollected = 0;
    public float timeRemaining = 180f;
    private bool isTimeRemain;
    public string currentPlayer;
    private int levelCompleted;
    private void Awake()
    {
        levelCompleted = 0;
        gameOverEvent.AddListener(GameOver);
        gameWinEvent.AddListener(GameWin);
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(instance);
        isTimeRemain = true;
        currentPlayer = UiManager.instanceUI.playerLogin;
        Debug.Log("Player Name:" +currentPlayer);
    }

    private void Update()
    {
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
            GameOver();
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
        levelCompleted++;
        Debug.Log("level current" +levelCompleted);
    }


}
