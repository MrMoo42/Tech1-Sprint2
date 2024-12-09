using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public bool isPercent = false; //Is this health pickup a percentage value?
    public float amt = 10; //How much to heal?

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.transform.CompareTag("Player")) { //Check if the object entering the trigger is a player. (Material or Mirror)
            obj = GameObject.Find("MaterialPlayer"); //Find the material player, as that's the one with the health.
            obj.GetComponent<PlayerHealth>().Heal(isPercent, amt); //Run the heal function in "PlayerHealth.cs"
            Destroy(gameObject); //Destroy the health pickup so it's used up.
        }
    }
}
