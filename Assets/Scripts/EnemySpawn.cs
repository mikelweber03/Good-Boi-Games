using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float randomTime;
    public float spawnX;
    public float spawnY;
    public float spawnZ;
    public GameObject[] enemyPrefeb;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpawn()
    {
        randomTime = Random.Range(1, 5);

    }

}
