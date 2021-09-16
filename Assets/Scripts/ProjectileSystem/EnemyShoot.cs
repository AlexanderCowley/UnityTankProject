using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] Projectile _obj_projectile;
    public void FireWeapon(Transform firePos, Quaternion fireRot, Projectile projectile)
    {
        projectile = Instantiate
            (projectile, firePos.position, fireRot);

        //projectile.IgnoreSpawnerCollider(null, this);
    }
}