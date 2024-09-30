using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask studentLayerMask;
    private Transform CurrentTarget;
    [SerializeField] private Transform PointA;
    [SerializeField] private Transform PointB;
    [SerializeField] private Rigidbody2D Rigid;
    [SerializeField] private CircleCollider2D circlecol;

    private void Awake()
    {
       CurrentTarget = PointB.transform;
    }
    private void Update()
    {
        if(FindStudent() == true)
        {
            Debug.Log("Da tim thay hoc sinh");

        }
        
        
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, radius);
    }
    private bool FindStudent()
    {
        RaycastHit2D ray = Physics2D.CircleCast(transform.position, radius,(Vector2)transform.position,0f,studentLayerMask);

        return ray;
    }
   
}