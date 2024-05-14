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
    public GameObject dør;

    public Dør door;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && dør != null && !door.isMoving)
        {
        
            door.ToggleDoor();
        }


      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dør"))
        {
            dør = other.gameObject;
            door = dør.GetComponent<Dør>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Dør"))
        {
            dør = null;
            door = null;
        }
    }
}
