using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Массив префабов врагов
    public Transform player; // Ссылка на трансформ игрока
    public float minSpawnRadius = 3.0f; // Минимальный радиус появления врагов
    public float maxSpawnRadius = 5.0f; // Максимальный радиус появления врагов
    public float spawnInterval = 1.0f; // Интервал появления врагов в секундах

    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0.0f;
        }
    }

    void SpawnEnemy()
    {
        // Генерируем случайный радиус в диапазоне между minSpawnRadius и maxSpawnRadius
        float spawnRadius = Random.Range(minSpawnRadius, maxSpawnRadius);

        // Генерируем случайный угол в радианах
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);

        // Вычисляем позицию на кольце
        Vector3 spawnPosition = new Vector3(Mathf.Cos(randomAngle), 0f, Mathf.Sin(randomAngle)) * spawnRadius + player.position;

        // Выбираем случайного врага из массива префабов
        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Спавним выбранного врага
        Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);
    }
}
