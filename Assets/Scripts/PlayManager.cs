using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour {

    public GameObject gameOverPanel;
    public Text gameOverText;

    void Start()
    {
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        Time.timeScale = 0.0001f;
        int wave = GetComponent<SpawnManagerWave>().currentWave;
        int enemiesDefeated = GetComponent<SpawnManagerWave>().totalEnemiesDefeated;
        gameOverPanel.SetActive(true);
        gameOverText.text = "Dotarłeś do "+ wave +" fali pokonując " + enemiesDefeated + " wrogów";
 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
