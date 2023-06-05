using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 20;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            Vector2 randomPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f));
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }
}

