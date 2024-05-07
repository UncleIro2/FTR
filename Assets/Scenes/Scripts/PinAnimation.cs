using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;


public class AnimatorScript : MonoBehaviour
{
    public Animator pin; // Reference to the Animator component of the object you want to animate
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(RunAnimation());
        }
    }

    IEnumerator RunAnimation()
    {
        pin.SetBool("PlayAnim", true);
        float waitTime = GetComponent<Animator>().runtimeAnimatorController.animationClips[0].length + 0.5f;
        yield return new WaitForSeconds(waitTime);
        pin.SetBool("AnimationDone", true);
        Destroy(this.gameObject);
    }
}
    
   


