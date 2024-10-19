using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(GameManager.instance.keyCollected == 5)
        {
            anim.SetTrigger("IsOpened");
        }
    }
}
