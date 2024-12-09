using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
    public float health;
    [SerializeField] private GameObject healthPickup;
    public int healthPickupChance = 5; //Out of a hundred.

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
        int n = Random.Range(0, 100); ;

        if (n <= healthPickupChance) {
            SpawnHealthPickup();
        }

        Destroy(gameObject);
    }

    private void SpawnHealthPickup() {
        float x = Random.Range (4.5f, 12.2f);
        float y = Random.Range(2, -5.5f);

        Instantiate(healthPickup, new Vector2(x, y), Quaternion.identity, transform.parent);
    }
}
