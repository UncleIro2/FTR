using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;


public class Extinguisher : MonoBehaviour
{
    [SerializeField] private float amountExtinguishPerSecond = 1.0f;
    ParticleSystem ps;

    public float vand;
    public float maxVand;
    public float vandCost;
    public bool pinPulled = false;
    public Animator pin;
    public EquipScript equipScript;





    private void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        ps.Stop();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !pinPulled && equipScript.brandSlukker == this.gameObject)
        {
            pinPulled = true;
            Pin();
        }


            bool isEquipped = this.transform.parent != null ? this.transform.parent.gameObject.CompareTag("Player") : false;
            if (isEquipped && pinPulled && Input.GetMouseButton(0) && vand > 0)
            {
                vand -= vandCost + Time.deltaTime;
                if (vand < 0) vand = 0;

                ps.Play();


                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 5f) && hit.collider.TryGetComponent(out Fire fire))
                {
                    fire.TryExtinguish(amountExtinguishPerSecond * Time.deltaTime);
                }


            }
        


        if (!Input.GetMouseButton(0) || vand <= 0)
        {
            ps.Stop();
        }

      

    }

    void Pin()
    {
        StartCoroutine(RunAnimation());

    }

    public IEnumerator RunAnimation()
    {
        pin.SetBool("PlayAnim", true);
        float waitTime = pin.runtimeAnimatorController.animationClips[0].length + 0.5f;
        yield return new WaitForSeconds(waitTime);
        pin.SetBool("AnimationDone", true);
        Destroy(pin.gameObject);
    }

}
