using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyController : MonoBehaviour
{
    public static UnityEvent OnKeyCollection = new UnityEvent();
    private CapsuleCollider2D capsuleCol;
    private bool isDestroy = false;
    private void Awake()
    {
        OnKeyCollection.AddListener(KeyCollection);
        capsuleCol = GetComponent<CapsuleCollider2D>();
        capsuleCol.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            Debug.Log("ban nhan duoc chia khoa");
            isDestroy = true;
            Destroy(gameObject);
        }
    }
     private void KeyCollection()
    {
        capsuleCol.enabled = true;
        if (isDestroy)
        {
            GameManager.instance.countNumber += 1;
        }
        Debug.Log("Count: " + GameManager.instance.countNumber);
    }
}
