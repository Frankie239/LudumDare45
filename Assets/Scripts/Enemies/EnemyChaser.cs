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

    private void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,0);

        playerCol = Physics2D.OverlapCircle(transform.position, range, whatIsPlayer);
//        Debug.Log(playerCol);

        if (playerCol != null)
        {
            if (stopFollowingTime <= 0)
            {
              
                if (Vector2.Distance(transform.position, target.position) > distanceToPlayer)
                {
                    Vector2 oldPosition = transform.position;
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

                    if(oldPosition.x < transform.position.x)
                    {
                        animator.Play("MoveRight");
                    }
                    else
                    {
                        animator.Play("MoveLeft");
                    }
                    if(oldPosition.y < transform.position.y)
                    {
                        animator.Play("MoveDown");
                    }
                    else
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
