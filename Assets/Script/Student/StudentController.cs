using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class myEvent : UnityEvent
{

}

public class StudentController : MonoBehaviour
{
    public static myEvent EnterChestEvent = new myEvent();
    public static myEvent ExitChestEvent = new myEvent();

    private Rigidbody2D rigid;
    private CircleCollider2D cirCol;
    private Animator anim;

    [SerializeField] private float moveSpeed;//toc do chay
    private float inPutHorizontal;
    private float inPutvertical;
    private float accelerate = 1;//tang toc
    public bool canMove;

    private Stamina stamina;
    public TeacherController teacher;



    private void Awake()
    {
        EnterChestEvent.AddListener(EnterChest);
        ExitChestEvent.AddListener(ExitChest);

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        cirCol = GetComponent<CircleCollider2D>();
        stamina = GetComponent<Stamina>();
        canMove = true;
    }
    private void Update()
    {
        Accelerate();
        if(canMove)
        {
            MoveMent();
        }
       

    }
    private void MoveMent()
    {
        inPutHorizontal = Input.GetAxisRaw("Horizontal");
        inPutvertical = Input.GetAxisRaw("Vertical");
        rigid.velocity = new Vector2(inPutHorizontal, inPutvertical).normalized * moveSpeed * accelerate;
    }

    private void Accelerate()
    {
        //fix loi kiem tra stamina

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(stamina.currentStamina > 0)
            {
                accelerate = 1.5f;
                Debug.Log("dang tang toc");
                stamina.TakeStamina(Time.deltaTime);
            }
            else
            {
                stamina.TakeStamina(Time.deltaTime);

            }


        }
        else
        {
            accelerate = 1f;

        }
    }
    //nguoi choi chui vao trong ruong
    private void EnterChest()
    {
        anim.SetTrigger("EnterChest");
        canMove = false;
        cirCol.enabled = false;
    }
    private void ExitChest()
    {
        cirCol.enabled = true;
        canMove = true;
        anim.SetTrigger("ExitChest");
    }
    




}
