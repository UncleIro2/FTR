using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;


public class Extinguisher : MonoBehaviour
{
    [Header("Brandslukker")]
    [SerializeField] private float amountExtinguishPerSecond = 1.0f, brandtæmppeAmount = 50;
    ParticleSystem ps;

    [Header("Vandtank")]
    public float vand;
    public float maxVand;
    public float vandCost;

    [Header("Pin")]
    public bool pinPulled = false;
    public Animator pin;

    [Header("MISC")]
    public EquipScript equipScript;





    private void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        ps.Stop();
    }


    private void Update()
    {

        if (equipScript.equippedItem == EquipScript.EquippedItem.BrandSlukker)
        {
            FireExt(1);

        }
        if (equipScript.equippedItem == EquipScript.EquippedItem.Brandtæppe)
        {
            FireExt(2);
           
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

    void FireExt(int state)
    {
        
        bool isEquipped = this.transform.parent != null ? this.transform.parent.gameObject.CompareTag("Player") : false;
        if (state == 1)
        {
            print("state 1");

            if (Input.GetKeyDown(KeyCode.P) && !pinPulled && equipScript.brandSlukker == this.gameObject)
            {
                pinPulled = true;
                Pin();
            }

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

        if (state == 2)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 20f) && hit.collider.TryGetComponent(out Fire fire))
                {
                print("state 2");

                    fire.TryExtinguish(brandtæmppeAmount * Time.deltaTime);
                    //fire.gameObject.SetActive(false);
                   

                }

            }
        }
    }

}
