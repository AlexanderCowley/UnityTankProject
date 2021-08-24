using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_SpeedIncrease : CollectibleBase
{
    [SerializeField]
    float _valueAmount = 1;

    protected override void Collect(Player player)
    {
        TankController tankController = player.GetComponent<TankController>();
        if(tankController != null)
        {
            tankController.MoveSpeed += _valueAmount;
        }
    }

    protected override void Movement(Rigidbody rb)
    {
        Quaternion turnOffSet = 
            Quaternion.Euler(MovementSpeed, MovementSpeed, MovementSpeed);
        rb.MoveRotation(rb.rotation * turnOffSet);
    }
}
