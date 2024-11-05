using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StudentController : MonoBehaviour
{
    [Header("Event")]
    public static UnityEvent EnterChestEvent = new UnityEvent();
    public static UnityEvent ExitChestEvent = new UnityEvent();

    [Header("Componet")]
    private Rigidbody2D rigid;
    private CircleCollider2D cirCol;
    private Animator anim;
    private Stamina stamina;

    [Header("Properties")]
    [SerializeField] private float moveSpeed;//toc do chay
    private float inPutHorizontal;//Dau vao truc hoanh
    private float inPutvertical;//Dau vao truc tung
    private float accelerate = 1;//tang toc
    public bool canMove;//co the di chuyen

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
        if(canMove)
        {
            Accelerate();
            MoveMent();
        }
        else
        {
            rigid.velocity = Vector2.zero;
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(inPutHorizontal != 0 || inPutvertical != 0)
            {
                if (stamina.TakeStamina(Time.deltaTime))
                {
                    accelerate = 1.5f;
                    Debug.Log("dang tang toc");
                }
                else
                {
                    Debug.Log("Het nang luong");
                }
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
        canMove = false;
        rigid.velocity = Vector2.zero;
        anim.SetTrigger("EnterChest");
        cirCol.enabled = false;
    }
    private void ExitChest()
    {
        anim.SetTrigger("ExitChest");
        canMove = true;
        cirCol.enabled = true;
    }
}
