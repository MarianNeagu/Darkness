using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
	public bool detectPlayer;
	//public PlayerDetectionUp playerDetectionUp;
	bool once;

	void Start()
	{
		detectPlayer = false;
		once = true;
	}
	void OnCollisionStay2D(Collision2D col)
	{
		if(once)
			if(col.gameObject.tag == "Player" )
			{
				detectPlayer = true;	
				once = false;
				StartCoroutine(ResetDection());
			}
	}

	IEnumerator ResetDection()
	{
		float time = 0.1f, speed = 1f;
		while(time > 0f)                                                         
		{
			time -= Time.deltaTime * speed;                                 
			yield return 0;
			if(time	<=	0f)
			{
				detectPlayer = false;	
				once = true;
			}
		}
	}

	void OnCollsionExit2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			detectPlayer = false;
			once = true;
		}
			
	}
}
