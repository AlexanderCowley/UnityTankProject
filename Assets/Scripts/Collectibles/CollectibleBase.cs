using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class CollectibleBase : MonoBehaviour
{
    protected abstract void Collect(Player player);

    [SerializeField]
    float _movementSpeed = 1f;
    protected float MovementSpeed => _movementSpeed;

    Rigidbody rigidBody;

    [SerializeField]
    ParticleSystem _collectedParticles;

    [SerializeField]
    AudioClip __collectedAudioClip;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    protected virtual void Movement(Rigidbody rb)
    {
        Quaternion turnOffset = Quaternion.Euler(0f, _movementSpeed, 0f);
        rb.MoveRotation(rb.rotation * turnOffset);
    }

    void Feedback()
    {
        if(_collectedParticles != null)
        {
            _collectedParticles = Instantiate(_collectedParticles,
                transform.position, Quaternion.identity);

            _collectedParticles.Play();
        }

        if (__collectedAudioClip != null)
        {
            AudioHelper.PlayClip2D(__collectedAudioClip, 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if(player != null)
        {
            Collect(player);
            Feedback();

            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        Movement(rigidBody);
    }
}
