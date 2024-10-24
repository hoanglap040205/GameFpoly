using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    public static UnityEvent gameOverEvent = new UnityEvent();
    public static UnityEvent gameWinEvent = new UnityEvent();

    public static GameManager instance;

    public GameObject gameWin;
    public GameObject gameOver;
    private void Awake()
    {
        gameOverEvent.AddListener(GameOver);
        gameWinEvent.AddListener(GameWin);
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(instance);
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
            PlayerPrefs.Save();
            Debug.Log("LevelMaxCurrent" + PlayerPrefs.GetInt("LevelMaxCurrent"));
        }
    }
}
