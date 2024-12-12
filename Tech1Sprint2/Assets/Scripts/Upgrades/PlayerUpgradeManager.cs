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
        for (int i = 0; i < DataStorage.upgradeStorage.Count; i++)
        {
            AddUpgrade(DataStorage.upgradeStorage[i]);
        }
    }

    public void AddUpgrade(Upgrade n) {
        switch (n.Type) {
            case Upgrade.UpgradeType.MaxHealth:
                health.maxHealth += n.upgradeValue;
                upgrades.Add(n);

                MaxHealthUI.SetActive(true);
                UpgradeUIElement uiElement = MaxHealthUI.GetComponent<UpgradeUIElement>();
                uiElement.amount += 1;
                uiElement.UpdateUI();
                
                break;
            case Upgrade.UpgradeType.MoveSpeed:
                movement.moveSpeed += n.upgradeValue;
                upgrades.Add(n);
                break;
            case Upgrade.UpgradeType.AttackDamage:
                melee.damage += n.upgradeValue;
                upgrades.Add(n);
                break;
            case Upgrade.UpgradeType.AttackSpeed:
                melee.attackSpeed -= n.upgradeValue;
                upgrades.Add(n);
                break;
            case Upgrade.UpgradeType.AttackRange:
                melee.attackRange += n.upgradeValue;
                upgrades.Add(n);
                break;
            default:
                Debug.LogError(n.Type + " is not recognized as an upgrade type.");
                break;
        }
    }
}
