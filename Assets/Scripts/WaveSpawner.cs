using System.Collections;
using UnityEngine;
[System.Serializable]
public class EnemyWave 
{
    public GameObject enemyPrefab;
    public int enemyCount;
    public float spawnRate;
}

public class WaveSpawner : MonoBehaviour
{
    [Header("Wave Configuration")]
    public EnemyWave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;

    void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    IEnumerator SpawnAllWaves()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            for (int j = 0; j < waves[i].enemyCount; j++)
            {
                Instantiate(waves[i].enemyPrefab, spawnPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(1f / waves[i].spawnRate);
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}