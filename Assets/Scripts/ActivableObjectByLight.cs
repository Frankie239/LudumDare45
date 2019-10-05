using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableObjectByLight : MonoBehaviour
{
	public Lights activationLight;

	public GameObject active;
	public GameObject inactive;

	// Start is called before the first frame update
	void Start()
	{
        active.SetActive(false);
        inactive.SetActive(true);
	}

	// Update is called once per frame
	void Update()
	{
		if (LightManager.GetLightManager().currentLight == activationLight)
		{
			active.SetActive(true);
			inactive.SetActive(false);
		}
		else
		{
			active.SetActive(false);
			inactive.SetActive(true);
		}
	}
}
