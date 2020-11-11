using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{

    private Animator anim;
    public float speed;

    private float moveInputX, moveInputY;

    private Rigidbody2D rb;

    public GameObject projectile;
    public Transform shotPos;

    public int Health = 5;
    public GameObject playerExplostion;
    public GameObject GameOverObj;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        GameOverObj.SetActive(false);
    }

    void FixedUpdate()
    {
        moveInputX = Input.GetAxis("Horizontal");
        moveInputY = Input.GetAxis("Vertical");
    }

    void Update()
    {
        rb.velocity = new Vector2(moveInputX * speed , moveInputY * speed);

        if (Input.GetMouseButtonDown(0)) {
            Instantiate(projectile, shotPos.position, Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.D)) {
            anim.SetBool("TurnRight", true);
        } else if (Input.GetKeyUp(KeyCode.D)) {
            anim.SetBool("TurnRight", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("TurnLeft", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("TurnLeft", false);
        }

        

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") {
            Health -= 1;
            if (Health <= 0) {
                Death();
            }
        }
    }

    void Death() {
        Destroy(gameObject);
        Instantiate(playerExplostion, transform.position, Quaternion.identity);
        Time.timeScale = 0;
        GameOverObj.SetActive(true);
    }


}
