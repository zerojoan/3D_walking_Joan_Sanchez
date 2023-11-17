using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    TPSControler _controler;


    void Awake()
    {
        _controler = GetComponentInParent<TPSControler>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "recogible")
        {
            _controler.objectToGrab = collider.gameObject;
        }

    }
    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "recogible")
        {
            _controler.objectToGrab = null;
        }
    }
}
