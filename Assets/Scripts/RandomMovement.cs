using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour
{
    public float speed = 2f;
    public float minMoveTime = 1f;
    public float maxMoveTime = 3f;
    public float minWaitTime = 1f;
    public float maxWaitTime = 3f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isMoving = false;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Получаем компонент спрайта
        StartCoroutine(MovementRoutine());
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rb.linearVelocity = movement * speed;

            // Поворачиваем спрайт в сторону движения
            if (movement.x < 0)
                spriteRenderer.flipX = false; // Идёт вправо
            else if (movement.x > 0)
                spriteRenderer.flipX = true; // Идёт влево
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    IEnumerator MovementRoutine()
    {
        while (true)
        {
            // Фаза движения
            isMoving = true;
            animator.SetBool("isMoving", true);
            ChangeDirection();
            yield return new WaitForSeconds(Random.Range(minMoveTime, maxMoveTime));

            // Фаза ожидания
            isMoving = false;
            animator.SetBool("isMoving", false);
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        }
    }

    void ChangeDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        movement = new Vector2(randomX, randomY).normalized;
    }
}
