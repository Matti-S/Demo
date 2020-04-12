using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform EnemyPrefab;

    public Transform SpawnPoint;
    
    public float TimeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text WaveCountdownText;

    private int WaveIndex = 0;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = TimeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        WaveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < WaveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f);
        }

        WaveIndex++;
    }

    void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }

}
