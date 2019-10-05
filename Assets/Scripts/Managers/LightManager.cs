using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Lights
{
	Blue,
	None
}
public class LightManager : MonoBehaviour
{
	private static LightManager lightManager;

	public Lights currentLight = Lights.None;
	public Light playerLight = default;

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
				break;
		}
	}
}
