using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circuito : MonoBehaviour
{
    public GameObject[] Destino;
    private int indice = 0;
    public float velocidad = 2;

    void Start()
    {
        
    }

    void Update()
    {
        if (Vector3.Distance(this.transform.position, Destino[indice].transform.position) <= 0.1f)
        {
            indice++;

            if (indice >= Destino.Length)
            {
                indice = 0;
            }

        }

        this.transform.position = Vector3.MoveTowards(this.transform.position, Destino[indice].transform.position, velocidad);
    }
}
