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
    private Stamina stamina;
    public TeacherController teacher;
    public bool isCatched;



    private void Awake()
    {
        isCatched = teacher.isCatchStudent;
        rigid = GetComponent<Rigidbody2D>();
        cirCol = GetComponent<CircleCollider2D>();
        stamina = GetComponent<Stamina>();
    }
    private void Update()
    {
        isCatched = teacher.isCatchStudent;
        Accelerate();
        if (!teacher.isCatchStudent)
        {
            MoveMent();
        }
        //MoveMent();


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
            accelerate = 1f;

        }
    }

    /*public bool Canmove()
    {
        return true;
    }*/


}
