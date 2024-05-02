using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EquipScript : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject Brændslukker;
    public GameObject Brandtæpperør;
    public Camera Camera;
    public Rigidbody rbBrændslukker;
    public Rigidbody rbBrandtæpperør;
    public bool isholding = false ;
 

    void Start()
    {
        rbBrændslukker = Brændslukker.GetComponent<Rigidbody>();
        rbBrandtæpperør = Brandtæpperør.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (isholding == false)
            {
                EquipBrændslukker();
                isholding = true;
            }
            if (isholding == false)
            {
                EquipBrandtæpperør();
                isholding = true;


            }

          


        }
        
     




        if (Input.GetKeyDown("q"))
        {
            if(isholding == true)
            {
                UnequipBrændslukker();
                isholding = false;
            }
            if(isholding == true)
            {
                UnequipBrandtæpperør();
                isholding = false;
            }



        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obj")) {
            Brændslukker = other.gameObject;
        }
    }

    void EquipObeject()
    {
       

        

    }

    void UnequipObject()
    {


    }


    void UnequipBrændslukker()
    {
        rbBrændslukker.constraints = RigidbodyConstraints.None;
        PlayerTransform.DetachChildren();
        Brændslukker.transform.eulerAngles = new Vector3(0f, 180f, 0f);


        


    }

    void UnequipBrandtæpperør()
    {
        rbBrandtæpperør.constraints = RigidbodyConstraints.None;
        PlayerTransform.DetachChildren();
        Brandtæpperør.transform.eulerAngles = new Vector3(0f, 180f, 0f);

    }



    void EquipBrændslukker()
    {
        if ((Brændslukker.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude)
        {
            rbBrændslukker.constraints = RigidbodyConstraints.FreezeAll;
            Brændslukker.transform.position = PlayerTransform.transform.position;
            Brændslukker.transform.rotation = PlayerTransform.transform.rotation;
            Brændslukker.transform.SetParent(PlayerTransform);

        }



    }

    void EquipBrandtæpperør()
    {
        if ((Brandtæpperør.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude)
        {
            rbBrandtæpperør.constraints = RigidbodyConstraints.FreezeAll;
            Brandtæpperør.transform.position = PlayerTransform.transform.position;
            Brandtæpperør.transform.rotation = PlayerTransform.transform.rotation;
            Brandtæpperør.transform.SetParent(PlayerTransform);
        }


    }

}



