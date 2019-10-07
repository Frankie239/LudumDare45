using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Lights
{
	Blue,
	Red,
	Green,
	Yellow,
	Violet,
	Orange,
	None
}
public class LightManager : MonoBehaviour
{
	private static LightManager lightManager;

	public Lights currentLight = Lights.None;
	
	private Light playerLight = default;
	private GameObject endingLight = default;
	private int activatedLights = 0;
    SetLightUI lightUI;

	void Awake()
	{
        lightUI = gameObject.GetComponent<SetLightUI>();

		if (lightManager == null)
		{
			lightManager = this;
		}
		else
		{
			Destroy(gameObject);
		}
		playerLight = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Light>();
		playerLight.color = Color.black;
		endingLight = GameObject.FindGameObjectWithTag("EndingLight");
		endingLight.SetActive(false);
	}

	public static LightManager GetLightManager()
	{
		return lightManager;
	}

	public void SetLight(Lights lightToActive)
	{
		currentLight = lightToActive;
		switch (currentLight)
		{
			case Lights.Blue:
				playerLight.color = new Color(0, 22, 255, 0);
                AudioManager.Audio_instance.ChangeMusic("Blue");
                lightUI.SetLight("blue");
				break;
			case Lights.Red:
				playerLight.color = new Color(255, 22, 0, 0);
                AudioManager.Audio_instance.ChangeMusic("Red");
                lightUI.SetLight("red");
                break;
			case Lights.Green:
				playerLight.color = new Color(29, 130, 24, 0);
                AudioManager.Audio_instance.ChangeMusic("Green");
                lightUI.SetLight("green");
                break;
			case Lights.Yellow:
				playerLight.color = new Color(199, 201, 56, 0);
                AudioManager.Audio_instance.ChangeMusic("Yellow");
                lightUI.SetLight("yellow");
                break;
			case Lights.Violet:
				playerLight.color = new Color(131, 59, 197, 0);
                AudioManager.Audio_instance.ChangeMusic("Violet");
                lightUI.SetLight("violet");
                break;
			case Lights.Orange:
				playerLight.color = new Color(224, 144, 39, 0);
                AudioManager.Audio_instance.ChangeMusic("Orange");
                lightUI.SetLight("orange");
                break;
		}

		activatedLights++;
		
		if(activatedLights == 6)
		{
			endingLight.SetActive(true);
		}
	}
}
