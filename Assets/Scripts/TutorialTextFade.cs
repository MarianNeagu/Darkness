using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TutorialTextFade : MonoBehaviour 
{
	public float speed = 1f;
	public TextMeshProUGUI text;

	void Start()
	{
		text.color = new Color (text.color.r, text.color.g, text.color.b, 0);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			StartCoroutine(Activare());
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			StartCoroutine(Dezactivare());
		}
	}

	IEnumerator Dezactivare()
	{
		float time = 1f;
		while(time > 0f)                                                         
		{
			time -= Time.deltaTime * speed;         
			text.color = new Color (text.color.r, text.color.g, text.color.b, time); // Valoarea alpha este atribuita timpului curent
			if(time <= 0)
				Destroy(this); //Autodistrugerea scriptului
			yield return 0;
		}
	}

	IEnumerator Activare()
	{
		float time = 0f;
		float speed = 0.5f;
		while(time < 1f)                                                         
		{
			time += Time.deltaTime * speed;         
			text.color = new Color (text.color.r, text.color.g, text.color.b, time);
			yield return 0;
		}
	}

}
