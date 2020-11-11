using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public GameObject ImpactEffect;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            Destroy(gameObject);
            Instantiate(ImpactEffect, transform.position, transform.rotation);
        }
    }
}
