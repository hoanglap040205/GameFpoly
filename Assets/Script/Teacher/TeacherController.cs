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
    public AIDestinationSetter setTarget;
    public StudentController student;
    private float timeChase = 0f;


    private void Awake()
    {
        
    }

    private void Update()
    {
        if (FindStudent() == true)
        {
            timeChase = 2f;
            setTarget.SetTarget(student.transform);


        }
        else
        {
           Debug.Log("Lai tron roi");
            
            if (timeChase > 0)
            {
                setTarget.SetTarget(student.transform);
                timeChase -= Time.deltaTime;
            }
            else
            {
                setTarget.SetTarget(targetPatrol.targetWaypoint.transform);
            }

            
            
        }
        
       
    }
    // Update is called once per frame
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
