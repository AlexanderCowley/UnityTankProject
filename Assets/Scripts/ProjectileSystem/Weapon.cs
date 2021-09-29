using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Projectile _obj_projectile;
    [SerializeField] Transform firePos;

    [SerializeField]
    ParticleSystem _collectedParticles;

    [SerializeField]
    AudioClip __collectedAudioClip;
    public void FireWeapon(Transform firePos, Quaternion fireRot, Projectile projectile)
    {
        if (_collectedParticles != null)
        {
            _collectedParticles = Instantiate(_collectedParticles,
                transform.position, Quaternion.identity);
            _collectedParticles.Play();
        }

        if(__collectedAudioClip != null)
        {
            AudioHelper.PlayClip2D(__collectedAudioClip, 1f);
        }

        _obj_projectile = Instantiate
            (_obj_projectile, firePos.position, fireRot);

        _obj_projectile.IgnoreSpawnerCollider(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            FireWeapon(firePos, firePos.rotation, _obj_projectile);
    }
}
