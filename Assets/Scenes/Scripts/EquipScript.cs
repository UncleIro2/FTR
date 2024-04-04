using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScript : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject Br�ndslukker;
    public Camera Camera;
    public float range = 2f;
    public float open = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Br�ndslukker.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            EquipObject();
            Shoot();
        }

        if (Input.GetKeyDown("q"))
        {
            UnequipObject();


        }
    }

    void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                EquipObject();
            }
        }
    }

    void UnequipObject()
    {
        PlayerTransform.DetachChildren();
        Br�ndslukker.transform.eulerAngles = new Vector3(Br�ndslukker.transform.eulerAngles.x, Br�ndslukker.transform.eulerAngles.y, Br�ndslukker.transform.eulerAngles.z - 45);
        Br�ndslukker.GetComponent<Rigidbody>().isKinematic = false;
    }

    void EquipObject()
    {
        Br�ndslukker.GetComponent<Rigidbody>().isKinematic = true;
        Br�ndslukker.transform.position = PlayerTransform.transform.position;
        Br�ndslukker.transform.rotation = PlayerTransform.transform.rotation;
        Br�ndslukker.transform.SetParent(PlayerTransform);
    }
}
