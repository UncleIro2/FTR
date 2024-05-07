using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioClip interactionSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
         
            Debug.Log("Collision detected");

         
            if (interactionSound != null && Input.GetKeyDown(KeyCode.E))
            {
               
                Debug.Log("E key pressed");
                AudioSource.PlayClipAtPoint(interactionSound, transform.position);
            }
        }
    }
}

