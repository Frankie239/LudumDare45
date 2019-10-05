using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public int damping;
    void Start()
    {
      //  transform.LookAt(player);
    }

   
    void Update()
    {
        LookAt();
    }

    void LookAt()
    {
        Quaternion rotation = Quaternion.LookRotation
            (player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }
}
