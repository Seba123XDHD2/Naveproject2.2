using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject PrefanEnemy;
    public void Spawn()
    {
        GameObject obj = GameObject.Instantiate(PrefanEnemy);
        obj.transform.position = transform.position;
        obj.transform.up = transform.up;


    }



}
