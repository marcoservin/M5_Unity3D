using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidireccionalDoorZoneDetection : MonoBehaviour
{
    public BidireccionalDoorMovement puerta;        
    public float tiempoCierre = 2f;  

    private Transform jugador;        

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugador = other.transform;
            Debug.Log("Jugador en zona");

      
            Vector3 direccion = (jugador.position - puerta.transform.position).normalized;
            float dot = Vector3.Dot(direccion, puerta.transform.right);

          
            if (dot > 0)
            {
                puerta.AbrirPuerta(true); 
            }
            else
            {
                puerta.AbrirPuerta(false); 
            }

            
            puerta.ReiniciarTimer(tiempoCierre);
        }
    }
}
