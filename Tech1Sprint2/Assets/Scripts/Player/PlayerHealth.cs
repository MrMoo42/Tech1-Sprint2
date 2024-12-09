using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public float maxHealth = 100;
    private float health;
    public bool HasTakenDamage { get; set; }

    private void Start()
    {
        health = maxHealth;
    }

    public void Damage(float amt) {
        health -= amt;

        if (health <= 0) {
            Die();
        }
    }

    public void Heal(bool percent = false, float amt = 0) {
        if (percent == false) {
            health += amt;
        } else {
            health += maxHealth / amt;
        }
        if (health > maxHealth) {
            health = maxHealth;
        }
    }

    public void Die() {
        SceneManager.LoadScene(0);
    }
}
