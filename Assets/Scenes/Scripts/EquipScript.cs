using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EquipScript : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject obj;
    public Camera Camera;
    public Rigidbody rb;
    public bool isholding = false ;
    public Image vandBar;



    void Update()
    {
        if (obj != null)
        {
            rb = obj.GetComponent<Rigidbody>();
           
        }

        if(isholding)
        {
            Extinguisher brandSlukker = obj.GetComponent<Extinguisher>();
            vandBar.transform.parent.gameObject.SetActive(true);
            vandBar.fillAmount = brandSlukker.vand / brandSlukker.maxVand;
        } else
        {
            vandBar.transform.parent.gameObject.SetActive(false);
        }

     
        KeyBind();
  
    }

    void Equip()
    { 
        if (obj != null && (obj.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude && isholding == false) 
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            obj.transform.position = PlayerTransform.transform.position;
            obj.transform.rotation = PlayerTransform.transform.rotation;
            obj.transform.SetParent(PlayerTransform);
            isholding = true;
          
        }

     
    }

    void Unequip()
    { 
        if(isholding == true) 
        {

            rb.constraints = RigidbodyConstraints.None;
            PlayerTransform.DetachChildren();
            obj.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            isholding = false;
        }

       
    }


    void KeyBind()
    {
        if (Input.GetKeyDown("e"))
        {
           
            Equip();            
            


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
            obj = other.gameObject;
        }
      

       
    }

   


}



