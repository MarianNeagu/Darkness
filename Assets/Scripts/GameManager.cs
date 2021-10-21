using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour 
{
	public SceneFader sceneFader;
	public string nextLevel = "Level2"; //doar initializare, in mod normal se modifica in editor care scena urmeaza
	public int levelToUnlock = 2;
	public bool _orbsCollected;
	public Animator exitAnim;
	public TextMeshProUGUI textOrbsInfo;
	public bool inTrigger;
	private int currentLevel;
	public GameObject particleSystemPortal;
	private bool particleSpawned;
	private Vector3 portalPosition;

	void Start()
	{
		//PlayerPrefs.DeleteAll(); //Asta e pentru stergerea bazei de date complet
		exitAnim.enabled = false;
		textOrbsInfo.color = new Color (textOrbsInfo.color.r, textOrbsInfo.color.g, textOrbsInfo.color.b, 0);
		inTrigger = false;
		currentLevel = SceneManager.GetActiveScene().buildIndex;
		particleSpawned = false;
		portalPosition = new Vector3(transform.position.x,transform.position.y-0.2f,transform.position.z);

	}
	void Update()
	{
		if(_orbsCollected)
		{
			exitAnim.enabled = true;
			if(!particleSpawned)
			{
				Instantiate(particleSystemPortal,portalPosition,Quaternion.Euler(new Vector3(-90f,-90f,0f)));
				particleSpawned = true;
			}
			
		}
			
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player" && _orbsCollected)
		{
			Debug.Log("LEVEL CASTIGAT!");
			if(PlayerPrefs.GetInt("ultimulLevel") <= currentLevel)//pentru cazul in care pornesti un lvl mai mic decat ultimul deblocat
				PlayerPrefs.SetInt("ultimulLevel", levelToUnlock);
			sceneFader.FadeTo(nextLevel);
		}
		else if(other.tag == "Player" && !_orbsCollected)
		{
			inTrigger = true;
			StartCoroutine(ActivareText());
		}
	}


	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player" && !_orbsCollected)
		{
			inTrigger = false;
			StartCoroutine(DezactivareText());
		}
	}

	IEnumerator ActivareText()
	{
		float time = 0f;
		float speed = 0.5f;
		while(time < 1f)                                                         
		{
			time += Time.deltaTime * speed;         
			textOrbsInfo.color = new Color (textOrbsInfo.color.r, textOrbsInfo.color.g, textOrbsInfo.color.b, time);
			yield return 0;
			if(!inTrigger)
				StartCoroutine(DezactivareText());
		}
	}

	IEnumerator DezactivareText()
	{
		float time = 1f;
		while(time > 0f)                                                         
		{
			time -= Time.deltaTime;         
			textOrbsInfo.color = new Color (textOrbsInfo.color.r, textOrbsInfo.color.g, textOrbsInfo.color.b, time); // Valoarea alpha este atribuita timpului curent
			yield return 0;
		}
	}
}
