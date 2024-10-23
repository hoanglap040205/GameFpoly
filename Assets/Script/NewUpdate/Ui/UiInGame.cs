using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiInGame : MonoBehaviour
{
    public GameObject[] panelIngame;
    public GameObject pauseScreen;
    private bool isOpened;
    private void Start()
    {
        isOpened = false;
        for(int i = 0; i< panelIngame.Length; i++)
        {
            if (panelIngame[i].activeInHierarchy)
            {
                panelIngame[i].SetActive(isOpened);
            }
        }
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
    
}
