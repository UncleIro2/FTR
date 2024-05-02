using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScript : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject Brændslukker;
    public Camera Camera;
    public Rigidbody rb;  
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = Brændslukker.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            EquipObject();
        }

        if (Input.GetKeyDown("q"))
        {
            UnequipObject();
            
        }

    }

    void UnequipObject()
    {
        rb.constraints = RigidbodyConstraints.None;
        PlayerTransform.DetachChildren();
        Brændslukker.transform.eulerAngles = new Vector3(0f,180f,0f);
    }

    void EquipObject()
    {

        if((Brændslukker.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f,1f,1f).magnitude)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Brændslukker.transform.position = PlayerTransform.transform.position;
            Brændslukker.transform.rotation = PlayerTransform.transform.rotation;
            Brændslukker.transform.SetParent(PlayerTransform);
        }
    }
}
