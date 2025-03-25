using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Referanse til enemy prefaben
    [SerializeField] private GameObject enemyPrefab;

    // Referanse til spawn points
    [SerializeField] private Transform[] spawnPoints;

    // Hvor mange spawn points har vi?
    private int numberOfSpawnPoints;

    private void Start()
    {
        numberOfSpawnPoints = spawnPoints.Length;
        InvokeRepeating("SpawnEnemies", 1, 5);
    }

    private void SpawnEnemies()
    {
        int spawnPoint = Random.Range(0, numberOfSpawnPoints);
        Instantiate(enemyPrefab, spawnPoints[spawnPoint].position, Quaternion.identity);
    }
}
