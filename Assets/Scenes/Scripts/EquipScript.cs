using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScript : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject Brændslukker;
    public Camera Camera;
    public float range = 2f;
    public float open = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Brændslukker.GetComponent<Rigidbody>().isKinematic = true;
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
        Brændslukker.transform.eulerAngles = new Vector3(Brændslukker.transform.eulerAngles.x, Brændslukker.transform.eulerAngles.y, Brændslukker.transform.eulerAngles.z - 45);
        Brændslukker.GetComponent<Rigidbody>().isKinematic = false;
    }

    void EquipObject()
    {
        Brændslukker.GetComponent<Rigidbody>().isKinematic = true;
        Brændslukker.transform.position = PlayerTransform.transform.position;
        Brændslukker.transform.rotation = PlayerTransform.transform.rotation;
        Brændslukker.transform.SetParent(PlayerTransform);
    }
}
