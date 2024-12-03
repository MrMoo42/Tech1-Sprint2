using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
    public float health;

    public bool HasTakenDamage { get; set; }

    private void Awake()
    {
        health = maxHealth;
    }

    public void Damage(float amt)
    {
        HasTakenDamage = true;

        health -= amt;

        if (health <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
