using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IldSound : MonoBehaviour
{
    public AudioClip fireSound;
    private float timeSinceLast;

    private void Start()
    {
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
        timeSinceLast = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timeSinceLast >= fireSound.length)
        {
            AudioSource.PlayClipAtPoint(fireSound, transform.position);
            timeSinceLast = Time.time;
        }        
    }
}
