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

    public float FireSpeed {get => _moveSpeed;}

    public int Damage {get => _damage;}

    IDamagable damagable;

    private void OnEnable()
    {
        ProjectileCollider = GetComponent<Collider>();
    }

    public void IgnoreSpawnerCollider(Shoot spawner = null, EnemyShoot enemyShoot = null)
    {
        Collider PlayerCollider;
        if (spawner != null)
            PlayerCollider = spawner.GetComponentInParent<Collider>();
        else
            PlayerCollider = enemyShoot.GetComponentInParent<Collider>();

        Physics.IgnoreCollision(ProjectileCollider, PlayerCollider);
    }

    public void DisableProjectile() => gameObject.SetActive(false);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<LineOfSightCollider>() != null)
            return;

        damagable = other.gameObject.GetComponent<IDamagable>();
        damagable?.OnImpact(0, this);

        PlayParicleEffect();
        PlaySFX();

        Coroutine_DisableDelay();
    }

    private void PlaySFX()
    {
        if (__collectedAudioClip != null)
        {
            AudioHelper.PlayClip2D(__collectedAudioClip, 1f);
        }
    }

    private void PlayParicleEffect()
    {
        if (_collectedParticles != null)
        {
            _collectedParticles = Instantiate(_collectedParticles,
                transform.position, Quaternion.identity);

            _collectedParticles.Play();
        }
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
            this.transform.forward * FireSpeed * Time.deltaTime;
    }

    private void Update()
    {
        LaunchProjectile();
    }
}
