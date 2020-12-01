using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmove : MonoBehaviour
{
    public float speed;
    public float damage;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
    void OnBecameInvisible()
    {
        GameObject.Destroy(this);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.SendMessage("OnRecibirDano", damage, SendMessageOptions.DontRequireReceiver);
        GameObject.Destroy(gameObject);
    }
}
