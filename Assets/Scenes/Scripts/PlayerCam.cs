using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [Header("Sensitivity")]
    public float SensX;
    public float SensY;

    [Header("Player orintation ")]
    public Transform orientation;

    [Header("Cam rotation")]
    float xRotation;
    float yRotation;

    private void Start()
    {
        //Sørge for at musen altid er i midten af skærmen og at den er  usynlig  
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void Update()
    {
        //Mouse input 
        float mouseX = Input.GetAxisRaw("MouseX") * Time.deltaTime * SensX;
        float mouseY = Input.GetAxisRaw("MouseY") * Time.deltaTime * SensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        //Sørge for at man ikke kan kigge mere end 90 grader 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotere Cam og orientation 
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}

