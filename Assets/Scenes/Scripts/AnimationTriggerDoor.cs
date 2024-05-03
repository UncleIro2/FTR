using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggerDoor : MonoBehaviour
{
[SerializeField] private Animator myDoor=null; 

[SerializeField] private bool openTrigger = false;
[SerializeField] private bool closeTrigger = false;

private void OnTriggerEnter(Collider other)
{
    if(other.CompareTag("Player"))
    {
        if(openTrigger)
        {
            myDoor.Play("Dør der åbner",0,0.0f);
            gameObject.SetActive(false);
        }
        else if(closeTrigger)
        {
            myDoor.Play("Dør der lukker",0,0.0f);
            gameObject.SetActive(false);
        }
    }
}


}