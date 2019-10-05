using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObject : MonoBehaviour
{
	public Lights lightToActive;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            LightManager.GetLightManager().SetLight(lightToActive);
            Destroy(gameObject);
        }
    }
}
