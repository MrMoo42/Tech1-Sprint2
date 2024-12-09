using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public bool isPercent = false;
    public float amt = 10;

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.transform.CompareTag("Player")) {
            obj = GameObject.Find("MaterialPlayer");
            obj.GetComponent<PlayerHealth>().Heal(isPercent, amt);
            Destroy(gameObject);
        }
    }
}
