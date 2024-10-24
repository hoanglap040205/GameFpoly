using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectterController : MonoBehaviour
{
    private List<string> collectedletter = new List<string>();
    private string targetWord;

    private void Start()
    {
        targetWord = "FPOLY";
    }
    private void Update()
    {
        CheckCollectedWord();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string word = gameObject.name.ToUpper();
        if(collectedletter.Contains(word) && targetWord.Contains(word))
        {
            collectedletter.Add(word);
            Debug.Log("Chu cai thu nhap duoc");
            CheckCollectedWord();
            Destroy(gameObject);
        }
    }

    private void CheckCollectedWord()
    {
        if (collectedletter.Count == targetWord.Length)
        {
            Debug.Log("Da thu nhap du.");

        }
        else
        {
            Debug.Log("Chua thu thap du");
        }
    }



}
