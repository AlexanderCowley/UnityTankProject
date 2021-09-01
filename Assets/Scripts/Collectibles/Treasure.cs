using UnityEngine;

public class Treasure : CollectibleBase
{
    [SerializeField]
    int amount;

    protected override void Collect(Player player)
    {
        TankController tankController = player.GetComponent<TankController>();
        if (tankController != null)
        {
            tankController.TreasureCount += amount;
        }
    }
}
