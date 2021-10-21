using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBA : MonoBehaviour 
{
	public GameObject portalAB;
	[SerializeField]
	public static bool teleportedBA;
	public float diferentaY;
	void Start()
	{
		teleportedBA = false;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player" && !teleportedBA)
		{
			other.transform.position = new Vector2(portalAB.transform.position.x,portalAB.transform.position.y-diferentaY);
			teleportedBA = true;
			PortalAB.teleportedAB = true;
		}	
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			teleportedBA = false;
			//PortalAB.teleportedAB = false;
		}	
	}
}
