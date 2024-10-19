using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField userName;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TextMeshProUGUI feebBack;
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
        }
        else
        {
            feebBack.text = "Dang ki khong thanh cong";
        }
    }

    public void OnClickLogin()
    {
        string username = userName.text;
        string pass = password.text;
        if(dataManager.Login(username, pass))
        {
            playerLogin = username;
            feebBack.text = "Dang nhap thanh cong";
            SceneManager.LoadScene("wall");


        }
        else
        {
            feebBack.text = "Dang nhap khong thanh cong";
        }
    }
}
