using UnityEngine;

public class LineOfSightCollider : MonoBehaviour
{
    TankController playerController;
    Boss bossCharacter;
    void Awake()
    {
        bossCharacter = GetComponentInParent<Boss>();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerController = other.GetComponent<TankController>();

        if (playerController != null)
        {
            bossCharacter.IsPlayerDetected = true;
        }
            
    }
}