using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Typing : MonoBehaviour
{
	private int index;
	public string[] sentences;
	public string text;
	public TextMeshProUGUI textDisplay;
	public float typeSpeed;
	public string nextLevel;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(Type());
	}

	IEnumerator Type() //Coroutine que escribe caracter por caracter.
	{ //Parte del codigo que escribe
		foreach (char letter in text) //Por cada caracter en las oraciones: 
		{
			#region Escritura: 
			textDisplay.text += letter; // voy agregando de a un caracter al textMeshPro
			yield return new WaitForSeconds(typeSpeed); //Le doy una velocidad de typeo

			#endregion
		}

		yield return new WaitForSeconds(3f);

		SceneManager.LoadScene(nextLevel);
	}
}
