    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    
    public void Destroyenemy()
    {
        EnemyExplosionPool.Instance?.GetPooledObject(transform.position);
        gameObject.SetActive(false);

    }
}
