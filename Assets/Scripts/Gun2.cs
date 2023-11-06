using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2 : Weapon
{
    [SerializeField] private ProjectileObject projectileFired;
    [SerializeField] private Transform firePoint;

    protected override void Attack(float chargePercent)
    {
        if (ammo > 0)
        {
            ProjectileObject current = Instantiate(projectileFired, firePoint.position, owner.transform.rotation);
            current.Initialize(chargePercent, owner);
            current.gameObject.layer = gameObject.layer;
        }
        ammo -= cost;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ammo = 3;
        }
    }
}

