using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float mouseSensitivityX = 250f; // Horizontal sens
    public float mouseSensitivityY = 250f; // Vertical sens

    public float walkSpeed = 8.0f; 
    public float jumpForce = 220;

    public LayerMask groundedMask;
    Transform cameraT;

    float verticalLookRotation; // Stores the amount the player is rotated horizontally

    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    bool grounded; // True is player is grounded

    public float smoothAmount = 0.15f;
    public float verticalConstraint = 60f; // Stores the degrees at which the player is able to look up or down

    // Start is called before the first frame update
    void Start()
    {
        cameraT = Camera.main.transform; // Finds the main camera
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivityX); // Takes vertical mouse movement. Rotates the camera
        verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivityY; // Takes horizontal mouse movement
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -verticalConstraint, verticalConstraint); // Prevents the camera from rotating higher or lower than the contrains
        cameraT.localEulerAngles = Vector3.left * verticalLookRotation; //  Rotates the player capsule

        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized; // Stores vector for direction the player should be moving in
        Vector3 targetMoveAmount = moveDir * walkSpeed; // Controlls the speed in that direction
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, smoothAmount); // Smoothes the movement between axises

        if (Input.GetButtonDown("Jump")){ // Checks if user presses space
            if (grounded){
            GetComponent<Rigidbody>().AddForce(transform.up * jumpForce); // Adds force for jump
          }
        }
        grounded = false; // Grounded is set to false by default
        Ray ray = new Ray(transform.position, -transform.up); // Creates ray from player to ground
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1 + 0.1f, groundedMask)){ // If ray hits surface with 'ground' layer
            grounded = true; // Grounded set to true
        }

    }

    void FixedUpdate(){
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime); // Updates the player's position
    }
}
