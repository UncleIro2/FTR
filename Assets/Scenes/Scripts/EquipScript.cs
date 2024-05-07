using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EquipScript : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject brandSlukker;
    public GameObject brandAlarm;
    public Camera Camera;
    public Rigidbody brandSlukkerRB;
    public bool isholding = false ;
    public Image vandBar;
    public AudioClip brandAlarmClip;



    void Update()
    {
        if (brandSlukker != null)
        {
            brandSlukkerRB = brandSlukker.GetComponent<Rigidbody>();
        }

        if(isholding)
        {
            Extinguisher brandSlukkerScript = brandSlukker.GetComponent<Extinguisher>();
            vandBar.transform.parent.gameObject.SetActive(true);
            vandBar.fillAmount = brandSlukkerScript.vand / brandSlukkerScript.maxVand;
        } else
        {
            vandBar.transform.parent.gameObject.SetActive(false);
        }

     
        KeyBind();
  
    }

    void Equip()
    { 
        if (brandSlukker != null && (brandSlukker.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude && isholding == false) 
        {
            brandSlukkerRB.constraints = RigidbodyConstraints.FreezeAll;
            brandSlukker.transform.position = PlayerTransform.transform.position;
            brandSlukker.transform.rotation = PlayerTransform.transform.rotation;
            brandSlukker.transform.SetParent(PlayerTransform);
            isholding = true;
          
        }
    }

    void Unequip()
    { 
        if(isholding == true) 
        {

            brandSlukkerRB.constraints = RigidbodyConstraints.None;
            PlayerTransform.DetachChildren();
            brandSlukker.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            isholding = false;
        }

       
    }

    void StartFireAlarm()
    {
        if (brandAlarm != null && (brandAlarm.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude)
        {
            Debug.Log("Test");
            AudioSource.PlayClipAtPoint(brandAlarmClip, transform.position);
        }
    }


    void KeyBind()
    {
        if (Input.GetKeyDown("e"))
        {
           
            Equip();
            StartFireAlarm();


        }
        if (Input.GetKeyDown("q"))
        {

            Unequip();
   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obj") && !isholding)
        {
            brandSlukker = other.gameObject;
        }

        if (other.gameObject.CompareTag("BrandAlarm"))
        {
            brandAlarm = other.gameObject;
        }

    }

   


}



