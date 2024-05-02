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



    // Start is called before the first frame update
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
            EquipObejet();

        }
       

        if (Input.GetKeyDown("q"))
        {
            UnequipObejct();


        }

       

    }

    void UnequipObejct()
    {
        rbBrændslukker.constraints = RigidbodyConstraints.None;
        PlayerTransform.DetachChildren();  
        Brændslukker.transform.eulerAngles = new Vector3(0f,180f,0f);


        rbBrandtæpperør.constraints = RigidbodyConstraints.None;
        PlayerTransform.DetachChildren();
        Brandtæpperør.transform.eulerAngles = new Vector3(0f, 180f, 0f);


    }

 

    void EquipObejet()
    {

        if((Brændslukker.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f,1f,1f).magnitude)
        {
            rbBrændslukker.constraints = RigidbodyConstraints.FreezeAll;
            Brændslukker.transform.position = PlayerTransform.transform.position;
            Brændslukker.transform.rotation = PlayerTransform.transform.rotation;
            Brændslukker.transform.SetParent(PlayerTransform);
        }

        if ((Brandtæpperør.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude)
        {
            rbBrandtæpperør.constraints = RigidbodyConstraints.FreezeAll;
            Brandtæpperør.transform.position = PlayerTransform.transform.position;
            Brandtæpperør.transform.rotation = PlayerTransform.transform.rotation;
            Brandtæpperør.transform.SetParent(PlayerTransform);
        }
        
    }

    
}
