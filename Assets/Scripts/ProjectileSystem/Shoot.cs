using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Projectile _obj_projectile;
    [SerializeField] Transform firePos;
    public void FireWeapon(Transform firePos, Quaternion fireRot, Projectile projectile)
    {
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
