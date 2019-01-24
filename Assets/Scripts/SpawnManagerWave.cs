using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerWave : MonoBehaviour {

    public List<GameObject> spawnPoints = new List<GameObject>();
    public GameObject[] enemies = new GameObject[3]; // 0 - Robak, 1 - Koń, 2 - Makrowirus
    public float spawnTime = 2f;
    public int currentWave, enemiesPerWave, enemiesDefeated, totalEnemiesDefeated;
    public float timeBetweenWaves = 5f;

    void Start()
    {
        foreach (GameObject spawnPoint in GameObject.FindGameObjectsWithTag("Spawn"))
        {
            spawnPoints.Add(spawnPoint);
        }

        currentWave = 1;
        enemiesPerWave = 10;
        totalEnemiesDefeated = 0;
        Waves();
    }

    void Waves()
    {
        StartCoroutine("SpawnEnemies");
    }


    IEnumerator SpawnEnemies()
    {
        Debug.Log("Start fali nr " + currentWave);

        for (int i = 0; i < enemiesPerWave; i++)
        {
            int rndEnemy = Random.RandomRange(0, 3);
            int rndSpawn = Random.RandomRange(0, spawnPoints.Count);
            Instantiate(enemies[rndEnemy], spawnPoints[rndSpawn].transform.position, enemies[rndEnemy].transform.rotation);
            yield return new WaitForSeconds(spawnTime);
        }

    }

    public void EnemyKilled()
    {
        enemiesDefeated++;
        totalEnemiesDefeated++;

        if(enemiesDefeated>= enemiesPerWave)
        {
            StopAllCoroutines();
            enemiesDefeated = 0;
            currentWave++;
            enemiesPerWave += 5;
            Invoke("Waves", timeBetweenWaves);
        }
    }

}

