using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{

    public int Respawn;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("restart");
            Invoke("killPlayer", 0.2f);
        }

    }

    void killPlayer()
    {

        SceneManager.LoadScene("SampleScene");
    }
}

