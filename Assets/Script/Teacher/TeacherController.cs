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


    private void Awake()
    {
        
    }

    private void Update()
    {
        if (FindStudent() == true)
        {
           // Debug.Log("Da tim thay hoc sinh");

        }
        else
        {
           // Debug.Log("Lai tron roi");
        }
        
        setTarget.SetTarget(targetPatrol.targetWaypoint.transform); 
    }
    // Update is called once per frame
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, radius);
    }
    private bool FindStudent()
    {
        RaycastHit2D ray = Physics2D.CircleCast(transform.position, radius, (Vector2)transform.position, 0f, studentLayerMask);

        return ray;
    }
}
