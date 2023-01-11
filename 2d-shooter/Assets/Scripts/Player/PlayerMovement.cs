using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    // Speed of player. Set in Unity Editor
    public float moveSpeed = 5;

    // Multiplier increased by shop items. As it increases, the player should move faster.
    [HideInInspector] public float movementSpeedMultiplier = 1f;

    // Ui text used for showing the movementSpeedMultiplier
    public TextMeshProUGUI multiplierText;

    // RigidBody of player. Set in Unity Editor
    public Rigidbody2D rigidbody;

    // Animator used to set the current animation. Set in Unity Editor
    public Animator animator;

    // Sprite renderer used to flip the player based on horizontal movement. Set in Unity Editor
    public SpriteRenderer spriteRenderer;

    // Direction of the player. Set by user inputs
    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        multiplierText.text = "x" + movementSpeedMultiplier.ToString();
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

        // Update variable for animator to switch between idle and running.
        animator.SetFloat("Speed", Mathf.Abs(moveX) + Mathf.Abs(moveY));

        // Flip player based on horizontal movement
        if (moveX > 0) {
            // normal
            spriteRenderer.flipX = false;
        } else if (moveX < 0) {
            // moving to the left -> flip
            spriteRenderer.flipX = true;
        }

    }

    // Move the player based on the direction and speed
    void MovePlayer() 
    {
        rigidbody.velocity = new Vector2(moveDirection.x * (movementSpeedMultiplier * moveSpeed), moveDirection.y * (movementSpeedMultiplier * moveSpeed));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
    }
}