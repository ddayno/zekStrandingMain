using UnityEngine;

public class EnemyMovementX : MonoBehaviour
{
    public Rigidbody2D enemyRigidX;
    public Transform enemyTransformX;
    public Transform playerTransformX;

    private bool isPlayerInsideX = false;
    public float stepX = 10f;
    public float patrolSpeedX = 1f;
    public float patrolTimerX = 7f;
    private float patrolResetX;
    private int patrolDirectionX = 1;

    private void Start()
    {
        enemyRigidX.linearVelocityX = patrolSpeedX * patrolDirectionX;
        patrolResetX = patrolTimerX;
    }

    private void Update()
    {
        if (isPlayerInsideX)
        {
            Vector2 distance = playerTransformX.position - enemyTransformX.position;
            float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
            enemyRigidX.rotation = angle;
            enemyTransformX.position = Vector2.MoveTowards(enemyTransformX.position, playerTransformX.position, stepX * Time.deltaTime);
        }
        else
        {
            patrolResetX -= Time.deltaTime;

            if (patrolResetX <= 0)
            {
                patrolDirectionX *= -1;
                patrolResetX = patrolTimerX;
            }

            enemyRigidX.linearVelocityX = patrolSpeedX * patrolDirectionX;

            // Flip GameObject rotation only on Y-axis
            enemyTransformX.rotation = Quaternion.Euler(0f, patrolDirectionX == 1 ? 0f : 180f, 0f);

            Debug.Log("Enemy X position: " + transform.position + " | Direction: " + patrolDirectionX);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInsideX = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInsideX = false;
        }
    }
}
