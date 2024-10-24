using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class TeacherController : MonoBehaviour
{
    private Animator anim;

    public AIDestinationSetter setTarget;
    public StudentController student;
    [SerializeField] PatrolTeacher targetPatrol;

    [SerializeField] private float radius;//ban kinh phat hien nguoi choi
    private float timeChase = 0f;//thoi gian duoi theo nguoi choi
    private float timeChaserToCatchPlayer = 1.5f;//thoi gian de bat giu nguoi choi
    [SerializeField] private LayerMask studentLayerMask;
   // public AIPath ai;

    private void Awake()
    {
        //student = GetComponent<StudentController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //fix thoi gian kiem 0.5f tim mot lan

        if (CheckPlayerIsInRange() == true)
        {
            anim.SetBool("IsChase", true);
            timeChase = 2f;
            setTarget.SetTarget(student.transform);
            timeChaserToCatchPlayer -= Time.deltaTime;
            if (timeChaserToCatchPlayer <= 0f)
            {
                PlayerHasBeenCaught();
               // ai.canMove = false;
                GameManager.gameOverEvent.Invoke();
            }
        }
        else
        {
           //Debug.Log("Lai tron roi");
            if (timeChase > 0)
            {
                setTarget.SetTarget(student.transform);
                timeChase -= Time.deltaTime;
                anim.SetBool("IsChase", true);
                timeChaserToCatchPlayer = 1f;
            }
            else
            {
                setTarget.SetTarget(targetPatrol.targetWaypoint.transform);
                anim.SetBool("IsChase", false);
                timeChaserToCatchPlayer = 1f;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, radius);
    }
    
    private bool CheckPlayerIsInRange()
    {
        RaycastHit2D ray = Physics2D.CircleCast(transform.position, radius, Vector2.zero, 0f, studentLayerMask);
        return ray.collider != null;
    }

    //Tat chuc nang di chuyen cua nguoi choi khi bi bat
    private void PlayerHasBeenCaught()
    {
       student.GetComponent<StudentController>().canMove = false;
        
    }
    



     
}
