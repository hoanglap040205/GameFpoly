using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class TeacherController : MonoBehaviour
{
    
    [Header("Component")]
    private Animator anim;
    private AIDestinationSetter setTarget;
    private PatrolTeacher targetPatrol;
    private AIPath ai;

    [Header("Reference")]
    public StudentController student;
    [Header("properties")]
    [SerializeField] private float radius;//ban kinh phat hien nguoi choi
    [SerializeField] private float speedmax;
    private float timeChase = 0f;//thoi gian duoi theo nguoi choi
    private bool isChase;
    private void Awake()
    {
        anim =         GetComponent<Animator>();
        targetPatrol = GetComponent<PatrolTeacher>();
        setTarget =    GetComponent<AIDestinationSetter>();
        ai =           GetComponent<AIPath>();
        isChase =      false;
        speedmax =     6.5f;
        setTarget.SetTarget(targetPatrol.targetWaypoint.transform);

    }

    private void Update()
    {
        ChasePlayer();
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, radius);
    }
    private bool CheckDistanceToPlayer()
    {
        if(Vector2.Distance(transform.position,student.transform.position) < radius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void ChasePlayer()
    {
        if (CheckDistanceToPlayer())
        {
            timeChase = 3f;
            setTarget.SetTarget(student.transform);
            anim.SetBool("IsChase", true);
            isChase = !isChase;
            if (isChase && ai.maxSpeed <= speedmax)
            {
                ai.maxSpeed += (Time.deltaTime /2);
            }
        }
        else
        {
            
            if(timeChase > 0)
            {
                timeChase -= Time.deltaTime;
                setTarget.SetTarget(student.transform);
                anim.SetBool("IsChase", true);
            }
            else
            {
                isChase = !isChase;
                setTarget.SetTarget(targetPatrol.targetWaypoint.transform);
                anim.SetBool("IsChase", false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            student.canMove = false;
            StartCoroutine(HasBeenCaughtPlayer());
        }
    }
    IEnumerator HasBeenCaughtPlayer()
    {
        ai.canMove = false;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
        GameManager.gameOverEvent.Invoke();
    }



}
