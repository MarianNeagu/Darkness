using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionUp : MonoBehaviour 
{

	public bool detectUp;
	void Start()
	{
		detectUp = false;
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
			detectUp = true;
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Player")
			detectUp = false;
	}
}
