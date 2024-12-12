using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float damage = 5.0f;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            GameObject.Find("MaterialPlayer").GetComponent<PlayerHealth>().Damage(damage);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Void")) {
            Destroy(gameObject);
        }
    }
}
