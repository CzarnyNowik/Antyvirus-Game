using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public int healthPoints;
    public int[] enemiesDamage = new int[3];
    public GameObject gameManager;
    public Slider healthBarSlider;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Worm") healthPoints -= enemiesDamage[0];

        if (other.gameObject.tag == "Horse") healthPoints -= enemiesDamage[1];

        if (other.gameObject.tag == "Makro") healthPoints -= enemiesDamage[2];

        healthBarSlider.value = healthPoints;

        if (healthPoints <= 0)
        {
            gameManager.GetComponent<PlayManager>().GameOver();
            Destroy(gameObject);
        }
    }


}
