using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileObject : MonoBehaviour
{
    private float curSpeed;
    private float curDamage;
    public float baseSpeed;
    private Vector2 curDirection;
    public float contactDamage;

    private Rigidbody owner;

    public float lifeTime = 0;

    public void Initialize(float chargePercent, Rigidbody owner)
    {
        this.owner = owner;
        curDirection = transform.right;
        curSpeed = baseSpeed * chargePercent;
        curDamage = contactDamage * chargePercent;
        GetComponent<Rigidbody>().AddForce(transform.forward * curSpeed, ForceMode.Impulse);
    }

}
