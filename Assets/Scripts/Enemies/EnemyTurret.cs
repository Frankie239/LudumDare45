using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    public Transform player;
    Vector3 playerDist;
    public LayerMask whatIsPlayer;
    public float followRange;
    Collider2D playerCol;

    public GameObject bullet;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;
   
    void Update()
    {
        playerCol = Physics2D.OverlapCircle(transform.position, followRange, whatIsPlayer);
        playerDist = player.transform.position - transform.position;
        LookAtAndFire();
//        Debug.Log(playerDist);
    }

    void LookAtAndFire()
    {
        if (playerCol != null) 
        {
            Quaternion rotation = Quaternion.LookRotation
                (player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            Fire();
        }
        else
        {
            Quaternion.Euler(0, 180, 0);
        }
    }

    private void Fire()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(bullet, shotPoint.position, transform.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followRange);
    }
}
