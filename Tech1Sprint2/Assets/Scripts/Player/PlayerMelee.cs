using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attackableLayer;

    public bool shouldDamage { get; private set; } = false;

    [SerializeField] private List<IDamageable> iDamageables = new List<IDamageable>();

    private RaycastHit2D[] hits;

    private Animator anim;

    public float damage = 10f;
    public float attackSpeed = 0.5f;

    private float attackTimeCounter;


    private void Start()
    {
        attackTimeCounter = attackSpeed;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (UserInput.instance.controls.Player.Attack.WasPerformedThisFrame() && attackTimeCounter >= attackSpeed)
        {
            attackTimeCounter = 0f;
            anim.SetTrigger("attack");
            //Attack();
        }

        attackTimeCounter += Time.deltaTime;
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
                    Debug.Log("Smack!");
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
