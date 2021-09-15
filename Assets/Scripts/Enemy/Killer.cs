using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : Enemy
{
    protected override void PlayerImpact(IDamagable player)
    {
        player.OnImpact(3);
    }
}
