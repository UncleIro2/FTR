using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{

    public int Respawn;
    void OnTriggerEnter(Collider other)
    {
        Invoke("killPlayer", 0.5f);

    }

    void killPlayer()
    {
        
            SceneManager.LoadScene("SampleScene");
    }
}
