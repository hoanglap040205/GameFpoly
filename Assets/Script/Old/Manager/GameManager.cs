using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : UnityEvent
{

}
public class GameManager : MonoBehaviour
{
    public static EventManager gameOverEvent = new EventManager();
    public static EventManager gameWinEvent = new EventManager();

    public static GameManager instance;

    public GameObject gameWin;
    public GameObject gameOver;

    public int keyCollected = 0;

    public string currentPlayer;
    private void Awake()
    {
        currentPlayer = null;
        gameOverEvent.AddListener(GameOver);
        gameWinEvent.AddListener(GameWin);
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(instance);
        currentPlayer = UiManager.instanceUI.playerLogin;
        Debug.Log("Player Name:" +currentPlayer);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameWin();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        gameOver.SetActive(true);
        
    }

    private void GameWin()
    {
        Debug.Log("Ban da chien thang");
        UnLockLevel();
        gameWin.SetActive(true);
    }

    private void UnLockLevel()
    {
       if(PlayerPrefs.GetInt("LevelCurrent") >= PlayerPrefs.GetInt("LevelMaxCurrent"))
        {
            PlayerPrefs.SetInt("LevelMaxCurrent", PlayerPrefs.GetInt("LevelCurrent") + 1);
            Debug.Log("LevelMaxCurrent" + PlayerPrefs.GetInt("LevelMaxCurrent"));
        }
    }
}
