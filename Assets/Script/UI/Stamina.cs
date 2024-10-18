using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public float startStamina;
    public float currentStamina;
    private StudentController student;
    private void Awake()
    {
        currentStamina = startStamina;
        student = GetComponent<StudentController>();
    }
    
    public void TakeStamina(float _StaminaAmount)
    {
        if (currentStamina > 0)
        {
            
            currentStamina = Mathf.Clamp(currentStamina - _StaminaAmount, 0, 100);
            Debug.Log("the luc con lai " + currentStamina);
           // Debug.Log("Dang tru the luc");
        }
        else if (currentStamina <= 0)
        {
            Debug.Log("Het the luc");
            HandleOutOfStamina();
        }
        
        
    }
    private void HandleOutOfStamina()
    {
        if (student.canMove)
        {
            Debug.Log("het stamina");
        }
        else if (!student.canMove)
        {
            GameManager.gameOverEvent.Invoke();
        }
    }
    public void AddStamina(float _staminaCollectionAmount)
    {
        currentStamina = Mathf.Clamp(currentStamina + _staminaCollectionAmount, 0, 100);

    }


}
