using System.Collections;
using UnityEngine;

public class Boss : Enemy
{
    bool _isPlayerDetected = false;
    float _movementSpeed;
    float _defaultSpeed = .75f;
    float _chargingSpeed = 1.4f;

    bool _isAttacking = false;

    [SerializeField] TankController player;

    float distanceToTarget = 3f;
    Vector3 startingPos;
    public bool IsPlayerDetected
    {
        set => _isPlayerDetected = value;
    }

    void Awake()
    {
        startingPos = transform.position;
        _movementSpeed = _defaultSpeed;
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
        print("huh");
        transform.position = Vector3.MoveTowards
            (transform.position, player.transform.position, _movementSpeed * Time.deltaTime);

        AttackPlayer();
    }

    bool InPlayerRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        return distanceToPlayer <= 3f;
    }

    void AttackPlayer()
    {
        if (InPlayerRange())
            Charge();
        else
            ShootProjectile();
    }

    void Charge()
    {
        if (!_isAttacking)
        {
            _isAttacking = true;

            StartCoroutine(attackDelay(.5f));
            _movementSpeed = _chargingSpeed;
            //fx
            StartCoroutine(attackDelay(2f));
            _movementSpeed = _defaultSpeed;
            _isAttacking = false;
            //fx = power down
        }
    }

    void ShootProjectile()
    {
        print("wha");
        if (!_isAttacking)
        {
            _isAttacking = true;

            StartCoroutine(attackDelay(.5f));
            // things
            //fx
            StartCoroutine(attackDelay(2f));
            //end things
            _isAttacking = false;
            //fx = power down
        }
    }

    IEnumerator attackDelay(float delayTimer)
    {
        yield return new WaitForSeconds(delayTimer);
        print("finished");
        yield return null;
    }

    //Projectile Attack
}