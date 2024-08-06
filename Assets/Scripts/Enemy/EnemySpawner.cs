using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnTime;
    public int maxSpawmNum;
    private float spawnTimer;
    private int    spawnCount=0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnTime&&spawnCount<maxSpawmNum)
        {
            spawnTimer = 0;
            SpawnEnemy();
            spawnCount++;
        }
    }

    void SpawnEnemy()
    {
        GameObject.Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
