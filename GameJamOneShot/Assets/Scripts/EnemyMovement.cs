using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Скорость движения объекта
    private Transform player; // Ссылка на объект player

    void Start()
    {
        // Находим объект player по тегу "Player". Убедитесь, что у вашего игрока установлен тег "Player".
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Не удалось найти объект с тегом 'Player'");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Вычисляем направление к player
            Vector3 direction = (player.position - transform.position).normalized;

            // Вычисляем новую позицию объекта
            Vector3 newPosition = transform.position + direction * moveSpeed * Time.deltaTime;

            // Двигаем объект к player
            transform.position = newPosition;
        }
    }
}
