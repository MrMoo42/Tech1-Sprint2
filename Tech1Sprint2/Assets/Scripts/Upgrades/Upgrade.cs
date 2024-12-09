using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrade {
    public enum UpgradeType { MaxHealth, AttackDamage, AttackSpeed, AttackRange, MoveSpeed };
    public UpgradeType Type;

    public float upgradeValue;
    public Sprite sprite;
}
