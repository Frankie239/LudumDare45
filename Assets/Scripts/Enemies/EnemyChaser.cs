using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    public float speed;
    private Transform target;
    public float distanceToPlayer;
    Collider2D playerCol;
    public float range;
    public LayerMask whatIsPlayer;
    public float stopFollowingTime = 0;
    //private float startFollowingTime;

    private Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        playerCol = Physics2D.OverlapCircle(transform.position, range, whatIsPlayer);

        if (playerCol != null)
        {
            if (stopFollowingTime <= 0)
            {

                if (Vector2.Distance(transform.position, target.position) > distanceToPlayer)
                {
                    Vector2 direction = (target.position - transform.position).normalized;
                    rb.velocity = direction * speed;
                    if (direction.x > 0)
                    {
                        animator.Play("MoveRight");
                    }
                    if (direction.x < 0)
                    {
                        animator.Play("MoveLeft");
                    }
                    if (direction.y > 0)
                    {
                        animator.Play("MoveDown");
                    }
                    if (direction.y < 0)
                    {
                        animator.Play("MoveUp");
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
