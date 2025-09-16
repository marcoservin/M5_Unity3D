using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public GameObject[] PM_puntosDestino;

    private int indice = 0;
    private bool retornar = false;
    private bool espera = true;
    public float velocidad = 3;
    public string ruta;
    public float tiempoEspera = 2;

    // Start is called before the first frame update
    void Start()
    {
        PM_puntosDestino = GameObject.FindGameObjectsWithTag(ruta);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, PM_puntosDestino[indice].transform.position) <= 0.1f)
        {

            if (indice == 0 || indice == PM_puntosDestino.Length -1) 
            {
                StartCoroutine(Espera());
                Debug.Log(indice);
            }
            if (retornar == false)
            {
                indice++;
                if (indice >= PM_puntosDestino.Length - 1)
                {
                    retornar = true;
                }
            }
            else if (retornar == true)
            {
                indice--;
                if (indice <= 0)
                {
                    retornar = false;
                }
            }
            
        }

        if (espera)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, PM_puntosDestino[indice].transform.position, velocidad * Time.deltaTime);
        }

    }


  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
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
        espera  = false;
        yield return new WaitForSecondsRealtime(tiempoEspera);
        espera = true;
    }
}
