using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public float gravity = -10f; // How powerful the gravity is

    public void Attract(Transform body){ // Called by each gravity body in the scene
        Vector3 targetDir = (body.position -transform.position).normalized; // Direction the up axis of the body should be facing
        Vector3 bodyUp = body.up; // Sets the body's up direction

        body.rotation = Quaternion.FromToRotation(bodyUp, targetDir) * body.rotation; // Rotates the body according to its position
        body.GetComponent<Rigidbody>().AddForce(targetDir * gravity); // Applies a downward force to simulate gravity
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
