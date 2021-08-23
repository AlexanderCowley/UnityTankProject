using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField]
    int _maxHealth;
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
    }

    public void decreaseHealth(int amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
}
