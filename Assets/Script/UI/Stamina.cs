using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public float startStamina;
    public float currentStamina;
    private bool isCatching = false;
    private StudentController student;
    private void Awake()
    {
        currentStamina = startStamina;
        student = GetComponent<StudentController>();
    }
    private void Update()
    {
        
        /*if (Input.GetKey(KeyCode.F))
        {
            TakeStamina();
        }*/
        


    }
    public void TakeStamina(float _StaminaAmount)
    {
        if (currentStamina > 0)
        {
            
            currentStamina = Mathf.Clamp(currentStamina - _StaminaAmount, 0, 100);
        }
        else if (currentStamina <= 0 && !student.isCatched)
        {
            Debug.Log("het the luc roi");
        }
        else if(currentStamina <= 0 && student.isCatched)
        {
            
            Debug.Log("bi bat");
        }
        
    }

    public void AddStamina(float _staminaCollectionAmount)
    {
        currentStamina = Mathf.Clamp(currentStamina + _staminaCollectionAmount, 0, 100);

    }


}
