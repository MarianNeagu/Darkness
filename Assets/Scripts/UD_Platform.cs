using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UD_Platform : MonoBehaviour 
{
	public PlayerDetection playerDetection;
    [Space]
    [Header("Pentru a mari viteza [moveSpeed]")]
	[Header("trebuie marita si lungimeCurs scazuta")]
    [Space]
	public float moveSpeed;

    [Header("Inaintea executarii se alege pozitia de inceput a platformei")]

	public bool isUp;
	public bool isDown;
	public float time;
	[Space]
    [Header("Nu merge modificata in Play mode")]
    [Space]
	public float lungimeCurs;
	void Start()
	{
		time = lungimeCurs;
	}

	void FixedUpdate()
	{
		if(time > 0 && isDown)
		{
			time -= Time.deltaTime;
			transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
			if(time <= 0)
			{
				isDown = false;
				isUp = true;
				time = lungimeCurs;
			}
		
		}
		else if(time > 0 && isUp)
		{
			time -= Time.deltaTime;
			transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
			if(time <= 0)
			{
				isDown = true;
				isUp = false;
				time = lungimeCurs;
			}
			if(playerDetection.detectPlayer)
			{
				time=lungimeCurs-time;
				isDown = true;
				isUp = false;
			}
		}
		else if(time==0 && isDown)
		{
			
		}
		

	}
}
