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
    TankController _tankController;

    private void Awake() => _tankController = GetComponent<TankController>();

    void Start()
    {
        _currentHealth = _maxHealth;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
    }

    public void increaseHealth(int amount)
    {
        _currentHealth += amount;
        print(_currentHealth);
    }

    public void decreaseHealth(int amount)
    {
        if (isInvinsible)
            return;

        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        print("Dead");
        gameObject.SetActive(false);
    }
}
