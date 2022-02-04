using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour
{
    GravityAttractor planet;
    public int whichGravity;
    GameObject[] planets =null;
    void Awake()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");
        Debug.Log(planets.Length);
        GetComponent<Rigidbody>().useGravity = false; // Prevents the rigidbody gravity from affecting the gravityattractor force
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation; // Prevents the rigidbody gravity from affecting the gravityattarctor rotation
    }

    // Update is called once per frame
    void FixedUpdate()
    {    
         CallAttract();
    }

    void CallAttract()
    {
        GravityAttractor planetAttractor =  planets[whichGravity].GetComponent<GravityAttractor>();
        planetAttractor.Attract(transform);
        // Debug.Log("Working");
        // Debug.Log(planetAttractor);
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("TRIGGERED");
        Debug.Log(other.name);
        if (other.name == "Gravity_Planet1"){
            whichGravity = 1;
        }
        if (other.name == "Gravity_Planet2"){
            whichGravity = 0;
        }
        
    }
    
}
