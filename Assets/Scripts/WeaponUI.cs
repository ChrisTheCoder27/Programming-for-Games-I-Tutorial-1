using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponUI : Weapon
{
    public TextMeshProUGUI weaponUI;

    void Awake()
    {
        weaponUI.text = $"Damage: " + contactDamage + "\nCharge Time: " + chargeTime + "\nCost: " + cost;
    }

    void Update()
    {
        
    }

    protected override void Attack(float chargePercent)
    {

    }
}
