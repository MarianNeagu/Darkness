using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbOnTrigger : MonoBehaviour 
{
	public OrbsCollectorManager orbsCollectorManagerScript;
	public Animator orbDissapearAnim;
	bool orbCollected;
	public GameObject orbParticleSystem;
	void Start()
	{
		orbDissapearAnim = GetComponent<Animator>();
		orbCollected = false;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			if(!orbCollected)
			{
				orbsCollectorManagerScript.nrCurrentOrbs++;
				orbCollected = true;
				orbDissapearAnim.Play("OrbDissapear", 0, 0.5f);
				Instantiate(orbParticleSystem,transform.position,Quaternion.identity);
			}	
		}
	}
	void Update()
	{
		//normalizedTime - valoarea 1 => s-a terminat animatia; ex: val 0.5 la jumatatea animatiei
		if(this.orbDissapearAnim.GetCurrentAnimatorStateInfo(0).IsName("OrbDissapear") && 
		this.orbDissapearAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
			Destroy(gameObject);
		if(transform.parent != null)
		{
			
		}
	}
}
