using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Drawers;
using UnityEngine.Events;
using System;
using Sirenix.OdinInspector.Editor;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectilecomponent : SerializedMonoBehaviour
{
    Rigidbody2D rb;

    public float projectileSpeed = 2f;
    public float projectileDamage = 1f;
    public string targetTag;
    public string targetMethod = "GetDamage";

  //  public UnityEventOnTriggerEnter2D TriggerEnter2D;
  //  public UnityEventOnCollisionEnter2D CollisionEnter2D;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void LaunchProjectile( )
    {
        
        SetVelocity(transform.forward * projectileSpeed);
    }
    public void LaunchProjectile(Vector2 LaunchDirection)
    {

        GetComponent<Rigidbody2D>().velocity = LaunchDirection * projectileSpeed;
    }
    public void LaunchProjectile(Vector2 LaunchDirection, float LaunchSpeed = 2f)
    {
        projectileSpeed = LaunchSpeed;
        GetComponent<Rigidbody2D>().velocity = LaunchDirection * projectileSpeed;
    }
    public void LaunchProjectile(float LaunchSpeed=2f)
    {
        projectileSpeed = LaunchSpeed;
        SetVelocity(transform.forward * projectileSpeed);
    }
    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity*projectileSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if(collision.CompareTag(targetTag)==true)
        {
            ApplyDamageTotarget(collision.gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag) == true)
        {
            ApplyDamageTotarget(collision.gameObject);
        }
    }

    void ApplyDamageTotarget(GameObject targetGameObject)
    {
        targetGameObject.SendMessage(targetMethod, projectileDamage,SendMessageOptions.DontRequireReceiver);

        gameObject.SetActive(false);
    }

}
