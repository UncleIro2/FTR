using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    //S�rge for at Kameraet altdi f�lger med spilleren 
    private void Update()
    {
        transform.position=cameraPosition.position;
    }

}
