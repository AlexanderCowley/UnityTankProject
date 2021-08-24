using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField]
    int _maxHealth = 3;
    int _currentHealth;
    TankController _tankController;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }

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
        _currentHealth -= amount;
        print(_currentHealth);

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
