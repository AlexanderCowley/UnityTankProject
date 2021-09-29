using System.Collections;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    bool _isAttacking = false;

    float _defaultSpeed = 1.2f;
    float _chargingSpeed = 3.2f;

    MeshRenderer _meshRenderer;
    Color _defaultColor;
    EnemyShoot _enemyWeapon;
    [SerializeField] Transform firePosition;
    [SerializeField] Projectile _enemyProjectile;
    Boss _bossCharacter;

    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultColor = _meshRenderer.material.color;
        _enemyWeapon = GetComponent<EnemyShoot>();
        _bossCharacter = GetComponent<Boss>();
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

        _meshRenderer.material.color = Color.blue;

        _enemyWeapon.FireWeapon(firePosition.transform,
            firePosition.transform.rotation, _enemyProjectile);

        yield return new WaitForSeconds(startingTime);

        _meshRenderer.material.color = _defaultColor;

        _isAttacking = false;
    }

    IEnumerator ChargeDelay(float startingTime)
    {
        if (_isAttacking)
            yield break;

        _isAttacking = true;

        print("charge");

        _bossCharacter.MovementSpeed = _chargingSpeed;
        _meshRenderer.material.color = Color.red;

        yield return new WaitForSeconds(startingTime);

        _bossCharacter.MovementSpeed = _defaultSpeed;

        _meshRenderer.material.color = _defaultColor;

        _isAttacking = false;
    }
}