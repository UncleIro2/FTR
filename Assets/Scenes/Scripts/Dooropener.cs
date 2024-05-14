using System.Collections;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using static EquipScript;
using static UnityEngine.GraphicsBuffer;

public class DoorOpen : MonoBehaviour
{
    public float range = 10f;
    public Camera Camera;
    public GameObject d�r;

    public D�r door;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && d�r != null && !door.isMoving)
        {
        
            door.ToggleDoor();
        }


      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("D�r"))
        {
            d�r = other.gameObject;
            door = d�r.GetComponent<D�r>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("D�r"))
        {
            d�r = null;
            door = null;
        }
    }
}
