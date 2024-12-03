using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Using the newer input system for this, more flexible.

    public float moveSpeed = 5.0f;
    private PlayerInputs playerInputs;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }
    private void Awake()
    {
        playerInputs = new PlayerInputs();
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.LogError("No rigidbody on " + this.gameObject.name + "!!!");
    }

    private void FixedUpdate()
    {
        moveInput = playerInputs.Player.Movement.ReadValue<Vector2>();
        moveInput.Normalize();
        rb.velocity = moveInput * moveSpeed;
    }
}
