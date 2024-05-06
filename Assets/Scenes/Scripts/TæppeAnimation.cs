using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;


public class TæppeAnimation : MonoBehaviour

{
    public Animator Brandtæppe; // Reference to the Animator component of the object you want to animate
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(RunAnimation());
        }


    }

    IEnumerator RunAnimation()
    {
        Brandtæppe.SetBool("PlayAnim", true);
        float waitTime = GetComponent<Animator>().runtimeAnimatorController.animationClips[0].length;
        yield return new WaitForSeconds(waitTime);
        Brandtæppe.SetBool("AnimationDone", true);
        Destroy(this.gameObject);
    }
}
