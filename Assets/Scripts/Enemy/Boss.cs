using System.Collections;
using UnityEngine;

public class Boss : Enemy
{
    bool _isPlayerDetected = false;
    float _movementSpeed;
    float _defaultSpeed = 1.2f;
    float _chargingSpeed = 4f;

    bool _isAttacking = false;

    [SerializeField] TankController player;

    [SerializeField] Projectile enemyProjectile;

    EnemyShoot enemyWeapon;

    [SerializeField] Transform firePosition;

    MeshRenderer mesh_renderer;
    Color _defaultColor;
    Color _attackColor;
    Color _delayColor;

    

    float distanceToTarget = 3f;
    Vector3 startingPos;
    public bool IsPlayerDetected
    {
        set => _isPlayerDetected = value;
    }

    void Awake()
    {
        mesh_renderer = GetComponent<MeshRenderer>();
        _defaultColor = mesh_renderer.material.color;

        startingPos = transform.position;
        _movementSpeed = _defaultSpeed;
        enemyWeapon = GetComponentInChildren<EnemyShoot>();
    }

    public override void Move()
    {
        if (!_isPlayerDetected)
            MoveBackAndForth();
        else
            TargetPlayer();
    }

    //Patrol
    void MoveBackAndForth()
    {
        Vector3 velocity = startingPos;
        velocity.x += distanceToTarget * Mathf.Sin(Time.time * _movementSpeed);
        transform.position = velocity;
    }

    //Chase Target and method to decide attacks
    void TargetPlayer()
    {
        transform.position = Vector3.MoveTowards
            (transform.position, player.transform.position, _movementSpeed * Time.deltaTime);

        AttackPlayer();
    }

    bool InPlayerRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        return distanceToPlayer <= 15f;
    }

    void AttackPlayer()
    {
        if (InPlayerRange())
            Charge();
        //else
            //ShootProjectile();
    }

    void Charge()
    {
        if (!_isAttacking)
        {
            _isAttacking = true;

            StartCoroutine(attackDelay(.5f));
            _movementSpeed = _chargingSpeed;
            StartCoroutine(attackDelay(2f));

            _movementSpeed = _defaultSpeed;
            _isAttacking = false;

            mesh_renderer.material.color = _defaultColor;
        }
    }

    void ShootProjectile()
    {
        if (!_isAttacking)
        {
            _isAttacking = true;

            StartCoroutine(attackDelay(.5f));
            FireWeapon();
            //fx
            StartCoroutine(attackDelay(2f));
            //end things
            _isAttacking = false;
            //fx = power down
        }
    }

    void FireWeapon()
    {
        enemyWeapon.FireWeapon(firePosition.transform, 
            firePosition.transform.rotation, enemyProjectile);
    }

    IEnumerator attackDelay(float delayTimer)
    {
        mesh_renderer.material.color = Color.red;
        yield return new WaitForSeconds(delayTimer);
    }
}