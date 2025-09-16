using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public float Velocidad = 10f;
    public Vector3 Rotar = Vector3.up;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Rotar * Velocidad * Time.deltaTime);
    }
}
