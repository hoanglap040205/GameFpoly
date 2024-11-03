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
    private CircleCollider2D cirC;

    [Header("Reference")]
    public StudentController student;
    [Header("properties")]
    [SerializeField] private float radius;//ban kinh phat hien nguoi choi
    [SerializeField] private float moveSpeed;
    [SerializeField] private float speedmax;//toc do toi da enemy co the dat toi
    private float timeChase = 0f;//thoi gian duoi theo nguoi choi
    [SerializeField]private LayerMask playerLayer;
    [SerializeField]private AudioClip audio;
    private void Awake()
    {
        moveSpeed = 3f;
        anim =         GetComponent<Animator>();
        cirC =         GetComponent<CircleCollider2D>();
        targetPatrol = GetComponent<PatrolTeacher>();
        setTarget =    GetComponent<AIDestinationSetter>();
        ai =           GetComponent<AIPath>();
        speedmax =     3f;

    }
    private void Start()
    {
        setTarget.SetTarget(targetPatrol.targetWaypoint.transform);
        ai.maxSpeed = moveSpeed;
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

    private void ChasePlayer()
    {
        if (CheckPlayerInRange())
        {
            if (SoundManager.instance != null)
            {
                SoundManager.instance.PlaySound(audio);
            }
            else
            {
                Debug.Log("Chua duoc khoi tao");
            }
            timeChase = 3f;
            setTarget.SetTarget(student.transform);
            anim.SetBool("IsChase", true);
            if (ai.maxSpeed <= speedmax)
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
                SoundManager.instance.StopSound();
                ai.maxSpeed = moveSpeed;
                setTarget.SetTarget(targetPatrol.targetWaypoint.transform);
                anim.SetBool("IsChase", false);
            }
        }
    }
    private bool CheckPlayerInRange()
    {
        RaycastHit2D ray = Physics2D.CircleCast(transform.position, radius, Vector2.zero, 0f, playerLayer);
        return ray.collider != null;
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
        ai.maxSpeed = 0;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
        GameManager.gameOverEvent.Invoke();
    }



}
