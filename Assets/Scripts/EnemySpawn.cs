using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private float randomTime;
    public float spawnX;
    public float spawnY;
    public float spawnZ;
    public GameObject enemyPrefeb;
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 3, 5);
    }

     
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefeb);
    }

}
