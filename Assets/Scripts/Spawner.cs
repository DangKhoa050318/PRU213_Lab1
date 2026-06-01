using UnityEngine;

// Sinh ngẫu nhiên thiên thạch và ngôi sao ở mép phải màn hình
public class Spawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject starPrefab;

    private float spawnRate = 1.5f;
    private float spawnX = 10f; // Vị trí X bên phải ngoài màn hình
    private float minY = -4.5f;
    private float maxY = 4.5f;

    void Start()
    {
        // Lặp lại việc sinh vật thể
        InvokeRepeating(nameof(SpawnElements), 1f, spawnRate);
    }

    void SpawnElements()
    {
        // Sinh thiên thạch
        Vector3 randomPosAsteroid = new Vector3(spawnX, Random.Range(minY, maxY), 0);
        Instantiate(asteroidPrefab, randomPosAsteroid, Quaternion.identity);

        // Sinh ngôi sao (tỷ lệ 50%)
        if (Random.value > 0.5f)
        {
            Vector3 randomPosStar = new Vector3(spawnX, Random.Range(minY, maxY), 0);
            Instantiate(starPrefab, randomPosStar, Quaternion.identity);
        }
    }
}