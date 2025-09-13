using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public GameObject[] puntosDestino;
    private int indice = 1;
    private bool avanzar = true;
    private bool moverIndice = true;
    public float velocidad = 5;
    // Start is called before the first frame update
    void Start()
    {
        puntosDestino = GameObject.FindGameObjectsWithTag("PuntoDestino");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, puntosDestino[indice].transform.position)<=0.1f)
        {
            if (moverIndice)
            {
                indice++;
                if (indice >= puntosDestino.Length)
                {
                    moverIndice = false;
                    indice = puntosDestino.Length - 2;

                }
            }
            else
            {
                indice--;
                if (indice <0)
                {
                    moverIndice = true;
                    indice = 1;

                }
            }

                StartCoroutine(Espera());
        }
        if (avanzar)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, puntosDestino[indice].transform.position, velocidad*Time.deltaTime);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    IEnumerator Espera()
    {
        avanzar = false;
        yield return new WaitForSecondsRealtime(1.5f);
        avanzar = true;
    }
}
