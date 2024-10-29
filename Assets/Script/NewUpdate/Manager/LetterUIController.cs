using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class LetterUIController : MonoBehaviour
{
    [SerializeField] GameObject panelLetter;
    [SerializeField] Animator anim;
    [SerializeField] private float timer;
    [SerializeField] private Image[] letters;
    //private bool isOpened;
    public static LetterUIController instance;
    private Color lerpColor;


    private void Start()
    {
        lerpColor = Color.black;
        for(int i = 0; i < letters.Length; i++)
        {
            letters[i].color = lerpColor;
        }
        if (instance == null)
        {
            instance = this;
        }
        StartCoroutine(ClosedPanel());
    }
    IEnumerator OpenedPanel()
    {
        yield return new WaitForSeconds(1f);
        panelLetter.SetActive(true);
        anim.SetTrigger("Opened");
        if (GameManager.instance.IsGameWin())
        {
            Debug.Log("WinGame");
            StartCoroutine(CollectedAll());
        }
        else
        {
            StartCoroutine(ClosedPanel());
        }
    }
    IEnumerator ClosedPanel()
    {
        yield return new WaitForSeconds(2f);
        anim.SetTrigger("Closed");
        yield return new WaitForSeconds(1.3f);
        panelLetter.SetActive(false);
    }IEnumerator CollectedAll()
    {
        yield return new WaitForSeconds(2f);
        anim.SetTrigger("CollectedAll");
        yield return new WaitForSeconds(1.3f);
        StartCoroutine(ClosedPanel());
    }
    //Khi thu nhap mot word thi anim opened va chu do se duoc to mau
    public void DisplayLetter(string wordCollected)
    {
        foreach(var letter in letters)
        {
            if(letter.name == wordCollected)
            {
                letter.color = Color.Lerp(Color.black,Color.white,1f);
                StartCoroutine(OpenedPanel());
                Debug.Log(2);
            }
        }
    }









}
