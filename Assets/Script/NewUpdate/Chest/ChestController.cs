using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private BoxCollider2D boxCol;
    private bool isPlayerInRange;//Kiem tra xem player co trong khu vuc co the mo ruong khong
    private bool isPlayerInchest =false;//kiem tra xem player co trong ruong khong
    private GameObject player;
    private void Awake()
    {
        boxCol = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("player");
    }
    //Them chuc nang nhan giu de mo ruong
    //Nhan giu du 5s thi ruong open
    private void Update()
    {
        if (isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!isPlayerInchest)//nguoi choi co the vao ruong
                {
                    StartCoroutine(EnterBee());
                }
            }
        }else if (!isPlayerInRange && isPlayerInchest && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(ExitBee());
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
    IEnumerator EnterBee()
    {
        yield return new WaitForSeconds(0.2f);
        StudentController.EnterChestEvent.Invoke();
        isPlayerInchest = !isPlayerInchest;//nguoi choi dang o trong ruong 
    }
     IEnumerator ExitBee()
    {
        yield return new WaitForSeconds(0.2f);
            StudentController.ExitChestEvent.Invoke();
        isPlayerInchest = !isPlayerInchest;//nguoi choi thoat ra khoi ruong

    }


}
