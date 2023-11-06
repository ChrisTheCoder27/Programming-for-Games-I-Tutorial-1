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
        weaponUI.text = $"Damage: 20\nCharge Time: 1.5\nCost: 3";
        //weaponUI.text = $"Damage: 40\nCharge Time: 1\nCost: 1";
        //weaponUI.text = $"Damage: 5\nCharge Time: 0.4\nCost: 1";
    }

    void Update()
    {
        /*if (playerCon.weapon == playerCon.shotgun)
        {
            weaponUI.text = $"Damage: 20\nCharge Time: 1.5\nCost: 3";
        }*/
    }
    
}
