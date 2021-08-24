using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Health : CollectibleBase
{
    [SerializeField]
    int _valueAmount;
    protected override void Collect(Player player)
    {
        player.increaseHealth(_valueAmount);
    }
}
