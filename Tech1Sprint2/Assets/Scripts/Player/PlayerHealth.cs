using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PlayerHealth : MonoBehaviour, IDamageable //Referencing IDamageable, because the player is damageable.
{
    public float maxHealth = 100; //Maxiumum health of player, can be modified.
    public float health; //Current health of player.
    public Image HPBar; //HP bar UI
    public bool HasTakenDamage { get; set; } //Is the player in the process of taking damage?

    public PlayerUpgradeManager PUM;

    AudioManager audioManager; // used to call the scene's audio manager

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        health = maxHealth; //Set the starting health of our player.
    }

    public void Damage(float amt) {
        health -= amt;

        if (health <= 0)
        {
            audioManager.PlaySFX(audioManager.playerDeath); // play sfx when player dies
            Die();
        }
        else
        {
            audioManager.PlaySFX(audioManager.hitPlayer); // play sfx when player is hit but doesn't die
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
        //DataStorage.instance.ClearUpgradeStorage();
    } //What to do if the player has died.

    void Update()
    {
        HPBar.fillAmount = health / maxHealth;
    }
}
