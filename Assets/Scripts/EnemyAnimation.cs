using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animator;
    public GameObject walker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isWalking",walker.GetComponent<EnemyMovementX>().isWalking);
    }
}
