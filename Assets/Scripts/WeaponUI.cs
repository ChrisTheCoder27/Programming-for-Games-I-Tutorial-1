using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    public TextMeshProUGUI weaponUI;
    public PlayerController playerCon;
    public Gun1 gun1;
    public Gun2 gun2;
    public Gun3 gun3;

    void Awake()
    {
        weaponUI.text = $"Damage: 20\nCharge Time: 1.5\nCost: 3\nAmmo: 12";
    }

    void Update()
    {
        if (playerCon.usingShotgun)
        {
            weaponUI.text = $"Damage: 20\nCharge Time: 1.5\nCost: 3";
        }
        else if (playerCon.usingSniper)
        {
            weaponUI.text = $"Damage: 40\nCharge Time: 1\nCost: 1";
        }
        else if (playerCon.usingSubGun)
        {
            weaponUI.text = $"Damage: 5\nCharge Time: 0.4\nCost: 1";
        }
    }
    
}
