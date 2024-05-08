using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class EquipScript : MonoBehaviour
{
    [Header("Brandslukker")]
    public Transform PlayerTransform;
    public GameObject brandSlukker;
    public Rigidbody brandSlukkerRB;

    [Header("Brandt�ppe")]
    public GameObject brandT�ppe;
    public Rigidbody brandT�ppeRB;
    public Transform brandT�ppeTransform;
    public Collider brandT�ppeCollider;


    [Header("BrandAlarm")]
    public AudioClip brandAlarmClip;
    public GameObject brandAlarm;

    [Header("Brandt�pper�r")]
    public GameObject brandT�ppeR�r;

    [Header("MISC")]
    public Camera Camera;
    public Image vandBar;


    private void Start()
    {
        brandT�ppeCollider = brandT�ppe.GetComponent<Collider>();
    }



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
        }
        else
        {
            vandBar.transform.parent.gameObject.SetActive(false);
        }


        KeyBind();

    }

    void Equip()
    {
        if (brandSlukker != null && (brandSlukker.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude && equippedItem == EquippedItem.Ingenting)
        {

            //S�tte Brandslukker p� player
            brandSlukkerRB.constraints = RigidbodyConstraints.FreezeAll;
            brandSlukker.transform.position = PlayerTransform.transform.position;
            brandSlukker.transform.rotation = PlayerTransform.transform.rotation;
            brandSlukker.transform.SetParent(PlayerTransform);
            equippedItem = EquippedItem.BrandSlukker;

        }

        if (brandT�ppeR�r != null && equippedItem == EquippedItem.Ingenting)
        {

            brandT�ppe.SetActive(true);
          




        }
        if (brandT�ppe != null && (brandT�ppe.transform.position - brandT�ppeTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude && equippedItem == EquippedItem.Ingenting)
        {
            //S�tte t�pper p� player
            brandT�ppeRB.constraints = RigidbodyConstraints.FreezeAll;
            brandT�ppe.transform.position = brandT�ppeTransform.transform.position;
            brandT�ppe.transform.rotation = brandT�ppeTransform.transform.rotation;
            brandT�ppe.transform.SetParent(brandT�ppeTransform);
            brandT�ppeCollider.enabled = false;
            equippedItem = EquippedItem.Brandt�ppe;

        }


    }

    void Unequip()
    {
        if (equippedItem == EquippedItem.BrandSlukker)
        {
            brandSlukkerRB.constraints = RigidbodyConstraints.None;
            PlayerTransform.DetachChildren();
            brandSlukker.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            equippedItem = EquippedItem.Ingenting;
        }
        else if (equippedItem == EquippedItem.Brandt�ppe)
        {
            brandT�ppeRB.constraints = RigidbodyConstraints.None;
            brandT�ppeTransform.DetachChildren();
            brandT�ppe.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            brandT�ppeCollider.enabled = true;
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

        if (other.gameObject.CompareTag("Brandt�ppeR�r") && equippedItem == EquippedItem.Ingenting)
        {


            brandT�ppeR�r = other.gameObject;
            string parentName = brandT�ppeR�r.name;
            if (brandT�ppeR�r.transform.childCount > 5)
            {
                Transform brandT�ppeTransform = brandT�ppeR�r.transform.GetChild(5);
                if (brandT�ppeTransform != null)
                {
                    brandT�ppe = brandT�ppeTransform.gameObject;
                    print(brandT�ppe);
                }
                else
                {
                    Debug.LogError("Child transform at index 5 does not exist.");
                }
            }


        }
        if (other.gameObject.CompareTag("BrandAlarm"))
        {
            brandAlarm = other.gameObject;
        }


    }




}



