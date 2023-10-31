using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float trueDamage;

    private void OnCollisionEnter(Collision collision)
    {
        // Prints the part of the player model that was hit
        print(collision.transform.name + "," + collision.transform.root.name);

        if(collision.transform.root.TryGetComponent(out IDamagable hitTarget))
        {
            hitTarget.TakeDamage(trueDamage);
        }
    }

}
