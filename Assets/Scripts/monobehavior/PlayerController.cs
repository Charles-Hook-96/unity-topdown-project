using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    //Assets
    private Rigidbody2D rb;
    private Animator anim;

    //Movement details/speed
    [SerializeField] private float moveSpeed = 4f;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // This function is automatically called by the PlayerInput component, Part of new Input System
    public void OnMove(InputAction.CallbackContext context)
    {
        anim.SetBool("isWalking", true);

        if (context.canceled)
        {
            anim.SetBool("isWalking", false);

            anim.SetFloat("lastInputX", moveInput.x);
            anim.SetFloat("lastInputY", moveInput.y);
        }

        moveInput = context.ReadValue<Vector2>();
    }

    // Use Update or FixedUpdate to apply movement
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        rb.linearVelocity = moveInput * moveSpeed;
        HandleMovementAnimations();
    }

    private void HandleMovementAnimations()
    {
        anim.SetFloat("yVelocity", moveInput.y * moveSpeed);
        anim.SetFloat("xVelocity", moveInput.x * moveSpeed);
    }
}
