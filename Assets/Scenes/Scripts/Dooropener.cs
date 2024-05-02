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
                if (hit.collider.CompareTag ("D�r"))
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

    void OpenDoor(GameObject d�r)
    {
        isOpening = true;
        // Calculate target rotation
        Quaternion targetRotation = Quaternion.Euler(0, 90, 0) * d�r.transform.rotation;
        Coroutine open = StartCoroutine(RotateDoor(d�r, targetRotation));
    }


    void CloseDoor(GameObject d�r)
    {
        isOpening = false;
        // Calculate target rotation
        Quaternion targetRotation = Quaternion.Euler(0, -90, 0) * d�r.transform.rotation;
        Coroutine open = StartCoroutine(RotateDoor(d�r, targetRotation));
    }

    private void wait()
    {
       isMoving = false;
    }

    IEnumerator RotateDoor(GameObject d�r, Quaternion targetRotation)
     {
        Quaternion startRotation = d�r.transform.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * rotationSpeed;
           d�r.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime);
            yield return null;
        }
        
        // Ensure the door reaches the exact target rotation
        d�r.transform.rotation = targetRotation;
     }
}
