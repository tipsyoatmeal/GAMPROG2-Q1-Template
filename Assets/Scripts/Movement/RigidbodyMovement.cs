using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 PlayerMovementInput;
    [SerializeField] private LayerMask FloorMask;

    [SerializeField] private Transform FeetTransform;
    [SerializeField] private float speed = 5.0f;

    //[SerializeField]
    //private int updateCount, fixedUpdateCount;

    private float xMove, zMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //Get the input values from the player
        PlayerMovementInput =  new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Jump();
    }

    private void FixedUpdate()
    {
        //Change the velocity of our player
        //rb.velocity = new Vector3(xMove, rb.velocity.y, zMove);

        Vector3 movement = transform.TransformDirection(PlayerMovementInput) * speed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Physics.CheckSphere(FeetTransform.position, 0.1f, FloorMask))
                rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
        }
    }

    
}
