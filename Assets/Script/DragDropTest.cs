using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropTest : MonoBehaviour
{
    private CapsuleCollider2D cap;
    private void Awake()
    {
        cap = GetComponent<CapsuleCollider2D>();
    }
    private void OnMouseDrag()
    {
        transform.position = GetMousePos();
        Debug.Log("onClick");
    }

    Vector3 GetMousePos()
    {
      var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Debug.Log("Cham");
            Destroy(collision.gameObject);
        }

    }


}
