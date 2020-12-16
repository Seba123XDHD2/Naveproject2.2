using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Taller;
public class Playerbase : MonoBehaviour
{
    public void destroyShip()
    {
        Playerdeathpool.Instance?.GetPooledObject(transform.position);
        gameObject.SetActive(false);
        GameManager.Instance?.PlayerDead();
    }
    
    
 
}
