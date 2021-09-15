using System.Collections;
using UnityEngine;

public class Boss : Enemy
{
    bool _isPlayerDetected = false;
    [SerializeField] float _movementSpeed;

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
    }

    /*bool InPlayerRange()
    {

        return 
    }*/

    void AttackPlayer()
    {
        //if(InPlayerRange())
            //Charge Player
        //else
            //ShootProjectile
    }

    //Player In Range of Melee Attack

    //Projectile Attack

    //Charge Attack
}