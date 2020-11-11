using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 1;
    public GameObject destroyEffect;

    private float timeBtwShots;
    public float startTimeBtwShots;
    private bool canShoot;

    public Transform shotPos;
    public GameObject projectile;

    public float speed;
    public float movementSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = Vector2.up * -movementSpeed;

        if (timeBtwShots <= 0)
        {
            canShoot = true;
            if (canShoot == true)
            {
               GameObject bullet = Instantiate(projectile, shotPos.position, shotPos.rotation);
                timeBtwShots = startTimeBtwShots;
                canShoot = false;
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(shotPos.up * speed, ForceMode2D.Impulse);
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerProjectile") {
            health -= 1;
        }
        if (collision.tag == "Player") {
            Destroy(gameObject);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }

        if (health <= 0) {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Endline") {
            Destroy(gameObject);
        }    
    }

}
