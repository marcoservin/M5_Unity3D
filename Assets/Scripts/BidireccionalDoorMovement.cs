using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidireccionalDoorMovement : MonoBehaviour
{
    public float anguloApertura = 90f;   
    public float velocidad = 2f;         

    private Quaternion rotacionInicial;
    private Quaternion rotacionObjetivo;
    private Coroutine cierreCoroutine;

    void Start()
    {
        rotacionInicial = transform.localRotation;
        rotacionObjetivo = rotacionInicial;
    }

    public void AbrirPuerta(bool sentidoHorario)
    {
    
        float angulo = sentidoHorario ? anguloApertura : -anguloApertura;
        rotacionObjetivo = rotacionInicial * Quaternion.Euler(0, 0, angulo);
    }

    public void ReiniciarTimer(float tiempo)
    {
        if (cierreCoroutine != null)
            StopCoroutine(cierreCoroutine);

        cierreCoroutine = StartCoroutine(CerrarPuertaDespuesDeTiempo(tiempo));
    }

    IEnumerator CerrarPuertaDespuesDeTiempo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        rotacionObjetivo = rotacionInicial; 
    }

    void Update()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotacionObjetivo, Time.deltaTime * velocidad);
    }
}
