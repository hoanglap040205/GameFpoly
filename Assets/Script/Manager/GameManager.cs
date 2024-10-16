using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int countNumber = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


}
