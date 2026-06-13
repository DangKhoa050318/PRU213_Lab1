using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject starPrefab;

    private float spawnRate = 1.5f;
    private float spawnX = 10f;
    private float minY = -4.5f;
    private float maxY = 4.5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnElements), 1f, spawnRate);
    }

    void SpawnElements()
    {
        Vector3 randomPosAsteroid = new Vector3(spawnX, Random.Range(minY, maxY), 0);
        Instantiate(asteroidPrefab, randomPosAsteroid, Quaternion.identity);

        if (Random.value > 0.5f)
        {
            Vector3 randomPosStar = new Vector3(spawnX, Random.Range(minY, maxY), 0);
            Instantiate(starPrefab, randomPosStar, Quaternion.identity);
        }
    }
}