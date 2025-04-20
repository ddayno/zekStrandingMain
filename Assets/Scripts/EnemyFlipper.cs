using UnityEngine;

public class EnemyFlipper : MonoBehaviour
{
    public Rigidbody2D enemyObject;
    public SpriteRenderer enemySprite;
    [SerializeField] private bool isFacingRIght = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Flip();
 
    }
    void Flip()
    {
        Vector2 enemyScale = enemySprite.transform.localScale;

        if (enemyObject.linearVelocityX > 0 && !isFacingRIght)
        {
            Debug.Log("asdasd");
            isFacingRIght = !isFacingRIght;
            enemyScale.x *= -1;
            enemySprite.gameObject.transform.localScale = enemyScale;
        }
        else if (enemyObject.linearVelocityX < 0 && isFacingRIght)
        {
            isFacingRIght = !isFacingRIght;
            enemyScale.x *= -1;
            enemySprite.gameObject.transform.localScale = enemyScale;
        }
    }
}   

