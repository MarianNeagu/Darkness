using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour 
{

	public GameObject levelSelectMenu;


	void Start()
	{
		levelSelectMenu.SetActive(false);

	}

	public void Play()
	{
		levelSelectMenu.SetActive(true);
		// PlayerPrefs.DeleteAll(); Doar pentru Resetare in editor
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void Back ()
	{
		levelSelectMenu.SetActive(false);
	}


}
