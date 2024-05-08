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

    [Header("Brandtæppe")]
    public GameObject brandTæppe;
    public Rigidbody brandTæppeRB;
    public Transform brandTæppeTransform;
    public Collider brandTæppeCollider;


    [Header("BrandAlarm")]
    public AudioClip brandAlarmClip;
    public GameObject brandAlarm;

    [Header("Brandtæpperør")]
    public GameObject brandTæppeRør;

    [Header("MISC")]
    public Camera Camera;
    public Image vandBar;


    private void Start()
    {
        brandTæppeCollider = brandTæppe.GetComponent<Collider>();
    }



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

            //Sætte Brandslukker på player
            brandSlukkerRB.constraints = RigidbodyConstraints.FreezeAll;
            brandSlukker.transform.position = PlayerTransform.transform.position;
            brandSlukker.transform.rotation = PlayerTransform.transform.rotation;
            brandSlukker.transform.SetParent(PlayerTransform);
            equippedItem = EquippedItem.BrandSlukker;

        }

        if (brandTæppeRør != null && equippedItem == EquippedItem.Ingenting)
        {

            brandTæppe.SetActive(true);
          




        }
        if (brandTæppe != null && (brandTæppe.transform.position - brandTæppeTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude && equippedItem == EquippedItem.Ingenting)
        {
            //Sætte tæpper på player
            brandTæppeRB.constraints = RigidbodyConstraints.FreezeAll;
            brandTæppe.transform.position = brandTæppeTransform.transform.position;
            brandTæppe.transform.rotation = brandTæppeTransform.transform.rotation;
            brandTæppe.transform.SetParent(brandTæppeTransform);
            brandTæppeCollider.enabled = false;
            equippedItem = EquippedItem.Brandtæppe;

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
        else if (equippedItem == EquippedItem.Brandtæppe)
        {
            brandTæppeRB.constraints = RigidbodyConstraints.None;
            brandTæppeTransform.DetachChildren();
            brandTæppe.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            brandTæppeCollider.enabled = true;
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

        if (other.gameObject.CompareTag("BrandtæppeRør") && equippedItem == EquippedItem.Ingenting)
        {


            brandTæppeRør = other.gameObject;
            string parentName = brandTæppeRør.name;
            if (brandTæppeRør.transform.childCount > 5)
            {
                Transform brandTæppeTransform = brandTæppeRør.transform.GetChild(5);
                if (brandTæppeTransform != null)
                {
                    brandTæppe = brandTæppeTransform.gameObject;
                    print(brandTæppe);
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



