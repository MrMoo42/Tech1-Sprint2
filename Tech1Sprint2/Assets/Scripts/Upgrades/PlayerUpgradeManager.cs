using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeManager : MonoBehaviour
{
    public List<Upgrade> upgrades;

    [SerializeField] private PlayerHealth health;
    [SerializeField] private PlayerMelee melee;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private MirPlayerMovement mirrorMovement;

    public void AddUpgrade(Upgrade n) {
        switch (n.Type) {
            case Upgrade.UpgradeType.MaxHealth:
                health.maxHealth += n.upgradeValue;
                upgrades.Add(n);
                break;
            case Upgrade.UpgradeType.MoveSpeed:
                movement.moveSpeed += n.upgradeValue;
                mirrorMovement.moveSpeed += n.upgradeValue;
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
