using UnityEngine;

public class Boss : Enemy
{

    bool _isPlayerDetected = false;
    [SerializeField] float _movementSpeed;

    float normalizedTime;
    float directionChangeTime = 3f;
    public bool IsPlayerDetected
    {
        set => _isPlayerDetected = value;
    }

    void Awake()
    {
        
    }

    public override void Move()
    {
        if (!_isPlayerDetected)
            GoToTarget();
        else
            TargetPlayer();
    }

    void GoToTarget()
    {
        print("go to target");
        Vector3 currentTarget = FindDirection();
        float distance = Vector3.Distance(currentTarget, transform.position);
        print(distance);

        while(distance > 10f)
        {
            transform.position = Vector3.Lerp
                (transform.position, currentTarget, _movementSpeed * Time.deltaTime);
        }
        
    }

    Vector3 FindDirection()
    {
        Vector3 randomDir = 
            new Vector3(transform.position.x + Random.Range(-1, 1f), 
            transform.position.y,
            transform.position.z + Random.Range(-1, 1f));
        randomDir *= 3f;
        randomDir.y = transform.position.y;

        return randomDir;
    }

    void TargetPlayer()
    {
        print("huh");
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

    //Move between them

    //Player In Range of Melee Attack

    //Projectile Attack

    //Charge Attack
}