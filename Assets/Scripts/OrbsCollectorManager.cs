using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OrbsCollectorManager : MonoBehaviour 
{
	public TextMeshProUGUI textNrOrbs;
	public GameManager gameManagerScript;
	public int nrCurrentOrbs;
	public int nrTotalOrbs;

	void Start()
	{
		textNrOrbs.text = "Orbs "+nrCurrentOrbs+"/"+nrTotalOrbs;
		nrCurrentOrbs = 0;
	}

	void Update ()
	{
		textNrOrbs.text = "Orbs "+nrCurrentOrbs+"/"+nrTotalOrbs;
		if(nrCurrentOrbs == nrTotalOrbs)
		{
			gameManagerScript._orbsCollected = true;
		}
	}



}
