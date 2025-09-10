using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zonaSegura : MonoBehaviour
{
    private GameObject puntoControl;
    void Start()
    {
        puntoControl = GameObject.FindGameObjectWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerExit(Collider other)
    {
        other.transform.position = puntoControl.transform.position;
    }

}
