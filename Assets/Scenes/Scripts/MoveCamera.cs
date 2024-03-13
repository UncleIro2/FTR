using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    //Sørge for at Kameraet altdi følger med spilleren 
    private void Update()
    {
        transform.position=cameraPosition.position;
    }

}
