using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuButtons : MonoBehaviour 
{
	public float speed;
	public SceneFader sceneFader;

	//	MENIURI
	public GameObject pauseMenu;
	public GameObject settingsMenu;


	//	IMAGINILE BUTOANELOR
	public Image pauseMenuImage;
	public Image resumeButImage;
	public Image menuButImage;
	public Image settingsButImage;

	//	BUTOANE
	public Button butonSus;
	public Button butonStanga;
	public Button butonDreapta;
	public Button butonPauza;
	public Button butonResume;
	public Button butonMenu;
	public Button butonSettings;
	public Button butonRestart;
	public Button butonBack;

	public string mainMenu = "MainMenu";
	public bool isOnPause;


	void Start()
	{
		isOnPause = false;
		speed = 1.5f;
		pauseMenuImage.color = new Color (pauseMenuImage.color.r, pauseMenuImage.color.g, 
										pauseMenuImage.color.b, 0);
		resumeButImage.color = new Color (pauseMenuImage.color.r, pauseMenuImage.color.g, 
										pauseMenuImage.color.b, 0);
		menuButImage.color = new Color (pauseMenuImage.color.r, pauseMenuImage.color.g, 
										pauseMenuImage.color.b, 0);
		pauseMenu.SetActive(false);
		settingsMenu.SetActive(false);
		butonSus.interactable = true;
		butonStanga.interactable = true;
		butonDreapta.interactable = true;
		butonPauza.interactable = true;
		butonMenu.interactable = false;
		butonSettings.interactable = false;
		Time.timeScale = 1f;
	}

	void Update()
	{
		/* if(Input.GetKeyDown(KeyCode.Escape) && !isOnPause)
			Pause();
		else if (Input.GetKeyDown(KeyCode.Escape) && isOnPause)
			Resume();*/
	}

	public void Pause()
	{
		StartCoroutine(FadeOut());	//butoanele se activeaza dupa Coroutine ca sa fie delay						
		pauseMenu.SetActive(true);
		butonSus.interactable = false;
		butonStanga.interactable = false;
		butonDreapta.interactable = false;
		butonPauza.interactable = false;
	}


	public void Resume()
	{
		
		Time.timeScale = 1f;
		butonResume.interactable = false;
		butonMenu.interactable = false;
		butonSettings.interactable = false;
		StartCoroutine(FadeInResume()); //butoanele se activeaza dupa Coroutine ca sa fie delay		
	}

	public void ToMainMenu()
	{
		Time.timeScale = 1f;
		butonRestart.interactable = false;
		butonResume.interactable = false;
		butonMenu.interactable = false;
		butonSettings.interactable = false;
		sceneFader.FadeTo(mainMenu);
	}

	public void ToSettingsMenu()
	{
		pauseMenu.SetActive(false);
		settingsMenu.SetActive(true);
	}

	public void BackToPauseMenu()
	{
		pauseMenu.SetActive(true);
		settingsMenu.SetActive(false);
	}

	IEnumerator FadeInResume() //la apasarea butonului Resume
	{
		float time = 1f;
		while(time > 0f)                                                         
		{
			time -= Time.deltaTime * speed;                                 
			pauseMenuImage.color = new Color (pauseMenuImage.color.r, pauseMenuImage.color.g, 
										pauseMenuImage.color.b, time);
			resumeButImage.color = new Color (resumeButImage.color.r, resumeButImage.color.g, 
										resumeButImage.color.b, time);
			menuButImage.color = new Color (menuButImage.color.r, menuButImage.color.g, 
										menuButImage.color.b, time);
			settingsButImage.color = new Color (settingsButImage.color.r, settingsButImage.color.g, 
										settingsButImage.color.b, time);
			yield return 0;

				
		}
		
		pauseMenu.SetActive(false);
		butonSus.interactable = true;
		butonStanga.interactable = true;
		butonDreapta.interactable = true;
		butonPauza.interactable = true;
		
	}

	IEnumerator FadeOut() //la apasarea butonului pauza
	{
		float time = 0f;
		while(time < 1f)                                           
		{
			time += Time.deltaTime * speed;                                 
			pauseMenuImage.color = new Color (pauseMenuImage.color.r, pauseMenuImage.color.g, 
										pauseMenuImage.color.b, time);
			resumeButImage.color = new Color (resumeButImage.color.r, resumeButImage.color.g, 
										resumeButImage.color.b, time);
			menuButImage.color = new Color (menuButImage.color.r, menuButImage.color.g, 
										menuButImage.color.b, time);
			settingsButImage.color = new Color (settingsButImage.color.r, settingsButImage.color.g, 
										settingsButImage.color.b, time);
			yield return 0;

				
		}
		
		Time.timeScale = 0f;
		butonResume.interactable = true;
		butonMenu.interactable = true;
		butonSettings.interactable = true;
	}
}
