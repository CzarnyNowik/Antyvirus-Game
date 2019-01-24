using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int eHealthPoints;
    private GameObject spawnInWaveManager;

    void Start()
    {
        spawnInWaveManager = GameObject.Find("Managers");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet") eHealthPoints--;
        if (eHealthPoints <= 0 || other.gameObject.tag == "Player" || other.gameObject.tag == "Hdd")
        {
            spawnInWaveManager.SendMessage("EnemyKilled");
            Destroy(gameObject);
        }
    }


}
