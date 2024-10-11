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


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        cirCol = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        MoveMent();
    }
    private void MoveMent()
    {
        inPutHorizontal = Input.GetAxisRaw("Horizontal");
        inPutvertical = Input.GetAxisRaw("Vertical");
             rigid.velocity = new Vector2(inPutHorizontal, inPutvertical).normalized * moveSpeed;
    }


}
