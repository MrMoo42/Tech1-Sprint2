using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeManager : MonoBehaviour
{
    public List<Upgrade> upgrades;

    [SerializeField] private PlayerHealth health;
    [SerializeField] private PlayerMelee melee;
    [SerializeField] private PlayerMovement movement;

    [SerializeField] private GameObject MaxHealthUI, MoveSpeedUI, AttackDamageUI, AttackSpeedUI, AttackRangeUI;

    void Start()
    {
        if (DataStorage.upgradeStorage.Count != null) {
            for (int i = 0; i < DataStorage.upgradeStorage.Count; i++) {
                AddUpgrade(DataStorage.upgradeStorage[i]);
            }
        }
    }

    public void AddUpgrade(Upgrade n) {
        switch (n.Type) {
            case Upgrade.UpgradeType.MaxHealth:
                health.maxHealth += n.upgradeValue;
                upgrades.Add(n);
                health.Heal(false, n.upgradeValue);

                MaxHealthUI.SetActive(true);
                UpgradeUIElement maxHPUIElement = MaxHealthUI.GetComponent<UpgradeUIElement>();
                maxHPUIElement.amount += 1;
                maxHPUIElement.UpdateUI();
                
                break;
            case Upgrade.UpgradeType.MoveSpeed:
                movement.moveSpeed += n.upgradeValue;
                upgrades.Add(n);

                MoveSpeedUI.SetActive(true);
                UpgradeUIElement mvmtUIElement = MoveSpeedUI.GetComponent<UpgradeUIElement>();
                mvmtUIElement.amount += 1;
                mvmtUIElement.UpdateUI();
                break;
            case Upgrade.UpgradeType.AttackDamage:
                melee.damage += n.upgradeValue;
                upgrades.Add(n);

                AttackDamageUI.SetActive(true);
                UpgradeUIElement attkUIElement = AttackDamageUI.GetComponent<UpgradeUIElement>();
                attkUIElement.amount += 1;
                attkUIElement.UpdateUI(); 
                
                break;
            case Upgrade.UpgradeType.AttackSpeed:
                melee.attackSpeed += n.upgradeValue;
                upgrades.Add(n);
                if (melee.attackSpeed < 0.1f) {
                    melee.attackSpeed = 0.1f;
                }

                AttackSpeedUI.SetActive(true);
                UpgradeUIElement atkSpeedUIElement = AttackSpeedUI.GetComponent<UpgradeUIElement>();
                atkSpeedUIElement.amount += 1;
                atkSpeedUIElement.UpdateUI();

                break;
            case Upgrade.UpgradeType.AttackRange:
                melee.attackRange += n.upgradeValue;
                upgrades.Add(n);

                AttackRangeUI.SetActive(true);
                UpgradeUIElement rangeUIElement = AttackRangeUI.GetComponent<UpgradeUIElement>();
                rangeUIElement.amount += 1;
                rangeUIElement.UpdateUI();

                break;
            default:
                Debug.LogError(n.Type + " is not recognized as an upgrade type.");
                break;
        }
    }
}
