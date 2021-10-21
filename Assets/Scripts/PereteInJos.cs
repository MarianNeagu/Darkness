using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PereteInJos : MonoBehaviour 
{
    public GameObject perete;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
            perete.transform.position = new Vector3 (15.41581f, -1.15f, 0);
    }
}
