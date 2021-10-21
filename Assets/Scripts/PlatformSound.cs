using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSound : MonoBehaviour 
{

	public AudioSource platformEnterSound;
	public AudioSource platformExitSound;

	void OnTriggerEnter2D (Collider2D col)
	{
		if(col.tag == "Player")
		{
			platformEnterSound.Play();
			Debug.Log("platformEnterSound");
		}
			

	}
	void OnTriggerExit2D (Collider2D col)
	{
		if(col.tag == "Player")
			platformExitSound.Play();

	}
	
}
