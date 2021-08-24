using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    int _damageAmount = 1;
    [SerializeField]
    ParticleSystem _impactParticles;
    [SerializeField]
    AudioClip _impactSound;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        {
            PlayerImpact(player);
            ImpactFeedback();
        }
    }

    protected virtual void PlayerImpact(Player player)
    {
        player.decreaseHealth(_damageAmount);
    }

    void ImpactFeedback()
    {
        if(_impactParticles != null)
        {
            _impactParticles = Instantiate(_impactParticles, 
                transform.position, Quaternion.identity);
        }

        if (_impactSound != null)
        {
            AudioHelper.PlayClip2D(_impactSound, 1);
        }
    }

    public void Move()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }
}
