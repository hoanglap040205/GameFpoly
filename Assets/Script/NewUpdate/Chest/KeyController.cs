using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private BoxCollider2D boxCol;
    private bool isPlayerInRange;//Kiem tra nguoi choi co trong khu vuc nhat chia khoa khong
    [SerializeField] private float timeCollectedKey;
    [SerializeField] private float timer;
    private string word;
    private string targetWord = "FPOLY";
    public GameObject timebar;

    private void Awake()
    {
        timeCollectedKey = 0f;
        timer = 8f;
        boxCol = GetComponent<BoxCollider2D>();
        word = gameObject.name.ToUpper();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isPlayerInRange)
        {
            timebar.SetActive(true);
            timer -= Time.deltaTime;
            Debug.Log(timer);
            if (timer <= timeCollectedKey)
            {
                Debug.Log("Da lay duoc chia khoa " + word);
                if (!GameManager.instance.words.Contains(word))
                {
                    GameManager.instance.words.Add(word);
                }
                Destroy(gameObject, 0.5f);
                Destroy(timebar);
            }
        }
        else
        {
            timebar.SetActive(false);
        }

        if(GameManager.instance.words.Count == targetWord.Length)
        {
            if(Time.deltaTime >0.5f)
            GameManager.gameWinEvent.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            isPlayerInRange = true;
            

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            isPlayerInRange = false;
        }
    }

    
}
