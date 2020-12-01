using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMytime : MonoBehaviour
{
    public float timeToSpawn;
    public float currentSeconds;
    // Start is called before the first frame update
    void Start()
    {
        currentSeconds = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        currentSeconds -= Time.deltaTime;
        if (currentSeconds <= 0)
        {
            GetComponent<Spawner>().Spawn();
            currentSeconds = timeToSpawn;
        }

    }

    
    
}
