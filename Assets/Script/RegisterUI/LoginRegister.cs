using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class LoginRegister : MonoBehaviour
{
    [SerializeField] private TMP_InputField userNameInputField;
    [SerializeField] private TMP_InputField passWordInputField;
    [SerializeField] private TMP_InputField checkPassWordInputField;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private GameObject reGisTerPanel;
    [SerializeField] private GameObject logInPanel;

    private string filePath;

    private void Start()
    {
        filePath = "C:\\Users\\Admin\\Desktop\\Poject\\GameFpoly\\Assets\\DataUser\\UserData.txt";
        /*if (!File.Exists(filePath))
        {
            
            File.Create(filePath).Close();
        }*/
        Debug.Log("Persistent Data Path: " + Application.persistentDataPath);
    }
    public void Register()
    {
        string userName = userNameInputField.text;
        string passWord = passWordInputField.text;
        string checkPassWord = checkPassWordInputField.text;
        if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord) )
        {
            feedbackText.text = "Vui long nhap day du thong tin";
            return;
        }
        if(checkPassWord != passWord)
        {
            feedbackText.text = "Mat khau xac nhan sai";
            return;
        }
        
        if (CheckUserExists(userName))
        {
            feedbackText.text = "Ten nguoi dung da ton tai!";
            return;
        }
        File.AppendAllText(filePath, userName.ToLower() + "\t" + passWord.ToLower() + "\n");
        feedbackText.text = "Dang ki thanh cong";
    }
    public void LogIn()
    {
        string userName = userNameInputField.text;
        string passWord = passWordInputField.text;
        Debug.Log("yess");
        if (string.IsNullOrEmpty(userName)|| string.IsNullOrEmpty(passWord))
        {
            feedbackText.text = "Vui long nhap du thong tin";
            return;
        }
        if(CheckLogin(userName, passWord))
        {
            feedbackText.text = "Dang nhap thanh cong";
            //Chuyen vao Scene man choi;
        }else
        {
            feedbackText.text = "Thong tin tai khoan hoac mat khau khong chin xac";
        }
    }
    private bool CheckUserExists(string userName)
    {
        string[] lines = File.ReadAllLines(filePath);
        foreach(string line in lines)
        {
            string[] data = line.Split('\t');
            if (data[0] == userName)
            {
                return true;
            }
        }
        return false;
    }
    public void FinishReGisTer()
    {
        reGisTerPanel.SetActive(false);
        logInPanel.SetActive(true);
    }
    public void OpenPanelRegister()
    {
        logInPanel.SetActive(false);
        reGisTerPanel.SetActive(true);
    }
    private bool CheckLogin(string username, string password)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] data = line.Split('\t');
                if (data[0].ToLower() == username && data[1].ToLower() == password.ToLower())
                {
                    return true;
                }
            }
        }
        return false;
    }
}
