using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addingRotation : MonoBehaviour
{
    public float tumple;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumple;

        
    }
}
