using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed;
    public float groundDrag;
    bool isGrounded;
    public Transform orientationTransform; 

    Vector3 movementDirection;

    public float jumpVelocity;

    
    float capsuleHeight;
    LayerMask ground;
    Rigidbody rb;
    float verticalInput;
    float horizontalInput; 

    public float airMultiplier;
   
    void Start()
    {
        rb  = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        capsuleHeight = GetComponentInChildren<CapsuleCollider>().height;

        ground = LayerMask.GetMask("Ground");
        
    }

    void FixedUpdate(){
        MovePlayer();
    }
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        isGrounded = Physics.Raycast(transform.position, Vector3.down, capsuleHeight * 0.5f + 0.2f, ground);

        if (isGrounded) {
            rb.drag = groundDrag;

            if (Input.GetKeyDown(KeyCode.Space)) {
                Jump();
            }

        }
        else {
            rb.drag = 0;

        }

        SpeedControl();
    }

    void MovePlayer() {
        movementDirection = orientationTransform.forward * verticalInput + orientationTransform.right * horizontalInput;

        if (isGrounded){
            rb.AddForce(movementDirection.normalized * speed * 10, ForceMode.Force);
        }
        else {
            rb.AddForce(movementDirection.normalized * speed * 10 * airMultiplier, ForceMode.Force);

        }
    }

    void Jump() {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.y);
        //then jump
        rb.AddForce(transform.up * jumpVelocity, ForceMode.Impulse);

    }

    private void SpeedControl(){
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVelocity.magnitude > speed) {
            Vector3 limitedVelocity = flatVelocity.normalized * speed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }
}
