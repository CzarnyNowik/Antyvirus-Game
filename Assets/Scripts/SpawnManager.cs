using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public List<GameObject> spawnPoints = new List<GameObject>();
    public GameObject[] enemies = new GameObject[3]; // 0 - Robak, 1 - Koń, 2 - Makrowirus
    public float spawnTime = 2f;

    void Start()
    {
        foreach (GameObject spawnPoint in GameObject.FindGameObjectsWithTag("Spawn"))
        {
            spawnPoints.Add(spawnPoint);
        }

        InvokeRepeating("SpawnEnemies", 0f, spawnTime);
    }

    void SpawnEnemies()
    {
        int rndEnemy = Random.RandomRange(0, 3);
        int rndSpawn = Random.RandomRange(0,spawnPoints.Count);

        Instantiate(enemies[rndEnemy], spawnPoints[rndSpawn].transform.position, enemies[rndEnemy].transform.rotation);

        //Debug.Log("Wyrano przeciwnika nr " + rndEnemy + " w miejscu " + rndSpawn);
    }


}
