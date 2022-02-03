using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour
{
    GravityAttractor planet;
    GameObject[] planets =null;
    void Awake()
    {
       // planets = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
         planets = GameObject.FindGameObjectsWithTag("Planet");
         Debug.Log(planets.Length);
        GetComponent<Rigidbody>().useGravity = false; // Prevents the rigidbody gravity from affecting the gravityattractor force
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation; // Prevents the rigidbody gravity from affecting the gravityattarctor rotation
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GravityAttractor planetAttractor =  planets[1].GetComponent<GravityAttractor>();
        planetAttractor.Attract(transform);
        // Debug.Log("Working");
        // Debug.Log(planetAttractor);
    }
}
