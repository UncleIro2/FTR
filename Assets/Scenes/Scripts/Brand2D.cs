using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Brand2D : MonoBehaviour
{

    
    public GameObject panel;
    
    

    private RectTransform _rectTransform;

    void Start()
    {
        _rectTransform = this.gameObject.transform.Find("pin").GetComponent<RectTransform>();
    }
}

