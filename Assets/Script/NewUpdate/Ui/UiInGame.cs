using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiInGame : MonoBehaviour
{
    public GameObject[] panelIngame;
    public GameObject pauseScreen;
    private bool isOpened;


    public float timeRemaining;
    private bool isTimeRemain;
    public TextMeshProUGUI timeText;
    private void Start()
    {
        isTimeRemain = true;
        timeRemaining = 180f;
        isOpened = false;
        for(int i = 0; i< panelIngame.Length; i++)
        {
            if (panelIngame[i].activeInHierarchy)
            {
                panelIngame[i].SetActive(isOpened);
            }
        }
    }

    private void Update()
    {
        DisPlayTimeRemain();
        CheckTimeRemain();
    }
    public void OnClickPauseScreen()
    {
        isOpened = !isOpened;
        pauseScreen.SetActive(isOpened);
    }

    public void PlayAgain()
    {
        string levelPlayAgain = "Map" + PlayerPrefs.GetInt("LevelCurrent");
        SceneManager.LoadScene(levelPlayAgain);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Levels");
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("LevelCurrent", PlayerPrefs.GetInt("LevelCurrent") + 1);

        string nextLevel = "Map" + PlayerPrefs.GetInt("LevelCurrent");
        Debug.Log(nextLevel);
        SceneManager.LoadScene(nextLevel);

    }
    //Check time
    //Check dieu kien kiem tra thoi gian
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
    //hien thi thoi gian
    private void DisPlayTimeRemain()
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

}
