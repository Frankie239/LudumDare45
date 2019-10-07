using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetLightUI : MonoBehaviour
{
    public GameObject[] lights;
    public Sprite[] colors;
    int index;

    private void Start()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(false);
        }
    }
//set color accede al elemento sprite y cambiale
    public void SetLight(string color)
    {
        lights[index].SetActive(true);
        lights[index].GetComponent<Image>().sprite = GetColor(color) ;
        
            index++;
    }

    Sprite GetColor(string color)
    {
        Sprite s = null;
        for (int i = 0; i < colors.Length; i++)
        {
            if (colors[i].name == color)
            {
                s = colors[i];
            }
        }

        return s;
    }

}
