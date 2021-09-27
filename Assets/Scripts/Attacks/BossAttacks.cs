using System.Collections;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    bool _isAttacking = false;

    float _movementSpeed;
    float _defaultSpeed;
    float _chargingSpeed;

    MeshRenderer _meshRenderer;
    Color _defaultColor;
    EnemyShoot _enemyWeapon;
    [SerializeField] Transform firePosition;
    [SerializeField] Projectile _enemyProjectile;

    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultColor = _meshRenderer.material.color;
        _enemyWeapon = GetComponent<EnemyShoot>();
    }

    public void Charge()
    {
        if (_isAttacking)
            return;

        StartCoroutine(ChargeDelay(2f));
    }

    public void ShootProjectile()
    {

        FireWeapon();
        //fx
        //end things
        //fx = power down
    }

    void FireWeapon()
    {
        StartCoroutine(FireRateDelay(2f));
    }

    IEnumerator FireRateDelay(float startingTime)
    {
        if (_isAttacking)
            yield break;

        _isAttacking = true;

        print("fire");

        _enemyWeapon.FireWeapon(firePosition.transform,
            firePosition.transform.rotation, _enemyProjectile);

        yield return new WaitForSeconds(startingTime);

        _isAttacking = false;
    }

    IEnumerator ChargeDelay(float startingTime)
    {
        if (_isAttacking)
            yield break;

        _isAttacking = true;

        print("charge");

        _movementSpeed = _chargingSpeed;

        yield return new WaitForSeconds(startingTime);

        _movementSpeed = _defaultSpeed;

        _isAttacking = false;
    }
}