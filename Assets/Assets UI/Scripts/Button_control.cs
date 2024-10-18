using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_control : MonoBehaviour
{
    [Header("Các màn hình")]
    public GameObject Account_screen;
    public GameObject Dang_nhap_screen;
    public GameObject Dang_ky_screen;
    public GameObject Quit_screen;
    public GameObject Menu_screen;
    public GameObject Setting_screen;
    public GameObject HighScores_screen;
    [Header("Các số scene")]
    public int Level_1_scene;
    public int Level_2_scene;
    public int Level_3_scene;



    //Nút ở màn hình đăng nhập đăng ký
    public void Dang_nhap() 
    {
        Account_screen.SetActive(false);
        Dang_nhap_screen.SetActive(true);
    }
    public void Dang_ky() 
    {
        Account_screen.SetActive(false);
        Dang_ky_screen.SetActive(true);
    }
    public void Quit()
    {
        Account_screen.SetActive(false);
        Quit_screen.SetActive(true);
    }
    //Nút ở màn hình thoát game
    public void Yes()
    {
        Application.Quit();
    }
    public void No()
    {
        Quit_screen.SetActive(false);
        Account_screen.SetActive(true);
    }
    //Nút ở màn hình đăng nhập
    public void Back_SignIn()
    {
        Dang_nhap_screen.SetActive(false);
        Account_screen.SetActive(true);
        Debug.Log("dung");
    }
    //Nút ở màn hình đăng ký
    public void Back_SignUp()
    {
        Dang_ky_screen.SetActive(false);
        Account_screen.SetActive(true);
    }
    //Nút ở màn hình menu
    public void Settings()
    {
        Menu_screen.SetActive(false);
        Setting_screen.SetActive(true);
    }
    public void HighScores()
    {
        Menu_screen.SetActive(false);
        HighScores_screen.SetActive(true);
    }
    public void Back_menu()
    {
        Menu_screen.SetActive(false);
        Account_screen.SetActive(true);
    }
    //Nút ở màn hình Levels
    public void Level_1()
    {
        SceneManager.LoadScene(Level_1_scene);
    }
    public void Level_2()
    {
        SceneManager.LoadScene(Level_2_scene);
    }
    public void Level_3()
    {
        SceneManager.LoadScene(Level_3_scene);
    }
    //Nút ở màn hình Setting
    public void Back_Setting()
    {
        Setting_screen.SetActive(false);
        Menu_screen.SetActive(true);
    }
    //Nút ở màn hình High score
    public void Back_HighScore()
    {
        HighScores_screen.SetActive(false);
        Menu_screen.SetActive(true);
    }
}
