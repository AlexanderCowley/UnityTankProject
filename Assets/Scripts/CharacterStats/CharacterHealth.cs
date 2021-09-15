using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour, IDamagable
{
    [SerializeField]
    int _maxHealth = 3;
    [SerializeField]
    int _currentHealth;

    public delegate void OnDeath();
    public event OnDeath DeathEvent;

    private void Awake()
    {
        InitStat();
        InitDeathEvent();
    }

    private void InitStat()
    {
        _currentHealth = _maxHealth;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
    }

    private void InitDeathEvent()
    {
        DeathEvent += CharacterDeath;
    }

    public void OnImpact(int damageAmount = 0, Projectile projectile = null)
    {
        if (damageAmount == 0)
            damageAmount = projectile.Damage;

        _currentHealth -= damageAmount;
        if (_currentHealth <= 0)
            DeathEvent?.Invoke();
    }

    void CharacterDeath() => gameObject.SetActive(false);
}
