using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LR_Platform : MonoBehaviour 
{
    [Space]
    [Header("Pentru a mari viteza [moveSpeed]")]
	[Header("trebuie marita si lungimeCurs scazuta")]
    [Space]
	public float moveSpeed;

    [Header("Inaintea executarii se alege pozitia de inceput a platformei")]

	public bool isRight;
	public bool isLeft;
	private float time;
	[Space]
    [Header("Nu merge modificata in Play mode")]
    [Space]
	public float lungimeCurs;

	void Start()
	{
		time = lungimeCurs;
	}
 	void OnTriggerStay2D(Collider2D other)
 	{
    	if(other.transform.tag == "Player")
    	{
			other.transform.parent = this.transform;
     	}
	}

	void OnTriggerExit2D(Collider2D other)
	{
    	if(other.transform.tag == "Player")
    	{
			other.transform.parent = null;
     	}		
	}

	void FixedUpdate()
	{

		if(time > 0 && isLeft)
		{
			time -= Time.deltaTime;
			transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
			if(time <= 0)
			{
				isLeft = false;
				isRight = true;
				time = lungimeCurs;
			}
		}
		else if(time > 0 && isRight)
		{
			time -= Time.deltaTime;
			transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
			if(time <= 0)
			{
				isLeft = true;
				isRight = false;
				time = lungimeCurs;
			}
		}

	}


	

	
}
