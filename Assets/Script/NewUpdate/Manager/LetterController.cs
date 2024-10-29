using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyController : MonoBehaviour
{
   // UnityEvent CollectedwordEvent = new UnityEvent();
    private BoxCollider2D boxCol;
    private bool isPlayerInRange;//Kiem tra nguoi choi co trong khu vuc nhat chia khoa khong
    [SerializeField] private float timeCollectedKey;
    [SerializeField] private float timer;
    private string word;
    public GameObject timebar;
    private void Awake()
    {
        timeCollectedKey = 0f;
        timer = 2f;
        boxCol = GetComponent<BoxCollider2D>();
        word = gameObject.name.ToUpper();
    }

    private void Update()
    {
        if (gameObject != null && timebar != null)
        {
            if (Input.GetKey(KeyCode.Space) && isPlayerInRange)
            {
                StartCoroutine(CheckWords());
            }
            else
            {
                timebar.SetActive(false);
            }
        }
    }

     IEnumerator CheckWords()
    {
        timebar.SetActive(true);
        yield return new WaitForSeconds(timer);

        if (!GameManager.instance.words.Contains(word))
        {
            GameManager.instance.words.Add(word);
            LetterUIController.instance.DisplayLetter(word);
        }
        Destroy(gameObject, 0.5f);
        Destroy(timebar);
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

