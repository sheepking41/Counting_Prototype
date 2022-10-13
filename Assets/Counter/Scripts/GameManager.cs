using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI waveText;
    public int enemyCount;
    public bool isGameActive;
    public int score = 0;
    public int waveNumber = 1;
    private float spawnRange = 1.9f;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Target>().Length;
        if (enemyCount == 0 && isGameActive)
        {
            waveNumber++;
            waveText.text = "Wave " + waveNumber;
            SpawnEnemyWave(waveNumber);

        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        //scoreText.text = "Score: " + score;
       
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(10, 16);

        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

        return randomPos;

    }


    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        //restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

}
