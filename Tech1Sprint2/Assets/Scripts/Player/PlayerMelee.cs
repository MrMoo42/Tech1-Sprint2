using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMelee : MonoBehaviour
{
    [SerializeField] private Transform attackTransform;
    public float attackRange = 1.5f; //How large should the attack sphere be. (range)
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private GameObject hinge;

    public bool shouldDamage { get; private set; } = false;

    [SerializeField] private List<IDamageable> iDamageables = new List<IDamageable>();

    private RaycastHit2D[] hits;

    private Animator anim;

    public float damage = 10f; //Damage dealt on each swing.
    public float attackSpeed = 0.7f; //Time that needs to pass before Player can attack again.

    private float attackTimeCounter;

    AudioManager audioManager; // used to call the scene's audio manager

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        attackTimeCounter = attackSpeed;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.speed = 1.25f + (-1 * (attackSpeed - 0.5f));

        //Get Screen POS of Object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(hinge.transform.position);
        //Get Mouse POS
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //Get the Angle Between the Two Points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        //Rotate!
        hinge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        if (hinge.transform.rotation.w < Mathf.Abs(0.7f)) {
            sprite.flipY = true;
        } else if (hinge.transform.rotation.w > Mathf.Abs(0.7f)) {
            sprite.flipY = false;
        }

        if (UserInput.instance.controls.Player.Attack.WasPerformedThisFrame() && attackTimeCounter >= attackSpeed)
        {
            attackTimeCounter = 0f;
            audioManager.PlaySFX(audioManager.playerAttack); // play sfx when player attacks
            anim.SetTrigger("attack");
            //Attack();
        }

        attackTimeCounter += Time.deltaTime;
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }

    /*
        private void Attack()
        {
            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);
            for (int i = 0; i < hits.Length; i++) {
                EnemyHealth enemyHealth = hits[i].collider.gameObject.GetComponent<EnemyHealth>();

                IDamageable iDamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();

                if (iDamageable != null) {
                    iDamageable.Damage(damage);
                }
            }
        }  
    */

    public IEnumerator DamageWhileMeleeActive()
    {
        shouldDamage = true;

        while (shouldDamage)
        {
            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right * -1, 0f, attackableLayer);
            for (int i = 0; i < hits.Length; i++)
            {
                EnemyHealth enemyHealth = hits[i].collider.gameObject.GetComponent<EnemyHealth>();

                IDamageable iDamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();

                if (iDamageable != null && !iDamageable.HasTakenDamage)
                {
                    iDamageable.Damage(damage);
                    iDamageables.Add(iDamageable);
                }
            }
            yield return null;
        }
        ReturnAttackablesToDamagable();
    }

    private void ReturnAttackablesToDamagable() {
        foreach (IDamageable thingThatWasDamaged in iDamageables) {
            thingThatWasDamaged.HasTakenDamage = false;
        }

        iDamageables.Clear();
    }

    public void ShouldDamageTrue() { 
        shouldDamage = true;
    }

    public void ShouldDamageFalse() {
        shouldDamage = false;
    }
}
