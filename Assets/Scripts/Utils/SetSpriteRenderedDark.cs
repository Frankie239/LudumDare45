using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpriteRenderedDark : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color original;
    private bool darkMode = true;

    void Awake() {
        sprite = GetComponent<SpriteRenderer>();
        original = sprite.color;
        SetDark();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(darkMode)
            {
                SetOriginal();
            }
            else
            {
                SetDark();
            }
        }
    }

    void SetDark()
    {
        sprite.color = new Color(0.2f, 0.1803922f, 0.1803922f, 1);
        darkMode = true;
    }

    void SetOriginal()
    {
        sprite.color = new Color(1, 1, 1, 1);
        darkMode = false;
    }
}
