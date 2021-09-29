using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] Projectile _obj_projectile;

    [SerializeField]
    ParticleSystem _collectedParticles;

    [SerializeField]
    AudioClip __collectedAudioClip;
    public void FireWeapon(Transform firePos, Quaternion fireRot, Projectile projectile)
    {
        PlaySFX();
        PlayParicleEffect();

        projectile = Instantiate
            (projectile, firePos.position, fireRot);

        projectile.IgnoreSpawnerCollider(null, this);
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
}