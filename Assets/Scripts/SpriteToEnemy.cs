using UnityEngine;

public class SpriteToEnemy : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject enemy;
    public GameObject player;
    public SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = enemyTransform.position;


    }

}   

