
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float jumpForce = 20;
    float velocity;
    private Rigidbody rb;

    private CharacterController characterController;
    private float xMove, zMove;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Get the input values from the player
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        Jump();
    }

    private void FixedUpdate()
    {
        //Change the velocity of our player
        //rb.velocity = new Vector3(xMove, rb.velocity.y, zMove);

        Vector3 movement = new Vector3(xMove, 0, zMove);
        rb.MovePosition(transform.position + movement * Time.deltaTime * speed);
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * speed * 50, ForceMode.Impulse);
        }
    }


}
