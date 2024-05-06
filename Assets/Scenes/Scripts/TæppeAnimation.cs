using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;


public class T�ppeAnimation : MonoBehaviour

{
    public Animator Brandt�ppe; // Reference to the Animator component of the object you want to animate
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(RunAnimation());
        }


    }

    IEnumerator RunAnimation()
    {
        Brandt�ppe.SetBool("PlayAnim", true);
        float waitTime = GetComponent<Animator>().runtimeAnimatorController.animationClips[0].length;
        yield return new WaitForSeconds(waitTime);
        Brandt�ppe.SetBool("AnimationDone", true);
        Destroy(this.gameObject);
    }
}
