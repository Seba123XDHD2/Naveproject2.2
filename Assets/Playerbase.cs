using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerbase : MonoBehaviour
{
    public void destroyShip()
    {
        Playerdeathpool.Instance?.GetPooledObject(transform.position);
        gameObject.SetActive(false);
    }
    
    
 
}
