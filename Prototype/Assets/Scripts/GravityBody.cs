using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour
{
    GravityAttractor planet;
    void Awake()
    {
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
        GetComponent<Rigidbody>().useGravity = false; // Prevents the rigidbody gravity from affecting the gravityattractor force
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation; // Prevents the rigidbody gravity from affecting the gravityattarctor rotation
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        planet.Attract(transform);
    }
}
