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

    public int keyCollected = 0;
    public string currentPlayer;
    private void Awake()
    {
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
    private void GameOver()
    {
        Debug.Log("Game Over");
    }

    private void GameWin()
    {
        Debug.Log("Ban da chien thang");
    }


}
