using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : Pool<SpawnerComponent>
{
    public void SpawnObject()
    {
        GetPooledObject(transform.position);
    }

}
