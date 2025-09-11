using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_invertiControl : MonoBehaviour
{
    [SerializeField] private float duracionInvertir = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            MovePlayer.debuffInvertir = true;
            MovePlayer.duracionInvertir = duracionInvertir;
            Destroy(this.gameObject);
        }

    }
}
