using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransportacion : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject TPA;
    private GameObject TPB;
    private bool dentrodelTP = false;

    void Start()
    {
        TPB = GameObject.FindGameObjectWithTag("TeleportA");
        TPA = GameObject.FindGameObjectWithTag("TeleportB");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (dentrodelTP == false)
        {
            collision.transform.position = TPB.transform.position;
            dentrodelTP = true;
        }
        else
        {
            collision.transform.position = TPA.transform.position;
            dentrodelTP = false;
        }
    }
}
