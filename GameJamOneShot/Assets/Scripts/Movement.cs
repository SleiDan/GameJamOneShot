using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 2f; // Скорость перемещения персонажа

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Получаем ввод от пользователя
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Создаем вектор движения
        Vector2 movement = new Vector2(moveX, moveY);

        // Нормализуем вектор движения, чтобы предотвратить движение по диагонали быстрее
        movement.Normalize();

        // Применяем движение к Rigidbody2D
        rb.velocity = movement * moveSpeed;
    }
}
