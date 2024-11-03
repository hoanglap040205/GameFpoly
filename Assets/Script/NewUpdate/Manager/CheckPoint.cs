using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D boxCol;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCol = GetComponent<BoxCollider2D>();
        boxCol.enabled = false;
    }
    private void Update()
    {
        if(LetterUIController.instance.countBee == 5)
        {
            anim.SetTrigger("AppearBee");
            StartCoroutine(EnabledCol());
        }
    }


    IEnumerator EnabledCol()
    {
        yield return new WaitForSeconds(4);
        boxCol.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            GameManager.gameWinEvent.Invoke();
        }
    }
}
