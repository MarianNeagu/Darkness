using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeParent : MonoBehaviour 
{
	public Transform child;
	void Update()
	{
        //Physics2D.IgnoreCollision(child.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
		
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if(col.tag == "Player")
			col.transform.parent = this.transform;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Player")
			col.transform.parent = null;
	}

}
