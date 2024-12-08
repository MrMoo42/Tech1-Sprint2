using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PlayerMovement : MonoBehaviour
{
    //Using the newer input system for this, more flexible.

    public float moveSpeed = 5.0f;
    private PlayerInputs playerInputs;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private SpriteRenderer sprite;
    private Animator anim;


    public Color flashColor = Color.red;
    private Color orignialColor = Color.white;
    private float flashDuration = 0.1f;

    public float Frames;
    public bool invincible;

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

    private void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        moveInput = playerInputs.Player.Movement.ReadValue<Vector2>();
        moveInput.Normalize();
        if (moveInput.x >= 0.5f) {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        } else if (moveInput.x <= -0.5f) {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        rb.velocity = moveInput * moveSpeed;
        animReset();

        if (moveInput == new Vector2(0, 0)) {
            anim.SetBool("Idle", true);
        }
        if (moveInput.x >= 0.5)
        {
            anim.SetBool("WalkRight", true);
        }
        else if (moveInput.x <= -0.5) {
            anim.SetBool("WalkLeft", true);
        }
        if (moveInput.y > 0.5) {
            anim.SetBool("WalkUp", true);
        }
        else if (moveInput.y < -0.5)
        {
            anim.SetBool("WalkDown", true);

        }
    }

    private void animReset() {
        sprite.flipX = false;
        anim.SetBool("Idle", false);
        anim.SetBool("WalkUp", false);
        anim.SetBool("WalkDown", false);
        anim.SetBool("WalkLeft", false);
        anim.SetBool("WalkRight", false);
    }

    public IEnumerator FlashDamage()
    {
        StartCoroutine(invincibilityFrames()); // trigger invincibility when damaged

        sprite.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        sprite.color = orignialColor;
    }

    public IEnumerator invincibilityFrames() // invisibility frames
    {
        if (!invincible)
        {
            invincible = true;
            yield return new WaitForSeconds(Frames);
            invincible = false;
            sprite.color = orignialColor;
        }
    }
}
