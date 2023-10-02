using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    { 
        // Will remove the collectable if an object with the "Player" tag collides with it
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Coin_Count.UpdateScore();
        }
    }

}
