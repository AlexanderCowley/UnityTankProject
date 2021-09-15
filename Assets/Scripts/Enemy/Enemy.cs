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
        IDamagable player = collision.gameObject.GetComponent<IDamagable>();
        if(player != null)
        {
            ImpactFeedback();
            PlayerImpact(player);
        }
    }

    protected virtual void PlayerImpact(IDamagable player)
    {
        player.OnImpact(_damageAmount);
    }

    void ImpactFeedback()
    {
        if (_impactParticles != null)
        {
            _impactParticles = Instantiate(_impactParticles, 
                transform.position, Quaternion.identity);
            _impactParticles.Play();
        }

        if (_impactSound != null)
        {
            AudioHelper.PlayClip2D(_impactSound, 1);
        }
    }

    public virtual void Move()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }
}
