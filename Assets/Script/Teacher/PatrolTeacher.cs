using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolTeacher : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float Speed;
    private Transform currentTarget;
    public bool isPatrol = true;
    private void Awake()
    {
        currentTarget = pointB.transform;
    }
    private void Update()
    {
        if (isPatrol)
        {
            Patrol();
        }
        
    }
    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, Speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, currentTarget.position) < 0.5f && currentTarget == pointA.transform)
        {
            currentTarget = pointB;
        }
        else if (Vector2.Distance(transform.position, currentTarget.position) < 0.5f && currentTarget == pointB.transform)
        {
            currentTarget = pointA;
        }
    }
}
