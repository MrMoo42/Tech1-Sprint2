using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth; //Max health of enemy.
    public float health; //Current health of enemy.

    [SerializeField] private GameObject healthPickup; //What health pickup object does this enemy drop?

    public int healthPickupChance = 5; //Out of a hundred.

    public bool HasTakenDamage { get; set; } //Used to make sure the enemy gets hit only once by a single attack.

    AudioManager audioManager; // used to call the scene's audio manager

    public EndLevel killCount; // calls the script that counts how many enemies have been killed
    
    private void Awake()
    {
        health = maxHealth; //Set the starting health for the enemy.
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Damage(float amt)
    {
        HasTakenDamage = true;

        health -= amt;

        if (health <= 0) {
            audioManager.PlaySFX(audioManager.enemyDeath); // play sfx when enemy dies
            Die();
        }
        else
        {
            audioManager.PlaySFX(audioManager.hitEnemy); // play sfx when enemy is hit but doesn't die
        }
    } //Damage function, also checks for death.

    private void Die() {
        int n = Random.Range(0, 100); ;

        if (n <= healthPickupChance) {
            SpawnHealthPickup();
        }

        killCount.EnemyKilled(); // tells the end level script another enemy has been killed

        Destroy(gameObject);
    } //What happens when the enemy dies?

    private void SpawnHealthPickup() {
        float x = Random.Range (4.5f, 12.2f);
        float y = Random.Range(2, -5.5f);

        Instantiate(healthPickup, new Vector2(x, y), Quaternion.identity, transform.parent);
    } //Function to spawn a health pickup at a random position in the mirror world.
}
