using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDrop : MonoBehaviour
{
    public Upgrade upgrade;
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = upgrade.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;

        if (obj.transform.CompareTag("Player")) {
            PlayerUpgradeManager PUM = obj.GetComponent<PlayerUpgradeManager>();
            PUM.AddUpgrade(upgrade);
            Destroy(gameObject);
        }
    }
}
