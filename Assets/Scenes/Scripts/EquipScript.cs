using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScript : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject Br�ndslukker;
    public Camera Camera;
    public Rigidbody rb;  
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = Br�ndslukker.GetComponent<Rigidbody>();
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
        Br�ndslukker.transform.eulerAngles = new Vector3(0f,180f,0f);
    }

    void EquipObject()
    {

        if((Br�ndslukker.transform.position - PlayerTransform.transform.position).magnitude <= new Vector3(1f,1f,1f).magnitude)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Br�ndslukker.transform.position = PlayerTransform.transform.position;
            Br�ndslukker.transform.rotation = PlayerTransform.transform.rotation;
            Br�ndslukker.transform.SetParent(PlayerTransform);
        }
    }
}
