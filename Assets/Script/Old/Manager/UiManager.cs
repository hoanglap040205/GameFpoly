using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField userName;
    [SerializeField] private TMP_InputField userNameSignIn;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_InputField passwordSignIn;
    [SerializeField] private TextMeshProUGUI feebBack;
    [SerializeField] private TextMeshProUGUI feebBackSignIn;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject register;
    [SerializeField] private GameObject login;
    [SerializeField] private GameObject quit;
    public DataUserManager dataManager;
    public static UiManager instanceUI;
    public string playerLogin;

    private void Awake()
    {
        if (instanceUI == null)
        {
            instanceUI = this;
        }
        DontDestroyOnLoad(instanceUI);
    }
    public void OnClickRegister()
    {
        
        string username = userName.text;
        string pass = password.text;
        if (dataManager.Register(username, pass))
        {
            feebBack.text = "Dang ki thanh cong";
            RegisterToLogin();
        }
        else
        {
            feebBack.text = "Dang ki khong thanh cong";
        }
    }

    public void OnClickLogin()
    {
        string username = userNameSignIn.text;
        string pass = passwordSignIn.text;
        if(username != null && pass != null)
        {
            if (dataManager.Login(username, pass))
            {
                playerLogin = username;
                feebBack.text = "Dang nhap thanh cong";
                SceneManager.LoadScene("LevelsManager");



            }
            else
            {
                feebBack.text = "Dang nhap khong thanh cong";
            }
        }
        else
        {
                feebBack.text = "Dang nhap khong thanh cong";
        }

    }

    public void OpenedRegister()
    {
        menu.SetActive(false);
        register.SetActive(true);
    }
    public void backMenuToRegiter()
    {
        menu.SetActive(true);
        register.SetActive(false);
    }
    public void OpenedLogin()
    {
        menu.SetActive(false);
        login.SetActive(true);
    }
    public void BackMenuToLogin()
    {
        login.SetActive(false);
        menu.SetActive(true);
    }
    private void RegisterToLogin()
    {
        register.SetActive(false);
        login.SetActive(true);

    }
    public void OpenedScreenQuit()
    {
        menu.SetActive(false);
        quit.SetActive(true);
    }

    public void No()
    {
        quit.SetActive(false);
        menu.SetActive(true);
    }
    public void Yes()
    {
        Debug.Log("Thoat Game");
    }
}
