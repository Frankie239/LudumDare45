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
	public Light playerLight = default;
	public GameObject endingLight = default;

	private int activatedLights = 0;

	void Awake()
	{
		if (lightManager == null)
		{
			lightManager = this;
		}
		else
		{
			Destroy(gameObject);
		}

		playerLight.color = Color.black;
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
				break;
			case Lights.Red:
				playerLight.color = new Color(255, 22, 0, 0);
                AudioManager.Audio_instance.ChangeMusic("Red");
                break;
			case Lights.Green:
				playerLight.color = new Color(29, 130, 24, 0);
                AudioManager.Audio_instance.ChangeMusic("Green");
                break;
			case Lights.Yellow:
				playerLight.color = new Color(199, 201, 56, 0);
                AudioManager.Audio_instance.ChangeMusic("Yellow");
                break;
			case Lights.Violet:
				playerLight.color = new Color(131, 59, 197, 0);
                AudioManager.Audio_instance.ChangeMusic("Violet");
                break;
			case Lights.Orange:
				playerLight.color = new Color(224, 144, 39, 0);
                AudioManager.Audio_instance.ChangeMusic("Orange");
                break;
		}

		activatedLights++;
		
		if(activatedLights == 6)
		{
			endingLight.SetActive(true);
		}
	}
}
