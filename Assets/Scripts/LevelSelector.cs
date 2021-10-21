using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour 
{

	public SceneFader sceneFader;
	public Button[] levelButtons;
	void Start()	
	{
		int ultimulLevel = PlayerPrefs.GetInt ("ultimulLevel", 1);

		for(int i = 0; i < levelButtons.Length; i++)
		{
			if (i + 1 > ultimulLevel)
				levelButtons[i].interactable = false;
		}
	}
	public void SelectLevel(string levelName)
	{
		sceneFader.FadeTo(levelName);//Urmatorul level
	}

}
