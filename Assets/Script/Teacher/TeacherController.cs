using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TeacherController : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask studentLayerMask;
    [SerializeField] PatrolTeacher targetPatrol;
    private Animator anim;
    public AIDestinationSetter setTarget;
    public StudentController student;
    private float timeChase = 0f;
    private float timeChaserToCatchPlayer = 2f;
    public bool isCatchStudent;


    private void Awake()
    {
        isCatchStudent = false;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (FindStudent() == true)
        {
            timeChase = 2f;
            setTarget.SetTarget(student.transform);
            anim.SetBool("IsChase",true);
            timeChaserToCatchPlayer -= Time.deltaTime;
            if(timeChaserToCatchPlayer <= 0f)
            {
                Debug.Log("Tum duoc roi");
                isCatchStudent = true;
                
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
    private bool FindStudent()
    {
        RaycastHit2D ray = Physics2D.CircleCast(transform.position, radius, Vector2.zero, 0f, studentLayerMask);
        

        return ray.collider != null;
    }
}
