using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAB : MonoBehaviour 
{
	public GameObject portalBA;
	[SerializeField]
	public static bool teleportedAB;
	public float diferentaY;

	void Start()
	{
		teleportedAB = false;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player" && !teleportedAB)
		{
			other.transform.position = new Vector2(portalBA.transform.position.x,portalBA.transform.position.y-diferentaY);
			teleportedAB = true;
			PortalBA.teleportedBA = true;
		}	
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			teleportedAB = false;
			//PortalBA.teleportedBA = false;
		}
			
		
	}
	
}
