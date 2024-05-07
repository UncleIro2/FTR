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

    public GameObject brandTæppe;
    public Rigidbody brandTæppeRB;

    public GameObject brandTæppeRør;


    public GameObject brandAlarm;
    public Camera Camera;
    
    public Image vandBar;
    public AudioClip brandAlarmClip;

    public Transform tæppeTP;

    public enum EquippedItem
    {
        Ingenting,
        BrandSlukker,
        Brandtæppe
    }

    public EquippedItem equippedItem;

    

    void Update()
    {
        if (brandSlukker != null)
        {
            brandSlukkerRB = brandSlukker.GetComponent<Rigidbody>();
        }
        if (brandTæppe != null)
        {
            brandTæppeRB = brandTæppe.GetComponent<Rigidbody>();
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
        if (brandTæppe != null && (brandTæppe.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude && equippedItem == EquippedItem.Ingenting)
        {
            brandTæppeRB.constraints = RigidbodyConstraints.FreezeAll;
            tæppeTP.transform.position = PlayerTransform.transform.position;
            tæppeTP.transform.rotation = PlayerTransform.transform.rotation;
            tæppeTP.transform.SetParent(PlayerTransform);
            equippedItem = EquippedItem.Brandtæppe;

        }
        if(brandTæppeRør != null && (brandTæppeRør.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude)
        {

            //FLYT TÆÆPET
            brandTæppeRB.constraints = RigidbodyConstraints.FreezeAll;
            brandTæppe.transform.position = tæppeTP.transform.position;
            brandTæppe.transform.rotation = tæppeTP.transform.rotation;
            brandTæppe.transform.SetParent(tæppeTP);
         
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
        else if (equippedItem == EquippedItem.Brandtæppe)
        {
            brandTæppeRB.constraints = RigidbodyConstraints.None;
            PlayerTransform.DetachChildren();
            brandTæppe.transform.eulerAngles = new Vector3(0f, 180f, 0f);
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
        if (other.gameObject.CompareTag("Brandtæppe") && equippedItem == EquippedItem.Ingenting)
        {
            brandTæppe = other.gameObject;
        }
        if(other.gameObject.CompareTag("BrandtæppeRør") && equippedItem == EquippedItem.Ingenting)
        {
            brandTæppeRør = other.gameObject;
        }

        if (other.gameObject.CompareTag("BrandAlarm"))
        {
            brandAlarm = other.gameObject;
        }


    }

   


}



