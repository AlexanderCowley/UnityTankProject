using UnityEngine;

public class Slower : Enemy
{
    [SerializeField] float amount;
    protected override void PlayerImpact(Player player)
    {
        TankController controller = player.GetComponent<TankController>();
        controller.MoveSpeed -= amount;
    }
}
