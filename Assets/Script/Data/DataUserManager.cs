using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    private string filePath;

    private void Start()
    {
        
        filePath = Application.persistentDataPath + "/users.json";
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
        Debug.Log("Data will be stored at: " + filePath);
    }

    //Ham dang ki nguoi dung moi
    public bool Register(string username, string password)
    {
        if (UserExists(username))
        {
            Debug.Log("User already exists.");
            return false;
        }

        User newUser = new User(username, password);
        List<User> users = LoadUsersFromFile();
        users.Add(newUser);
        SaveUsersToFile(users);
        Debug.Log("User registered successfully.");
        return true;
    }

    // ham dang nhap
    public bool Login(string username, string password)
    {
        List<User> users = LoadUsersFromFile();

        foreach (var user in users)
        {
            if (user.username == username && user.password == password)
            {
                Debug.Log("Login successful.");
                return true;
            }
        }

        Debug.Log("Login failed. Incorrect username or password.");
        return false;
    }

    // Them du lieu man choi vao nguoi dung hien tai
    public void SaveLevelRecord(string username, int levelNumber, float timeSpent)
    {
        List<User> users = LoadUsersFromFile();

        foreach (var user in users)
        {
            if (user.username == username)
            {
                user.AddLevelRecord(levelNumber, timeSpent);
                SaveUsersToFile(users); // luu du lieu lai sau khi cap nhat
                Debug.Log("Level data saved successfully.");
                return;
            }
        }

        Debug.LogError("User not found.");
    }

    // Kiem tra nguoi dung ton tai hay chua
    private bool UserExists(string username)
    {
        List<User> users = LoadUsersFromFile();

        foreach (var user in users)
        {
            if (user.username == username)
            {
                return true;
            }
        }
        return false;
    }

    // luu danh sach vao file json
    private void SaveUsersToFile(List<User> users)
    {
        string json = JsonUtility.ToJson(new UserList(users), true);
        File.WriteAllText(filePath, json);
    }

    // Tai danh sach nguoi dung tu file json
    private List<User> LoadUsersFromFile()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            UserList userList = JsonUtility.FromJson<UserList>(json);
            return userList.users;
        }
        else
        {
            return new List<User>();
        }
    }

    // Class luu danh sach nguoi dung cho viec chuyen doi json
    [System.Serializable]
    private class UserList
    {
        public List<User> users;

        public UserList(List<User> users)
        {
            this.users = users;
        }
    }
    /*public void OnLevelCompleted(string username, int levelNumber, float timeSpent)
    {
        userManager.SaveLevelRecord(username, levelNumber, timeSpent);
    }*/
}
