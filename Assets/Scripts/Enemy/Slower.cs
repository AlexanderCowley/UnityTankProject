using UnityEngine;

public class Slower : Enemy
{
    [SerializeField] float amount;
    protected override void PlayerImpact(IDamagable player)
    {
        //TankController controller = player.GetComponent<TankController>();
        //controller.MoveSpeed -= amount;
    }
}
