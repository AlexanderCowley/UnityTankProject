using System.Collections;
using UnityEngine;

public class Boss : Enemy
{
    bool _isPlayerDetected = false;
    float _movementSpeed;
    float _defaultSpeed = 1.2f;

    [SerializeField] TankController player;

    BossAttacks _attacks;

    float distanceToTarget = 3f;
    Vector3 startingPos;
    public bool IsPlayerDetected
    {
        set => _isPlayerDetected = value;
    }

    void Awake()
    {
        _attacks = GetComponent<BossAttacks>();

        startingPos = transform.position;
        _movementSpeed = _defaultSpeed;
    }

    public override void Move()
    {
        if (!_isPlayerDetected)
            Patrol();
        else
            TargetPlayer();
    }

    //Patrol
    void Patrol()
    {
        Vector3 velocity = startingPos;
        velocity.x += distanceToTarget * Mathf.Sin(Time.time * _movementSpeed);
        transform.position = velocity;
    }

    void TargetPlayer()
    {
        transform.position = Vector3.MoveTowards
            (transform.position, player.transform.position, _movementSpeed * Time.deltaTime);

        RotateToPlayer();

        AttackPlayer();
    }

    private void RotateToPlayer()
    {
        Vector3 DirectionToFace = player.transform.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(DirectionToFace);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
            _movementSpeed * Time.deltaTime);
    }

    bool InPlayerRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        return distanceToPlayer <= 5f;
    }

    void AttackPlayer()
    {
        if (InPlayerRange())
            _attacks.Charge();
        else
            _attacks.ShootProjectile();
    }
}