using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillOnTrigger : MonoBehaviour 
{
	public SceneFader sceneFader;
	public float speed = 1.5f;
	public GameObject gameOverMenu;
	public Button butonSus;
	public Button butonStanga;
	public Button butonDreapta;
	public Button butonPauza;
	public Button butonRestart;
	public Button gameOver_ButonMenu;
	public Image gameOverMenuImage;
	public Image restartButImage;
	public Image menuButImage;

	void Start()
	{
		gameOverMenu.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
			GameOver();		
		
	}
	
	public void GameOver()
	{
		StartCoroutine(FadeOut());							
		gameOverMenu.SetActive(true);
		butonSus.interactable = false;
		butonStanga.interactable = false;
		butonDreapta.interactable = false;
		butonPauza.interactable = false;
		butonRestart.interactable = false;
		gameOver_ButonMenu.interactable = false;
	}

	IEnumerator FadeOut() 
	{
		float time = 0f;
		while(time < 1f)                                                         
		{
			time += Time.deltaTime * speed;                                 
			gameOverMenuImage.color = new Color (gameOverMenuImage.color.r, gameOverMenuImage.color.g, 
										gameOverMenuImage.color.b, time);
			restartButImage.color = new Color (restartButImage.color.r, restartButImage.color.g, 
										restartButImage.color.b, time);
			menuButImage.color = new Color (menuButImage.color.r, menuButImage.color.g, 
										menuButImage.color.b, time);
			if(time>=1f)
			{
				butonRestart.interactable = true;
				gameOver_ButonMenu.interactable = true;
			}
			yield return 0;
		}
		Time.timeScale = 0f;
	}

	public void Restart()
	{
		Time.timeScale = 1f;
		butonRestart.interactable = false;
		gameOver_ButonMenu.interactable = false;
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
	}
}
