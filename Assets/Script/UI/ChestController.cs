using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private BoxCollider2D boxCol;
    private CapsuleCollider2D capCol;
    private Animator anim;
    private bool isPlayerInRange;//Kiem tra xem player co trong khu vuc co the mo ruong khong
    private bool isPlayerInchest =false;//kiem tra xem player co trong ruong khong
    private void Awake()
    {
        boxCol = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!isPlayerInchest)//nguoi choi co the vao ruong
                {
                    StudentController.EnterChestEvent.Invoke();

                    isPlayerInchest = !isPlayerInchest;//nguoi choi dang o trong ruong 
                }
            }
        }else if (!isPlayerInRange && isPlayerInchest && Input.GetKeyDown(KeyCode.F))
        {
            StudentController.ExitChestEvent.Invoke();
            isPlayerInchest = !isPlayerInchest;//nguoi choi thoat ra khoi ruong
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            isPlayerInRange = true;
            anim.SetTrigger("Opened");
            KeyController.OnKeyCollection.Invoke();
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
