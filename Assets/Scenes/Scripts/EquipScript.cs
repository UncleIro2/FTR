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



    // Start is called before the first frame update
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
            EquipObejet();

        }
       

        if (Input.GetKeyDown("q"))
        {
            UnequipObejct();


        }

       

    }

    void UnequipObejct()
    {
        rbBr�ndslukker.constraints = RigidbodyConstraints.None;
        PlayerTransform.DetachChildren();  
        Br�ndslukker.transform.eulerAngles = new Vector3(0f,180f,0f);


        rbBrandt�pper�r.constraints = RigidbodyConstraints.None;
        PlayerTransform.DetachChildren();
        Brandt�pper�r.transform.eulerAngles = new Vector3(0f, 180f, 0f);


    }

 

    void EquipObejet()
    {

        if((Br�ndslukker.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f,1f,1f).magnitude)
        {
            rbBr�ndslukker.constraints = RigidbodyConstraints.FreezeAll;
            Br�ndslukker.transform.position = PlayerTransform.transform.position;
            Br�ndslukker.transform.rotation = PlayerTransform.transform.rotation;
            Br�ndslukker.transform.SetParent(PlayerTransform);
        }

        if ((Brandt�pper�r.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f, 1f, 1f).magnitude)
        {
            rbBrandt�pper�r.constraints = RigidbodyConstraints.FreezeAll;
            Brandt�pper�r.transform.position = PlayerTransform.transform.position;
            Brandt�pper�r.transform.rotation = PlayerTransform.transform.rotation;
            Brandt�pper�r.transform.SetParent(PlayerTransform);
        }
        
    }

    
}
