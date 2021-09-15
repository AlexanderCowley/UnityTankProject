using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int _damage;
    [SerializeField] float _moveSpeed;

    [SerializeField] float disableDelay;

    Collider ProjectileCollider;

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

    public void IgnoreSpawnerCollider(Shoot spawner)
    {
        Collider PlayerCollider = 
            spawner.GetComponentInParent<Collider>();

        Physics.IgnoreCollision(ProjectileCollider, PlayerCollider);
    }

    public void DisableProjectile() => gameObject.SetActive(false);

    private void OnTriggerEnter(Collider other)
    {
        damagable = other.gameObject.GetComponent<IDamagable>();
        damagable?.OnImpact(0, this);

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
