using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileObject : Weapon
{
    [SerializeField] private ProjectileObject projectileFired;
    [SerializeField] private Transform firePoint;

    protected override void Attack(float chargePercent)
    {
        ProjectileObject current = Instantiate(projectileFired, firePoint.position, owner.transform.rotation);
    }

}
