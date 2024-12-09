using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void Damage(float amt);

    public bool HasTakenDamage { get; set; }
} //Simple interface for other scripts to use. Helps regulate damage.
