using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levitacion : MonoBehaviour
{
    private Vector3 posInicial;
    [SerializeField] private float alturaLevitacion = 0.2f;
    [SerializeField] private float velocidadLevitacion = 3f;
    private float offsetVertical;
    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;//guarda la posicion actual del objeto
    }

    // Update is called once per frame
    void Update()
    {
        offsetVertical = Mathf.Sin(Time.time * velocidadLevitacion) * alturaLevitacion;
        transform.position = new Vector3(posInicial.x, posInicial.y + offsetVertical, posInicial.z);
    }
}
