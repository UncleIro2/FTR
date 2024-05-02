using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EquipScript : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject Br�ndslukker;
    public GameObject Brandt�pper�r;
    public Camera Camera;
    public Rigidbody rbBr�ndslukker;
    public Rigidbody rbBrandt�pper�r;
    public bool isholding = false ;
 

    void Start()
    {
        rbBr�ndslukker = Br�ndslukker.GetComponent<Rigidbody>();
        rbBrandt�pper�r = Brandt�pper�r.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (isholding == false)
            {
                EquipBr�ndslukker();
                isholding = true;
            }
            if (isholding == false)
            {
                EquipBrandt�pper�r();
                isholding = true;


            }

          


        }
        
     




        if (Input.GetKeyDown("q"))
        {
            if(isholding == true)
            {
                UnequipBr�ndslukker();
                isholding = false;
            }
            if(isholding == true)
            {
                UnequipBrandt�pper�r();
                isholding = false;
            }



        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obj")) {
            Br�ndslukker = other.gameObject;
        }
    }

    void EquipObeject()
    {
       

        

    }

    void UnequipObject()
    {


    }


    void UnequipBr�ndslukker()
    {
        rbBr�ndslukker.constraints = RigidbodyConstraints.None;
        PlayerTransform.DetachChildren();
        Br�ndslukker.transform.eulerAngles = new Vector3(0f, 180f, 0f);


        


    }

    void UnequipBrandt�pper�r()
    {
        rbBrandt�pper�r.constraints = RigidbodyConstraints.None;
        PlayerTransform.DetachChildren();
        Brandt�pper�r.transform.eulerAngles = new Vector3(0f, 180f, 0f);

    }



    void EquipBr�ndslukker()
    {
        if ((Br�ndslukker.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude)
        {
            rbBr�ndslukker.constraints = RigidbodyConstraints.FreezeAll;
            Br�ndslukker.transform.position = PlayerTransform.transform.position;
            Br�ndslukker.transform.rotation = PlayerTransform.transform.rotation;
            Br�ndslukker.transform.SetParent(PlayerTransform);

        }



    }

    void EquipBrandt�pper�r()
    {
        if ((Brandt�pper�r.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude)
        {
            rbBrandt�pper�r.constraints = RigidbodyConstraints.FreezeAll;
            Brandt�pper�r.transform.position = PlayerTransform.transform.position;
            Brandt�pper�r.transform.rotation = PlayerTransform.transform.rotation;
            Brandt�pper�r.transform.SetParent(PlayerTransform);
        }


    }

}



