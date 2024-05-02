using System.Collections;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DoorOpen : MonoBehaviour
{
    public float range = 10f;
    public bool isOpening = false;
    public bool isMoving = false;
    public Camera Camera;
    private RaycastHit hit;
    public float rotationSpeed = 2f; // Adjust as needed






    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isMoving)
        {
            isMoving = true;
            Invoke("wait", 0.5f);

            Vector3 raycastDirection = Camera.transform.forward; // Use camera's forward direction
            if (Physics.Raycast(Camera.transform.position, raycastDirection, out hit, range))
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.CompareTag ("Dør"))
                {
                   
                    if (!isOpening)
                    {
                        OpenDoor(hit.collider.gameObject);
                        
                    }
                    else 
                    {
                        CloseDoor(hit.collider.gameObject);
                        

                    }
                }
            }
        }
    }

    void OpenDoor(GameObject dør)
    {
        isOpening = true;
        // Calculate target rotation
        Quaternion targetRotation = Quaternion.Euler(0, 90, 0) * dør.transform.rotation;
        Coroutine open = StartCoroutine(RotateDoor(dør, targetRotation));
    }


    void CloseDoor(GameObject dør)
    {
        isOpening = false;
        // Calculate target rotation
        Quaternion targetRotation = Quaternion.Euler(0, -90, 0) * dør.transform.rotation;
        Coroutine open = StartCoroutine(RotateDoor(dør, targetRotation));
    }

    private void wait()
    {
       isMoving = false;
    }

    IEnumerator RotateDoor(GameObject dør, Quaternion targetRotation)
     {
        Quaternion startRotation = dør.transform.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * rotationSpeed;
           dør.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime);
            yield return null;
        }
        
        // Ensure the door reaches the exact target rotation
        dør.transform.rotation = targetRotation;
     }
}
