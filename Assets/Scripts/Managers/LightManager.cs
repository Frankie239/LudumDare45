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
	}

	public static LightManager GetLightManager()
	{
		return lightManager;
	}
}
