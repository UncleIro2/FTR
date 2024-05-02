using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dør : MonoBehaviour
{
    public bool isOpen = false;
    public bool isMoving = false;
    public float rotationSpeed = 2f; // Adjust as needed

    public void ToggleDoor()
    {
        Quaternion targetRotation = Quaternion.Euler(0, isOpen ? -90 : 90, 0) * this.transform.rotation;
        if (!isMoving) 
        { 
            StartCoroutine(RotateDoor(targetRotation));
            
        }

        isOpen = !isOpen;


    }

    

    IEnumerator RotateDoor(Quaternion targetRotation)
    {
        Quaternion startRotation = this.transform.rotation;
        float elapsedTime = 0f;
    
        while (elapsedTime < 1f)
        {
            isMoving = true;
            elapsedTime += Time.deltaTime * rotationSpeed;
            this.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime);
            yield return null;
            isMoving = false;        

        }

     

        // Ensure the door reaches the exact target rotation
        this.transform.rotation = targetRotation;
    }

}
