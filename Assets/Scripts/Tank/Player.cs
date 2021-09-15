using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField]
    int _maxHealth = 3;
    [SerializeField]
    int _currentHealth;
    bool isInvinsible;
    public bool IsInvinsible
    {
        set => isInvinsible = value;
    }

    public void increaseHealth(int amount) => _currentHealth += amount;

    public void decreaseHealth(int amount)
    {
        if (isInvinsible)
            return;

        _currentHealth -= amount;

        if (_currentHealth <= 0)
            Die();
    }

    public void Die() => gameObject.SetActive(false);
}
