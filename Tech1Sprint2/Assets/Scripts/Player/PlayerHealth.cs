using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable //Referencing IDamageable, because the player is damageable.
{
    public float maxHealth = 100; //Maxiumum health of player, can be modified.
    private float health; //Current health of player.
    public bool HasTakenDamage { get; set; } //Is the player in the process of taking damage?

    private void Start()
    {
        health = maxHealth; //Set the starting health of our player.
    }

    public void Damage(float amt) {
        health -= amt;

        if (health <= 0) {
            Die();
        }
    } //Damage function so we don't have to change the value directly. Also checks if player is dead.

    public void Heal(bool percent = false, float amt = 0) {
        if (percent == false) {
            health += amt;
        } else {
            health += maxHealth / amt;
        }
        if (health > maxHealth) {
            health = maxHealth;
        }
    } //Heal function, so we don't have to change the value directly. Can do flat numbers or percentages.

    public void Die() {
        SceneManager.LoadScene(0);
    } //What to do if the player has died.
}
