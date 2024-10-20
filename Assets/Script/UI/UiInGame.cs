using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiInGame : MonoBehaviour
{
    public GameObject pauseScreen;
    public void OpenPauseScreen()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosedPauseScreen()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void BackSelecteLevel()
    {
        SceneManager.LoadScene("LevelsManager");
    }
}
