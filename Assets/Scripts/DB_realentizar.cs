using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_realentizar : MonoBehaviour
{
    [SerializeField] private float duracionDeBuff = 3f;
    [SerializeField] private float reduccionVel = 0.5f;

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
            MovePlayer.debuffVelocidad = true;
            MovePlayer.duracionModVel = duracionDeBuff;
            MovePlayer.modificadorVel -= reduccionVel;
            Destroy(this.gameObject);
        }

    }

}
