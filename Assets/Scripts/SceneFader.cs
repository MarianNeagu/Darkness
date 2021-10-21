using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour 
{
	public Image fader;
	public GameObject panel;
	float speed = 0.8f;
	void Start()
	{
		panel.SetActive(true);
		StartCoroutine (FadeIn());
	}

	public void FadeTo(string scene)
	{
		StartCoroutine(FadeOut(scene));
	}

	IEnumerator FadeIn()
	{
		float time = 1f;
		panel.SetActive(true);
		while(time > 0f)                                                         
		{
			time -= Time.deltaTime * speed;                                 
			fader.color = new Color (0f, 0f, 0f, time);
			yield return 0;
		}
		panel.SetActive(false);
	}

	IEnumerator FadeOut(string scene)
	{
		float time = 0f;
		panel.SetActive(true);
		while(time < 1f)                                                         
		{
			time += Time.deltaTime * speed;                                 
			fader.color = new Color (0f, 0f, 0f, time);
			yield return 0;
		}
		SceneManager.LoadScene(scene);
		Debug.Log(scene);
	}
}
