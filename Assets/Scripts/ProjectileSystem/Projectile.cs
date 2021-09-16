using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int _damage;
    [SerializeField] float _moveSpeed;

    [SerializeField] float disableDelay;

    Collider ProjectileCollider;

    [SerializeField]
    ParticleSystem _collectedParticles;

    [SerializeField]
    AudioClip __collectedAudioClip;

    public float FireSpeed
    {
        get => _moveSpeed;
    }

    public int Damage 
    { 
        get => _damage;
    }

    IDamagable damagable;

    private void OnEnable()
    {
        ProjectileCollider = GetComponent<Collider>();
    }

    public void IgnoreSpawnerCollider(Shoot spawner = null)
    {
        Collider PlayerCollider = spawner.GetComponentInParent<Collider>();

        Physics.IgnoreCollision(ProjectileCollider, PlayerCollider);
    }

    public void DisableProjectile() => gameObject.SetActive(false);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<LineOfSightCollider>() != null)
            return;

        damagable = other.gameObject.GetComponent<IDamagable>();
        damagable?.OnImpact(0, this);

        if (_collectedParticles != null)
        {
            _collectedParticles = Instantiate(_collectedParticles,
                transform.position, Quaternion.identity);

            _collectedParticles.Play();
        }

        if (__collectedAudioClip != null)
        {
            AudioHelper.PlayClip2D(__collectedAudioClip, 1f);
        }
        Coroutine_DisableDelay();
    }

    void Coroutine_DisableDelay() => StartCoroutine(DisableDelay(disableDelay));

    IEnumerator DisableDelay(float delay)
    {
        float normalizedTime = 0f;
        while(normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / delay;
            yield return null;
        }
        DisableProjectile();
    }

    void LaunchProjectile()
    {
        this.transform.position +=
            transform.forward * FireSpeed * Time.deltaTime;
    }

    private void Update()
    {
        LaunchProjectile();
    }
}
