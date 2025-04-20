using UnityEngine;

public class EnemyMovementX : MonoBehaviour
{
    public Rigidbody2D enemyRigidX;
    public Transform enemyTransformX;
    public Transform playerTransformX;

    public bool isPlayerInsideX = false;
    public bool isWalking;
    public bool isRunning;
    public float stepX = 10f;
    public float patrolSpeedX = 1f;
    public float patrolTimerX = 7f;
    private float patrolResetX;
    private int patrolDirectionX = 1;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        enemyRigidX.linearVelocityX = patrolSpeedX * patrolDirectionX;
        patrolResetX = patrolTimerX;
    }

    private void Update()
    {
        if (isPlayerInsideX)
        {
            isWalking = false;
            Vector2 distance = playerTransformX.position - enemyTransformX.position;
            float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
            enemyRigidX.rotation = angle;
            float x = playerTransformX.position.x - transform.position.x;
            if (x < 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (x > 0)
            {
                spriteRenderer.flipX = true;

            }
            Debug.Log("Enemy X position: " + transform.position + " | Direction: " + patrolDirectionX);
            enemyTransformX.position = Vector2.MoveTowards(enemyTransformX.position, playerTransformX.position, stepX * Time.deltaTime);
            isRunning = true;
        }
        else
        {
            isWalking = true;
            patrolResetX -= Time.deltaTime;

            if (patrolResetX <= 0)
            {

                patrolDirectionX *= -1;
                patrolResetX = patrolTimerX;
            }

            enemyRigidX.linearVelocityX = patrolSpeedX * patrolDirectionX;

            // Flip GameObject rotation only on Y-axis
            enemyTransformX.rotation = Quaternion.Euler(0f, patrolDirectionX == 1 ? 0f : 180f, 0f);
            if (enemyRigidX.linearVelocityX < 0)
            {
                spriteRenderer.flipX = false;
            }
            else if(enemyRigidX.linearVelocityX > 0)
            {
                spriteRenderer.flipX = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInsideX = true;
            isWalking = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInsideX = false;
            isWalking = true;
        }
    }
}
