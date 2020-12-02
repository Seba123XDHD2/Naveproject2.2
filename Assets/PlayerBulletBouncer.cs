using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBouncer : MonoBehaviour
{
    Rigidbody2D rb;
    public string[] ignoreTag;

      bool isBouncing;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        isBouncing = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < ignoreTag.Length; i++)
        {

            if (collision.gameObject.CompareTag(ignoreTag[i])) return;
        }
 

            Vector2 reflectedVelocity = Vector2.Reflect(rb.velocity, collision.GetContact(0).normal);

            rb.velocity = reflectedVelocity;
            isBouncing = true;


    }
 
    public bool TryToRecover()
    {
        if (!isBouncing) return false;
        gameObject.SetActive(false);
        return true;
    }
}
