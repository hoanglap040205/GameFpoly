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
    [SerializeField] private TextMeshProUGUI feedbackText;
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
        if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord))
        {
            feedbackText.text = "Vui long nhap day du thong tin";
            return;
        }
        if (CheckUserExists(userName))
        {
            feedbackText.text = "Ten nguoi dung da ton tai!";
            return;
        }
        File.AppendAllText(filePath, userName + "\t" + passWord + "\n");
        feedbackText.text = "Dang ki thanh cong";
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
    /*private bool CheckLogin(string username, string password)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                if (data[0] == username && data[1] == password)
                {
                    return true;
                }
            }
        }
        return false;
    }*/
}
