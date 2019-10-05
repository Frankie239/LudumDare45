using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSetting : MonoBehaviour
{
    void Start()
    {
        GameObject lightGameObject = new GameObject("The Light");

        // Add the light component
        Light lightComp = lightGameObject.AddComponent<Light>();

        // Set color and position
        lightComp.color = Color.blue;

        lightComp.intensity = 15;
    }

    
}
