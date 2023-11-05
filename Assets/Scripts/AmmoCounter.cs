using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    public TextMeshProUGUI ammoUI;
    public int maxAmmo = 12;
    public int currentAmmo;
    private bool isFiring;

    private void Awake()
    {
        ammoUI.text = "Ammo: 12";
    }

    public void Update()
    {
        /*if(Input.GetMouseButtonDown(0) && !isFiring && currentAmmo > 0)
        {
            UpdateAmmo();
        }
        else if (Input.GetKeyDown("r"))
        {
            currentAmmo = maxAmmo;
            ammoUI.text = "Ammo: " + currentAmmo.ToString();
        }*/
    }

    private void UpdateAmmo()
    {
        isFiring = true;
        currentAmmo--;
        ammoUI.text = "Ammo: " + currentAmmo.ToString();
        isFiring = false;
    }
}
