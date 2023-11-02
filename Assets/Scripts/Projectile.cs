using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Weapon
{
    [SerializeField] private ProjectileObject projectileFired;
    [SerializeField] private Transform firePoint;

    protected override void Attack(float chargePercent)
    {
        for (int i = 0; i < 3; i++)
        {
            ProjectileObject current = Instantiate(projectileFired, firePoint.position, owner.transform.rotation);
            current.Initialize(chargePercent, owner);
            current.gameObject.layer = gameObject.layer;
        }
    }
}
