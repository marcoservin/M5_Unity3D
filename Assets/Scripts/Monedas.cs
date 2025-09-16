using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    public int Valor = 1;
    public static int TotalMonedas = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        TotalMonedas += Valor;
        Debug.Log("Total Monedas: " + TotalMonedas);

        Destroy(this.gameObject);
    }
}

