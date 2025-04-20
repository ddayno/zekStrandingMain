using UnityEngine;

public class PlayerAnimHandler : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", player.GetComponent<PlayerMovement>().isRunning);
        if (player.GetComponent<PlayerMovement>().isDashing)
        {
            animator.SetTrigger("Dashing");
            return;
        }
        animator.SetBool("isWalking", player.GetComponent<PlayerMovement>().isWalking);
    }
}
