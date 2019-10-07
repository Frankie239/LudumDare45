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
    public float rotationSpeed;
   
    void FixedUpdate()
    {
        playerCol = Physics2D.OverlapCircle(transform.position, followRange, whatIsPlayer);
        playerDist = player.transform.position - transform.position;
        LookAtAndFire();
//        Debug.Log(playerDist);
    }

    void LookAtAndFire()
    {
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (playerCol != null) 
        {
            //This implementation was somehow buggy. So changed it with Quaternion.AngleAxis. Works as intended now
            //Leaving this here just because I want to know why it didnt work later. 
            //Quaternion rotation = Quaternion.LookRotation
            //    (direction, transform.TransformDirection(Vector3.up));
            //transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.SlerpUnclamped(transform.rotation, rot, rotationSpeed * Time.deltaTime);
            Fire();
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
