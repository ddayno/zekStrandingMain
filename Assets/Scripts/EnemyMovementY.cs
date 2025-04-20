using UnityEngine;

public class EnemyMovementY : MonoBehaviour
{
    public Rigidbody2D enemyRigidY;
    public Transform enemyTransformY;
    public Transform playerTransformY;

    private bool isPlayerInsideY = false;
    public float stepY = 10f;
    public float patrolSpeedY = 1f;
    public float patrolTimerY = 7f;
    private float patrolResetY;
    private int patrolDirectionY = 1;

    private void Start()
    {
        enemyRigidY.linearVelocityY = patrolSpeedY * patrolDirectionY;
        patrolResetY = patrolTimerY;
    }

    private void Update()
    {
        if (isPlayerInsideY)
        {
            Vector2 distance = playerTransformY.position - enemyTransformY.position;
            float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
            enemyRigidY.rotation = angle;
            enemyTransformY.position = Vector2.MoveTowards(enemyTransformY.position, playerTransformY.position, stepY * Time.deltaTime);
        }
        else
        {
            patrolResetY -= Time.deltaTime;

            if (patrolResetY <= 0)
            {
                patrolDirectionY *= -1;
                patrolResetY = patrolTimerY;
            }

            enemyRigidY.linearVelocityY = patrolSpeedY * patrolDirectionY;

            // Flip GameObject rotation only on X-axis
            enemyTransformY.rotation = Quaternion.Euler(patrolDirectionY == 1 ? 0f : 180f, 0f, 0f);

            Debug.Log("Enemy Y position: " + transform.position + " | Direction: " + patrolDirectionY);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInsideY = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInsideY = false;
        }
    }
}
