using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Weapon
{
    [SerializeField] private ProjectileObject projectileFired;
    [SerializeField] private Transform firePoint;

    protected override void Attack(float chargePercent)
    {
        if (ammo > 0)
        {
            for (int i = 0; i < 3; i++)
            {
                ProjectileObject current = Instantiate(projectileFired, firePoint.position, owner.transform.rotation);
                current.Initialize(chargePercent, owner);
                current.gameObject.layer = gameObject.layer;
            }
            ammo -= cost;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
}
