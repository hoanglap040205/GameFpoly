using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public float startStamina;
    public float currentStamina;
    private bool isCatching = false;

    private void Awake()
    {
        currentStamina = startStamina;
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
        else if (currentStamina <= 0 && !isCatching)
        {
            Debug.Log("het the luc roi");
        }
        else if(currentStamina <= 0 && isCatching)
        {
            
            Debug.Log("bi bat");
        }
        
    }

    public void AddStamina(float _staminaCollectionAmount)
    {
        currentStamina = Mathf.Clamp(currentStamina + _staminaCollectionAmount, 0, 100);

    }


}
