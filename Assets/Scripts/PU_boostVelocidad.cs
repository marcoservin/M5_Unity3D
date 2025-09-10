using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_boostVelocidad : MonoBehaviour
{
    [SerializeField] public float duracionBoost = 3f;
    [SerializeField] public float aumnetoBoost = 0.5f;

    private float velocidadBoost;

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
            MovePlayer.boostVelocidad = true;
            MovePlayer.duracionBoostVel = duracionBoost;
            MovePlayer.aumentoVel += aumnetoBoost;
            Destroy(this.gameObject);
        }

    }
}
