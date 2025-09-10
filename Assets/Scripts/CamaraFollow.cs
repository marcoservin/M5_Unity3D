using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
