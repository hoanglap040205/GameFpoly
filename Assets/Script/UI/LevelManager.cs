using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject highScore;
    public void OpenLevelID(int level)
    {
        string levelId = "Level" +level;
        SceneManager.LoadScene(levelId);
        
    }

    public void OpenHighScore()
    {
        level.SetActive(false);
        highScore.SetActive(true);
    }
    public void returnLevel()
    {
        highScore.SetActive(false);
        level.SetActive(true);
    }
    public void returnMenu()
    {
        SceneManager.LoadScene("RegisterLogin");
    }
}
