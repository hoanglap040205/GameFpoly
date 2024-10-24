using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterColector : MonoBehaviour
{
    private List<string> letterCollector = new List<string>();
    private string targetWord;
    [SerializeField] private TextMeshProUGUI textCollected;
    private void Start()
    {
        targetWord = "FPOLY";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        string letter = collision.name.ToUpper();
        Debug.Log(letter);
        if (!letterCollector.Contains(letter) && targetWord.Contains(letter))
        {
            letterCollector.Add(letter);
            Debug.Log(collision.gameObject);
            CheckCollectedWord();
          //  UpdateCollectedLettersUI();
            Destroy(collision.gameObject);
        }
    }
  /*  private void UpdateCollectedLettersUI()
    {
        foreach (string letter in letterCollector)
        {
            textCollected.text += letter + " ";
        }
    }*/

    private void CheckCollectedWord()
    {
        if(letterCollector.Count == targetWord.Length)
        {
            Debug.Log("Ban da co du chia khoa");
        }
    }
}
