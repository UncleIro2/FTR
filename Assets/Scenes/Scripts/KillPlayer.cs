using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
 




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Invoke("Respawn", 1f);


        }


    }

    public void Respawn()
    {
        SceneManager.LoadScene("sampleScene");

    }


}

