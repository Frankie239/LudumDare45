using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SetColorDark : MonoBehaviour
{
    private Tilemap tilemap;
    private Color original;
    private bool darkMode = true;

    void Awake() {
        tilemap = GetComponent<Tilemap>();
        original = tilemap.color;
        SetDark();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(darkMode)
            {
                // SetOriginal();
            }
            else
            {
                SetDark();
            }
        }
    }

    void SetDark()
    {
        tilemap.color = new Color(0.2f, 0.1803922f, 0.1803922f, 1);
        darkMode = true;
    }

    void SetOriginal()
    {
        tilemap.color = new Color(1, 1, 1, 1);
        darkMode = false;
    }
}
