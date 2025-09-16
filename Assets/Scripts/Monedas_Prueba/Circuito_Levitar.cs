using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circuito_Levitar: MonoBehaviour
{
    // Circuito
    public GameObject[] Destino;
    private int indice = 0;
    public float velocidadCircuito = 2f;

    // Levitación
    private Vector3 posInicialCircuito;
    [SerializeField] private float alturaLevitacion = 0.2f;
    [SerializeField] private float velocidadLevitacion = 3f;
    private float offsetVertical;

    void Start()
    {
      
    }

    void Update()
    {
        // Circuito
        if (Destino == null || Destino.Length == 0) return;

        transform.position = Vector3.MoveTowards(transform.position, Destino[indice].transform.position, velocidadCircuito * Time.deltaTime);

        // Almacena la posición actual del circuito para usarla en la levitación
        posInicialCircuito = transform.position;

        if (Vector3.Distance(transform.position, Destino[indice].transform.position) <= 0.1f)
        {
            indice++;
            if (indice >= Destino.Length)
            {
                indice = 0; // Regresa al inicio
            }
        }

        // 2. Lógica de la Levitación
        
        offsetVertical = Mathf.Sin(Time.time * velocidadLevitacion) * alturaLevitacion;
        transform.position = new Vector3(posInicialCircuito.x, posInicialCircuito.y + offsetVertical, posInicialCircuito.z);
    }
}