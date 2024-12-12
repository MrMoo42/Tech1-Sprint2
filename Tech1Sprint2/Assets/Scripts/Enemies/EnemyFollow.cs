using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target;
    private float distance;
    public float speed = 4.2f;
    public float damage = 5;
    private SpriteRenderer sprite;

    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
        if (target == null)
            target = GameObject.Find("MaterialPlayer").transform;
    }

    private void Update() {
        distance = Vector3.Distance(transform.position, target.position);
        if (target.position.x > transform.position.x) {
            sprite.flipX = true;
        } else {
            sprite.flipX = false;
        }


        if (target != null && distance >= 0.5f) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 0.5f * speed * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Player")) {
            PlayerMovement playerMove = obj.GetComponent<PlayerMovement>();
            PlayerHealth playerHP = obj.GetComponent<PlayerHealth>();
            if (!playerMove.invincible) // deal damage only if i frames are inactive
            {
                playerHP.Damage(damage);
                StartCoroutine(playerMove.FlashDamage()); // start flashing and i frames
            }
        }
    }
}
