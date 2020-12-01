using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float enemyspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * enemyspeed * Time.deltaTime;
    }
    private void OnBecameInvisible()
    {
        GameObject.Destroy(gameObject);
    }
    public void OnRecibirDano(float cantidad)
    {
        Debug.Log("Ouch!! Me hicieron " + cantidad + " de daño!!");
        GameObject.Destroy(gameObject);
    }
}
