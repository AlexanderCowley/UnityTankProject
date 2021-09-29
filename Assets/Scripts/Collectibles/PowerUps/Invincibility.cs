using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{

    Color _currentColor;
    Color _initialColor = new Color(69, 195, 56);
    [SerializeField] Color _powerUpColor;

    protected override void PowerUp(Player player)
    {
        base.PowerUp(player);
        _initialColor = player.GetComponentInChildren<MeshRenderer>().material.color;
       _currentColor = _powerUpColor;
        ProtectPlayer(player);
    }

    protected override void PowerDown(Player player)
    {
        base.PowerDown(player);

        _currentColor = _initialColor;
        UpdatePlayer(player);
        MakeVulnerable(player);
    }

    void ProtectPlayer(Player player) => player.IsInvinsible = true;

    void MakeVulnerable(Player player) => player.IsInvinsible = false;

    protected override void UpdatePlayer(Player playerCharacter)
    {
        base.UpdatePlayer(playerCharacter);

        MeshRenderer meshRenderer = playerCharacter.GetComponentInChildren<MeshRenderer>();
        meshRenderer.material.color = _currentColor;
    }
}
