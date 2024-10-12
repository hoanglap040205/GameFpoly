using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentController : MonoBehaviour
{
    private Rigidbody2D rigid;
    private CircleCollider2D cirCol;
    [SerializeField] private float moveSpeed;
    private float inPutHorizontal;
    private float inPutvertical;
    private float accelerate = 1;
    [SerializeField] private float timeAccelerate = 3f;
    [SerializeField] private float timeAccelerateCoolDown = 5f;
    private Stamina stamina;
    //private bool isAccelerate;



    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        cirCol = GetComponent<CircleCollider2D>();
        stamina = GetComponent<Stamina>();

    }
    private void Update()
    {
        Accelerate();
       
        MoveMent();
    }
    private void MoveMent()
    {
        inPutHorizontal = Input.GetAxisRaw("Horizontal");
        inPutvertical = Input.GetAxisRaw("Vertical");
        rigid.velocity = new Vector2(inPutHorizontal, inPutvertical).normalized * moveSpeed * accelerate;
    }

    private void Accelerate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && stamina.GetComponent<Stamina>().currentStamina >0f)
        {
            accelerate = 1.5f;
            Debug.Log("dang tang toc");
            stamina.GetComponent<Stamina>().TakeStamina(Time.deltaTime);

            //isAccelerate = true;
            //The luc trong 5s
            //toi da co the dung the luc trong khoang 5s het thi hoi theo thoi gian
        }
        else
        {
            //isAccelerate = false;
        }
    }


}
