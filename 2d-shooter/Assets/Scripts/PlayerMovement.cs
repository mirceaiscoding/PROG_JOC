using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Speed of player. Set in Unity Editor
    public float moveSpeed;

    // RigidBody of player. Set in Unity Editor
    public Rigidbody2D rigidbody;

    // Direction of the player. Set by user inputs
    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateMoveDirectionFromInputs();

    }

    // Independent of framerate
    void FixedUpdate()
    {
        MovePlayer();
    }

    // Get moveDirection from inputs
    void updateMoveDirectionFromInputs() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    // Move the player based on the direction anmd speed
    void MovePlayer() 
    {
        rigidbody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}