using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    public TextMeshProUGUI weaponUI;
    public PlayerController playerCon;

    void Awake()
    {
        weaponUI.text = $"Damage: 20\nCharge Time: 1.5\nCost: 3\nAmmo: 12";
    }

    void Update()
    {
        if (playerCon.usingShotgun)
        {
            weaponUI.text = $"Damage: 20\nCharge Time: 1.5\nCost: 3\nAmmo: " + playerCon.weapon.ammo;
        }
        else if (playerCon.usingSniper)
        {
            weaponUI.text = $"Damage: 40\nCharge Time: 1\nCost: 1\nAmmo: " + playerCon.weapon2.ammo;
        }
        else if (playerCon.usingSubGun)
        {
            weaponUI.text = $"Damage: 5\nCharge Time: 0.4\nCost: 1\nAmmo: " + playerCon.weapon3.ammo;
        }
        else if (playerCon.usingBurstGun)
        {
            weaponUI.text = $"Damage: 10\nCharge Time: 0.8\nCost: 2\nAmmo: " + playerCon.weapon4.ammo;
        }
        else if (playerCon.usingLaserGun)
        {
            weaponUI.text = $"Damage: 2\nCharge Time: 0.2\nCost: 2\nAmmo: " + playerCon.weapon5.ammo;
        }
    }
    
}
