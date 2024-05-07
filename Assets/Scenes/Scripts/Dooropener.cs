using System.Collections;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using static UnityEngine.GraphicsBuffer;

public class DoorOpen : MonoBehaviour
{
    public float range = 10f;
    public Camera Camera;
    private RaycastHit hit;

    public D�r door;


    void Update()
    {
        Vector3 rayDoorCheck = Camera.transform.forward; // Use camera's forward direction
        if (Physics.Raycast(Camera.transform.position, rayDoorCheck, out hit, range))
        {
            if (hit.collider.CompareTag("D�r"))
            {
                door = hit.collider.gameObject.GetComponent<D�r>();
                
            }
        }


        if (Input.GetKeyDown(KeyCode.E) && !door.isMoving)
        {


            Vector3 raycastDirection = Camera.transform.forward; // Use camera's forward direction
            if (Physics.Raycast(Camera.transform.position, raycastDirection, out hit, range))
            {
                if (hit.collider.CompareTag("D�r"))
                {
                    hit.collider.gameObject.GetComponent<D�r>().ToggleDoor();
                }
            }

        }
    }
  
}
