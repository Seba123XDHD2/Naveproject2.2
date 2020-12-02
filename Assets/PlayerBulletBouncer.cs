using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBouncer : MonoBehaviour
{
    Rigidbody2D rb;
    public string[] bounceTargetTag;

    bool bounceWait;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player")) return;

        if (bounceWait) return;
        bounceWait = true;
            Vector2 reflectedVelocity = Vector2.Reflect(rb.velocity, collision.GetContact(0).normal);

            rb.velocity = reflectedVelocity;
         
    }
 
}
