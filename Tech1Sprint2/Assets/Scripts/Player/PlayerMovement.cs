using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Using the newer input system for this, more flexible.

    public float moveSpeed = 5.0f; //How quickly the player moves across the level.

    private PlayerInputs playerInputs; //Needed for detecting key presses.
    private Rigidbody2D rb; //To actually *move* the player.
    private Vector2 moveInput; //Back end value, goes from -1 to 1 on each axis (x and y).

    [SerializeField] private Transform MirrorPlayer;
    public float difference = 17;

    private SpriteRenderer sprite;
    private SpriteRenderer mirSprite;
    private Animator anim;
    private Animator mirAnim;

    [Header("IFrames")]
    public Color flashColor = Color.red;
    private Color orignialColor = Color.white;
    private float flashDuration = 0.1f;

    public float Seconds;
    public bool invincible;

    private void OnEnable()
    {
        playerInputs.Enable(); 
    } //Function to start detecting keyboard/controller inputs.

    private void OnDisable()
    {
        playerInputs.Disable();
    } //Function to stop detecting keyboard/controller inputs.

    private void Awake()
    {
        playerInputs = new PlayerInputs(); //For input detection.
        rb = GetComponent<Rigidbody2D>(); //Get rigidbody from the gameObject.
        if (rb == null)
            Debug.LogError("No rigidbody on " + this.gameObject.name + "!!!"); //Throw an error if there isn't a rigidbody on the gameObject.
    }

    private void Start()
    {
        anim = GetComponent<Animator>(); //Get animator from the gameObject.
        sprite = GetComponent<SpriteRenderer>(); //Get spriteRenderer from the gameObject.
        mirAnim = MirrorPlayer.GetComponent<Animator>();
        mirSprite = MirrorPlayer.GetComponent<SpriteRenderer>();

        if (mirAnim == null) {
            Debug.LogError("NO MIRROR ANIM");
        }
        if (mirSprite == null) {
            Debug.LogError("NO MIRROR SPRITE");
        }
    }

    private void FixedUpdate()
    {

        MirrorPlayer.position = new Vector3(difference-transform.position.x, transform.position.y, 0);

        moveInput = playerInputs.Player.Movement.ReadValue<Vector2>(); //Detect the players inputs of WASD/Joystick.
        moveInput.Normalize(); //Normalize, this makes it so holding 2 keys doesn't make the movement any faster.

        if (moveInput.x >= 0.5f) {
            sprite.flipX = true;
        } else if (moveInput.x <= -0.5f) {
            sprite.flipX = false;
        }
        rb.velocity = moveInput * moveSpeed; //The actual movement of the player.
        animReset();

        if (moveInput == new Vector2(0, 0)) {
            anim.SetBool("Idle", true);
            mirAnim.SetBool("Idle", true);
        }
        if (moveInput.x >= 0.5)
        {
            anim.SetBool("WalkRight", true);
            mirAnim.SetBool("WalkLeft", true);
        }
        else if (moveInput.x <= -0.5) {
            anim.SetBool("WalkLeft", true);
            mirAnim.SetBool("WalkRight", true);
        }
        if (moveInput.y > 0.5) {
            anim.SetBool("WalkUp", true);
            mirAnim.SetBool("WalkUp", true);
        }
        else if (moveInput.y < -0.5)
        {
            anim.SetBool("WalkDown", true);
            mirAnim.SetBool("WalkDown", true);

        } //These 5 functions decide which animation to use.
    }

    private void animReset() {
        sprite.flipX = false;
        anim.SetBool("Idle", false);
        anim.SetBool("WalkUp", false);
        anim.SetBool("WalkDown", false);
        anim.SetBool("WalkLeft", false);
        anim.SetBool("WalkRight", false);

        mirSprite.flipX = false;
        mirAnim.SetBool("Idle", false);
        mirAnim.SetBool("WalkUp", false);
        mirAnim.SetBool("WalkDown", false);
        mirAnim.SetBool("WalkLeft", false);
        mirAnim.SetBool("WalkRight", false);
    } //Reset animations, incase we're now in a different state. (Eg.. WalkUp -> Idle)

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
            yield return new WaitForSeconds(Seconds);
            invincible = false;
            sprite.color = orignialColor;
        }
    }
}
