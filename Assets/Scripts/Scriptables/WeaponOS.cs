using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "MyScriptableObject/WeaponStats", order = 1)]
public class WeaponOS : ScriptableObject
{
    [field: Header("Weapon Base Stats")]
    [field: SerializeField] public float timeBetweenAttacks;
    [field: SerializeField] public float contactDamage { get; private set; }
    [field: SerializeField] public float chargeTime { get; private set; }
    [field: SerializeField, Range(0, 1)] public float minCharge { get; private set; }
    [field: SerializeField] public float cost { get; private set; }

    public WaitForSeconds CoolDown { get; private set; }
    [field: SerializeField] private float coolDown;

    private void OnEnable()
    {
        CoolDown = new WaitForSeconds(coolDown);
    }

}
