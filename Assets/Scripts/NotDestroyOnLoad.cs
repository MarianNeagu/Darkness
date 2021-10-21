using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotDestroyOnLoad : MonoBehaviour 
{
	public static bool started=false;

	void Awake()
	{
		if(!started)
        {
			started = true;
			DontDestroyOnLoad(transform.gameObject);
		}
		else transform.gameObject.SetActive(false);
		
	}

}
