using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void OnImpact(int damageAmount = 0, Projectile projectile = null);
}