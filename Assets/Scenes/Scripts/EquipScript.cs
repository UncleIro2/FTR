using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class EquipScript : MonoBehaviour
{
    public Transform PlayerTransform;
    
    public GameObject brandSlukker;
    public Rigidbody brandSlukkerRB;

    public GameObject brandT�ppe;
    public Rigidbody brandT�ppeRB;

    public GameObject brandT�ppeR�r;


    public GameObject brandAlarm;
    public Camera Camera;
    
    public Image vandBar;
    public AudioClip brandAlarmClip;

    public Transform t�ppeTP;

    public enum EquippedItem
    {
        Ingenting,
        BrandSlukker,
        Brandt�ppe
    }

    public EquippedItem equippedItem;

    

    void Update()
    {
        if (brandSlukker != null)
        {
            brandSlukkerRB = brandSlukker.GetComponent<Rigidbody>();
        }
        if (brandT�ppe != null)
        {
            brandT�ppeRB = brandT�ppe.GetComponent<Rigidbody>();
        }


        if (equippedItem == EquippedItem.BrandSlukker)
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
        if (brandSlukker != null && (brandSlukker.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude && equippedItem == EquippedItem.Ingenting) 
        {
            brandSlukkerRB.constraints = RigidbodyConstraints.FreezeAll;
            brandSlukker.transform.position = PlayerTransform.transform.position;
            brandSlukker.transform.rotation = PlayerTransform.transform.rotation;
            brandSlukker.transform.SetParent(PlayerTransform);
            equippedItem = EquippedItem.BrandSlukker;
          
        }
        if (brandT�ppe != null && (brandT�ppe.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude && equippedItem == EquippedItem.Ingenting)
        {
            brandT�ppeRB.constraints = RigidbodyConstraints.FreezeAll;
            t�ppeTP.transform.position = PlayerTransform.transform.position;
            t�ppeTP.transform.rotation = PlayerTransform.transform.rotation;
            t�ppeTP.transform.SetParent(PlayerTransform);
            equippedItem = EquippedItem.Brandt�ppe;

        }
        if(brandT�ppeR�r != null && (brandT�ppeR�r.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude)
        {

            //FLYT T��PET
            brandT�ppeRB.constraints = RigidbodyConstraints.FreezeAll;
            brandT�ppe.transform.position = t�ppeTP.transform.position;
            brandT�ppe.transform.rotation = t�ppeTP.transform.rotation;
            brandT�ppe.transform.SetParent(t�ppeTP);
         
        }

    }

    void Unequip()
    { 
        if(equippedItem == EquippedItem.BrandSlukker) 
        {
            brandSlukkerRB.constraints = RigidbodyConstraints.None;
            PlayerTransform.DetachChildren();
            brandSlukker.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            equippedItem = EquippedItem.Ingenting;
        }
        else if (equippedItem == EquippedItem.Brandt�ppe)
        {
            brandT�ppeRB.constraints = RigidbodyConstraints.None;
            PlayerTransform.DetachChildren();
            brandT�ppe.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            equippedItem = EquippedItem.Ingenting;
        }


    }

    void StartFireAlarm()
    {
        if (brandAlarm != null && (brandAlarm.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude)
        {
            
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
        if (other.gameObject.CompareTag("Brandslukker") && equippedItem == EquippedItem.Ingenting)
        {
            brandSlukker = other.gameObject;
        }
        if (other.gameObject.CompareTag("Brandt�ppe") && equippedItem == EquippedItem.Ingenting)
        {
            brandT�ppe = other.gameObject;
        }
        if(other.gameObject.CompareTag("Brandt�ppeR�r") && equippedItem == EquippedItem.Ingenting)
        {
            brandT�ppeR�r = other.gameObject;
        }

        if (other.gameObject.CompareTag("BrandAlarm"))
        {
            brandAlarm = other.gameObject;
        }


    }

   


}



