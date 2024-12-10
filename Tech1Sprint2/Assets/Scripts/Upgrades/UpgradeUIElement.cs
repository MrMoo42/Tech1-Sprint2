using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIElement : MonoBehaviour
{
    public Upgrade upgrade;
    public int amount;

    private Transform img;
    private Transform amt;

    private void Awake() {
        img = transform.Find("Img");
        amt = transform.Find("Amt");

        UpdateUI();
    }

    public void UpdateUI() {
        if (amount == 0) {
            gameObject.SetActive(false);
        } else {
            gameObject.SetActive(true);
        }
        if (amount > 99) {
            amount = 99;
        }

        img.GetComponent<Image>().sprite = upgrade.sprite;
        amt.GetComponent<TextMeshProUGUI>().text = (amount.ToString());
    }
}
