using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porte : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        
	}

    public void open()
    {
        //ouverture de la porte
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().flipY = true;
    }

    public void close()
    {
        //fer;eture de la porte
        Debug.Log("fermeture");
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<SpriteRenderer>().flipY = false;
    }
}
